﻿using INSN.Web.Common;
using INSN.Web.Portal.Services.Interfaces;
using INSN.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using INSN.Web.Models;

namespace INSN.Web.Portal.Controllers
{
    public class RedireccionarController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IRedireccionarProxy _proxy;

        /// <summary>
        /// Redireccionar Controller
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public RedireccionarController(IRedireccionarProxy proxy, IWebHostEnvironment env)
        {
            _proxy = proxy;
            _enviroment = env;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> Index(int p, string url)
        {
            string token = HttpContext.Session.GetString(Constantes.JwtToken);
            //SistemasViewModel model = new SistemasViewModel();

            if (token != null)
            {
                // Deserializar el token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Acceder a los claims (información) dentro del token
                var claims = jwtToken.Claims;

                // Obtener el valor de un claim específico
                var usuario = claims.FirstOrDefault(c => c.Type == "username")?.Value;

                // Realizar acciones con la información del token deserializado
                LoginSistemaDtoRequest modelo = new LoginSistemaDtoRequest();
                modelo.Usuario = usuario;
                modelo.CodigoSistemaId = p;

                var response = await _proxy.LoginSistema(modelo);

                if (response.Success)
                {
                    if (p == 1) // SegApp
                    {
                        // Leer token
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(response.Token);

                        // Leer los Claims
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        identity.AddClaims(jwt.Claims);

                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        
                        // Guardar token
                        HttpContext.Session.SetString(Constantes.JwtToken, response.Token);

                        return RedirectToAction("Index", "Menu");
                    }
                    else
                    {
                        if (p == 13)
                        {
                            return Redirect($"{url}");
                        }
                        else
                        {
                            return Redirect($"{url}?token={response.Token}");
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Sistemas");
        }
    }
}
