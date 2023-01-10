// See https://aka.ms/new-console-template for more information
using Evaluacion1._2;

var alertService = new AlertService(new AlertDAO());
var guuid=alertService.RaiseAlert();
Console.WriteLine(alertService.GetAlertTime(guuid));
