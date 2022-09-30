using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Context;
using Microsoft.EntityFrameworkCore;
using API.Repositories.Data;
using API.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdminPanelController : Controller
    {
        AdminPanelRepository adminPanelRepository;

        public AdminPanelController(AdminPanelRepository adminPanelRepository)
        {
            this.adminPanelRepository = adminPanelRepository;
        }

        [HttpPost]
        public IActionResult ChangeRole(ChangeRole changeRole)
        {
            var data = adminPanelRepository.ChangeRole(changeRole.Email, changeRole.Role);
            if (data > 0)
                return Ok(new { message = "berhasil ubah role", statusCode = 200, data = data });
            return BadRequest(new { message = "gagal ubah role", statusCode = 400 });
        }

        [HttpPost]
        public IActionResult DeleteEmployee(ChangeRole changeRole)
        {
            var data = adminPanelRepository.DeleteEmployee(changeRole.Email);
            if (data > 0)
                return Ok(new { message = "berhasil hapus employee", statusCode = 200, data = data });
            return BadRequest(new { message = "gagal hapus employee", statusCode = 400 });
        }
    }
}
