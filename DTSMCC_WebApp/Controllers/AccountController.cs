using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DTSMCC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        string address;
        
        public AccountController()
        {
            this.address = "https://localhost:17828/api/Account/"; // port lihat di /api/properties/launchsettings.json

            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(address)
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            try
            {
                var result = HttpClient.PostAsync(address + "Login/", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                    HttpContext.Session.SetString("Role", data.data.Role);
                    ViewData["FullName"] = data.data.FullName;
                    var role = HttpContext.Session.GetString("Role");
                    if (role.Equals("Admin"))
                        return Redirect("/AdminPanel");
                    return Redirect("/Home");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            try
            {
                var result = HttpClient.PostAsync(address + "Register/", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    return Redirect("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
            }
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePassword), Encoding.UTF8, "application/json");
            try
            {
                var result = HttpClient.PostAsync(address + "ChangePassword/", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    HttpContext.Session.Clear();
                    return Redirect("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ChangePassword changePassword)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePassword), Encoding.UTF8, "application/json");
            try
            {
                var result = HttpClient.PostAsync(address + "ForgotPassword/", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    HttpContext.Session.Clear();
                    return Redirect("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Account/Login");
        }
    }
}
