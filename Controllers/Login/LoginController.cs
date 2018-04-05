using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VeterinaryHospital.Controllers
{
    [Route("api/[controller]")]
    public class Logincontroller : Controller
    {
        S _s = new S();

        //POST api/Login
        [HttpPost]
        public BaseResponse logIn()
        {
            return this.endPoint(Request.Headers["apiKey"]);
        }

        //GET api/Login
        [HttpGet]
        public BaseResponse logOut()
        {
            return this.endPoint(Request.Headers["apiKey"]);
        }

        //Generic handle Function (end Point)
        public BaseResponse endPoint(string apiKey)
        {
            return(_s.validateApiKey(apiKey) ? new LoginResponseC(0, _s.successAccess, null, null) : new BadResponse(6, _s.notGrantedPrivileges) as BaseResponse);
        }
    }
}