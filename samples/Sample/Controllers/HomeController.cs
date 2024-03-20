﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Serilog;

namespace Sample.Controllers;

public class HomeController : Controller
{
    static int _callCount;

    readonly ILogger<HomeController> _logger;
    readonly IDiagnosticContext _diagnosticContext;

    public HomeController(ILogger<HomeController> logger, IDiagnosticContext diagnosticContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Hello, world! Hello");

        _diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref _callCount));

        return View();
    }

    public IActionResult Privacy()
    {
        throw new InvalidOperationException("Something went wrong.");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}