using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KUSYS_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using KUSYS_Demo.Services;
using KUSYS_Demo.Entities;
using Microsoft.Extensions.Logging;

namespace KUSYS_Demo.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Services.OperationsService OperationsService_;
    public HomeController(DatabaseContext databaseContext, IConfiguration configuration, ILogger<HomeController> logger)
    {
        OperationsService_ = new Services.OperationsService(databaseContext, configuration);
        _logger = logger;
    }

    public IActionResult Index()
    {
        try
        {
            var courseStudentViewModel_ = OperationsService_.GetCourseStudentList();
            if (courseStudentViewModel_ != null)
            {
                return View(courseStudentViewModel_);
            }
            return View();
        }
        catch (Exception ex)
        {
            //Error log here
            return View();
            throw;
        }
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
}

