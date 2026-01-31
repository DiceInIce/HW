using FitnessTracker.Data;
using FitnessTracker.Presentation;
using FitnessTracker.Configuration;
using Microsoft.EntityFrameworkCore;

var appConfiguration = new AppConfiguration();
var context = new FitnessTrackerContext(appConfiguration);

await context.Database.MigrateAsync();

var app = new Application(context);
app.Run();

context.Dispose();