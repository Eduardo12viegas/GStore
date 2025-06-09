using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using GStore.Models;
using GStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            string userName = login.Email;
            if (IsValidEmail(login.Email))
            {
                var user = await _userManager.FindByEmailAsync(
                    userName, login.Senha, login.Lembrar, lockoutOnFailture: true   
                );
            if (result.suceeded) {
                    _logger.LogInformation($"Usuário {login.Email} acessou o sitema");
                    return LocalRedirect(localUrlRetorno);
                }
            if (result.IsLockedOut) {
                    _logger.LogWarning($"Usuário {login.Email} está bloqueado");
                    ModelState.AddModelError("", "Sua conta está bloqueada, aguarde alguns minutos e tente novamente!!");
                   }
             if (result.IsNotAllowed) {
                    _logger.LogWarning($"Usuário {login.Email} não confirmou sua conta");
                    ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!!!");
                }
                    else
                        ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!!!");
                }
                return View(login);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            Public async async Task<IActionResult> Logout()
            {
                _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index, Home");
            }
        }
    }
}

