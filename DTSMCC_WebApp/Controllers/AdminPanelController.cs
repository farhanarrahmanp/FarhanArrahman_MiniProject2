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
    public class AdminPanelController : Controller
    {
        HttpClient HttpClient;
        string address;

        public AdminPanelController()
        {
            this.address = "https://localhost:17828/api/AdminPanel/"; // port lihat di /api/properties/launchsettings.json

            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(address)
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public IActionResult ChangeRole()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeRole(ChangeRole changeRole)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(changeRole), Encoding.UTF8, "application/json");
                try
                {
                    var result = HttpClient.PostAsync(address + "ChangeRole/", content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return Redirect("/AdminPanel");
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
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public IActionResult DeleteEmployee()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(ChangeRole changeRole)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(changeRole), Encoding.UTF8, "application/json");
                try
                {
                    var result = HttpClient.PostAsync(address + "DeleteEmployee/", content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return Redirect("/AdminPanel");
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
            return RedirectToAction("Unauthorized", "ErrorPage");
        }
    }
}
