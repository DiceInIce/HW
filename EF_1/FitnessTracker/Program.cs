using FitnessTracker.Data;
using FitnessTracker.Presentation;

var context = new FitnessTrackerContext();
var app = new Application(context);
app.Run();

context.Dispose();