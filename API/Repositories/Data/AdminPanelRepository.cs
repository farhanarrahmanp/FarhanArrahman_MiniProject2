using System;
using API.Context;
using API.Models;
using System.Linq;
using System.Collections.Generic;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AdminPanelRepository
    {
        MyContext myContext;

        public AdminPanelRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int ChangeRole(string email, string role)
        {
            var data = myContext.UserRoles.Include(x => x.User).Include(x => x.User.Employee).SingleOrDefault(x => x.User.Employee.Email.Equals(email));
            var roleId = myContext.Roles.SingleOrDefault(x => x.Name.Equals(role)).Id;
            if (data == null)
            {
                return 0;
            }
            data.RoleId = roleId;
            myContext.Entry(data).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                return result;
            return 0;
        }

        public int DeleteEmployee(string email)
        {
            var userRole = myContext.UserRoles.Include(x => x.User).Include(x => x.User.Employee).SingleOrDefault(x => x.User.Employee.Email.Equals(email));
            var user = myContext.Users.Include(x => x.Employee).SingleOrDefault(x => x.Employee.Email.Equals(email));
            var employee = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email));

            myContext.UserRoles.Remove(userRole);
            myContext.SaveChanges();
            myContext.Users.Remove(user);
            myContext.SaveChanges();
            myContext.Employees.Remove(employee);
            var result = myContext.SaveChanges();
            if (result > 0)
                return result;
            return 0;
        }
    }
}
