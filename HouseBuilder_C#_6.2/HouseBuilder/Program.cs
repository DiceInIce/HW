
using HouseBuilder.Team;
using HouseBuilder.Workers;
using HouseBuilder.Models;

internal class Programm
{
    static void Main()
    {
        var house = new House();

        var leader = new TeamLeader("Бригадир Иван");
        var team = new Team(leader);

        team.AddWorker(new Worker("Рабочий Алексей"));
        team.AddWorker(new Worker("Рабочий Петр"));
        team.AddWorker(new Worker("Рабочий Сергей"));
        team.AddWorker(new Worker("Рабочий Дмитрий"));

        team.BuildHouse(house);

        Console.WriteLine("\nНажмите любую клавишу, чтобы выйти...");
        Console.ReadKey();

    }
}