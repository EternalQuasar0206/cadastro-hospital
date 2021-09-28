using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cadastro_hospital.Models;
using cadastro_hospital.Data;

namespace cadastro_hospital.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Home() {
            return View();
        }
    }
}