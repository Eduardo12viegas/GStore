using System.Net.Mail;
using System.Security;
using GStore.Models;
using GStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GStore.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    private readonly SignInManager<Usuario> _signInManager;

    private readonly UserManager<Usuario> _userManager;

    private readonly IWebHostEnvironment _host;



    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host
        )
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _host = host;
    }

    [HttpGet]
    public IActionResult Login(string returnUr1)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUr1 ?? Url.Content("~/")
        };
        return View(login);
    }
}

