using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_new_mvc.Models;

namespace dotnet_new_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("/success")]
    public IActionResult Success()
    {
        // Return a successful response
        return Ok("Successful, as always");
    }

    [HttpGet("/sometimes4xx")]
    public IActionResult Sometimes4xx()
    {
        // Return a successful response
        return Ok("Successful, as always");
    }

    [HttpGet("/sometimes5xx")]
    public IActionResult Sometimes5xx()
    {
        // Return a successful response
        return Ok("Successful, as always");
    }

    [HttpGet("/sometimeslatent")]
    public async Task<IActionResult> SometimesLatent()
    {
        // Return a successful response
        return Ok("Successful, as always");
    }
}
