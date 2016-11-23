using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreInital.Controllers
{
    [Route("/company/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "+34 635838730";
        }

        public string Address()
        {
            return "Marques de Cerralbo";
        }
    }
}
