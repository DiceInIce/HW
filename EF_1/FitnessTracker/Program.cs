using FitnessTracker.Data;
using FitnessTracker.Presentation;
using FitnessTracker.Configuration;
using Microsoft.EntityFrameworkCore;

var appConfiguration = new AppConfiguration();
var context = new FitnessTrackerContext(appConfiguration);

var app = new Application(context);
app.Run();

context.Dispose();