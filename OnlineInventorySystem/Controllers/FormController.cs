using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Logic;

namespace OnlineInventorySystem.Controllers
{
    public class FormController : Controller
    {
        private const string SessionKeyCompany = "_CompanyID";
        private FormLogic formlogic = new FormLogic();
        private CompanyManagerLogic companyMangerLogic = new CompanyManagerLogic();

        [HttpPost]
        public IActionResult LoginForm(InlogFormData inlogFormData)
        {
         bool empty = formlogic.NullCheck(inlogFormData.UsernameTextboxData, inlogFormData.PasswordTextboxData);
          if (empty == false)
          {
           int id = companyMangerLogic.CompanyLogin(inlogFormData.UsernameTextboxData, inlogFormData.PasswordTextboxData);
            if (id != 0)
            {
                SetSession(id);
                return View("~/Views/Home/Index.cshtml");
            }
          }
          return View("~/Views/Start/Index.cshtml");
        }

        public void SetSession(int id)
        {
            HttpContext.Session.SetInt32(SessionKeyCompany, id);
        }
    }
}