using EjemploFlujoAsync;
using System.Diagnostics;



// MANERA SINCRONA
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();


Console.WriteLine("\nBienvenido a la calculadora de Hipotecas Síncrona");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo Neto Obtenido: {sueldoNeto}€");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensuales}");


var hipotecaCondedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMensuales, cantidadSolicitada: 50000, aniosPagar: 30);

var resultado = hipotecaCondedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis finalizado. Su solicitud de hipoteca ha sido: {resultado}");

stopwatch.Stop();

Console.WriteLine($"\nLa operacion Sincrona ha durado: {stopwatch.Elapsed}");

//Reiniciamos un controlador de tiempo
stopwatch.Restart();
Console.WriteLine("\n*****************************");
Console.WriteLine("\nBienvenido a la calculadora de Hipotecas Asíncrona");
Console.WriteLine("\n*****************************");


Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboral();

Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();

Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();

Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var analisisHipotecaTask = new List<Task>
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (analisisHipotecaTask.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTask);

    if (tareaFinalizada == aniosVidaLaboralTask)
    {

        Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboralTask.Result}");

    }
    else if (tareaFinalizada == esTipoContratoIndefinidoTask)
    {

        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");

    }
    else if (tareaFinalizada == sueldoNetoTask)
    {

        Console.WriteLine($"\nSueldo Neto Obtenido: {sueldoNetoTask.Result}€");

    }
    else if (tareaFinalizada == gastosMensualesTask)
    {

        Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensualesTask.Result}");

    }

    analisisHipotecaTask.Remove(tareaFinalizada); // Eliminamos de la lista de tareas la tarea finalizada para salir del While

}

var hipotecaAsyncCondedida = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMensualesTask.Result, cantidadSolicitada: 50000, aniosPagar: 30);

var resultadoAsync = hipotecaAsyncCondedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");

stopwatch.Stop();

Console.WriteLine($"\nLa operacion Asícrona ha durado: {stopwatch.Elapsed}");

Console.Read();
