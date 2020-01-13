using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LojaJaguar.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaJaguar.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult LoginPage()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserPage");
            }

            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //dados estáticos
                    if (usuario.Login == "felipe" && usuario.Senha == "12345")
                    {
                        Login(usuario);
                        return RedirectToAction("UserPage");
                    }
                    if(usuario.Login!="felipe")
                    {
                        ViewBag.Erro = "Usuário incorreto!";
                    }
                    if(usuario.Senha!="12345")
                    {
                        ViewBag.Erro = "Senha incorreta!";
                    }
                    if (usuario.Login != "felipe" && usuario.Senha != "12345")
                    {
                        ViewBag.Erro = "Usuário e Senha incorretos!";
                    }

                }
            }
            catch (Exception)
            {
                ViewBag.Erro = "Ocorreu algum erro ao tentar se logar, tente novamente!";
            }
            return View();
        }

        private async void Login(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim(ClaimTypes.Role, "Usuario_Comum")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(2),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        [Authorize]
        public IActionResult UserPage()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage");
        }
    }
}