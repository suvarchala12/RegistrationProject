using Microsoft.AspNetCore.Mvc;
using Registration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegister _register;

        public RegistrationController(IRegister register)
        {
            _register = register;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegistrationModel());
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            var response=_register.InsertRegisterRecord(model);

            if (response > 0)
            {
                return View("Index");

            }
            else
            {
                return View(model);
            }
        }
    }
}
