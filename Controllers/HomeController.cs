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
        return Ok("Success");
    }

    [HttpGet("/sometimes4xx")]
    public IActionResult Sometimes4xx()
    {
        // Randomly return a 4xx status code or a successful response
        if (Random.Shared.Next(0, 2) == 0)
        {
            return NotFound(); // Example of a 4xx status code
        }
        else
        {
            return Ok("Success");
        }
    }

    [HttpGet("/sometimes5xx")]
    public IActionResult Sometimes5xx()
    {
        // Randomly return a 5xx status code or a successful response
        if (Random.Shared.Next(0, 2) == 0)
        {
            return StatusCode(500, "Internal Server Error"); // Example of a 5xx status code
        }
        else
        {
            return Ok("Success");
        }
    }

    [HttpGet("/sometimeslatent")]
    public async Task<IActionResult> SometimesLatent()
    {
        // Randomly introduce a delay or return a successful response immediately
        if (Random.Shared.Next(0, 2) == 0)
        {
            await Task.Delay(5000); // Simulate a 5-second delay
        }

        return Ok("Success");
    }
}
