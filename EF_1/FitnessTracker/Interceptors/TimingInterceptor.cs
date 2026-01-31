using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace FitnessTracker.Interceptors;

public class TimingInterceptor : DbCommandInterceptor
{
	private readonly Dictionary<DbCommand, Stopwatch> _stopwatches = new();

	public override InterceptionResult<DbDataReader> ReaderExecuting(
			DbCommand command,
			CommandEventData eventData,
			InterceptionResult<DbDataReader> result)
	{
		_stopwatches[command] = Stopwatch.StartNew();
		LogCommandStart(command);
		return base.ReaderExecuting(command, eventData, result);
	}

	public override DbDataReader ReaderExecuted(
			DbCommand command,
			CommandExecutedEventData eventData,
			DbDataReader result)
	{
		LogCommandEnd(command);
		return base.ReaderExecuted(command, eventData, result);
	}

	public override InterceptionResult<object> ScalarExecuting(
			DbCommand command,
			CommandEventData eventData,
			InterceptionResult<object> result)
	{
		_stopwatches[command] = Stopwatch.StartNew();
		LogCommandStart(command);
		return base.ScalarExecuting(command, eventData, result);
	}

	public override object? ScalarExecuted(
			DbCommand command,
			CommandExecutedEventData eventData,
			object? result)
	{
		LogCommandEnd(command);
		return base.ScalarExecuted(command, eventData, result);
	}

	public override InterceptionResult<int> NonQueryExecuting(
			DbCommand command,
			CommandEventData eventData,
			InterceptionResult<int> result)
	{
		_stopwatches[command] = Stopwatch.StartNew();
		LogCommandStart(command);
		return base.NonQueryExecuting(command, eventData, result);
	}

	public override int NonQueryExecuted(
			DbCommand command,
			CommandExecutedEventData eventData,
			int result)
	{
		LogCommandEnd(command);
		return base.NonQueryExecuted(command, eventData, result);
	}

	private void LogCommandStart(DbCommand command)
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine($"[SQL] Executing: {command.CommandText}");

		if (command.Parameters.Count > 0)
		{
			Console.WriteLine("      Parameters:");
			foreach (DbParameter param in command.Parameters)
			{
				Console.WriteLine($"        {param.ParameterName} = {param.Value ?? "NULL"}");
			}
		}
		Console.ResetColor();
	}

	private void LogCommandEnd(DbCommand command)
	{
		if (_stopwatches.TryGetValue(command, out var stopwatch))
		{
			stopwatch.Stop();
			var elapsedMs = stopwatch.ElapsedMilliseconds;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"[SQL] Completed in {elapsedMs}ms");

			if (elapsedMs > 1000)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"WARNING: Query exceeded 1 second!");
			}
			Console.ResetColor();

			_stopwatches.Remove(command);
		}
	}
}
