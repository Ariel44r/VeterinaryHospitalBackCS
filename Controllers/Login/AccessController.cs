using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VeterinaryHospital.Controllers
{
    [Route("api/[controller]")]
    public class AccessController : Controller
    {
        S _s = new S();
        DatabaseManager _db = new DatabaseManager();

        //POST api/Login
        [HttpPost]
        public BaseResponse logIn()
        {
            return this.endPoint(_s.parseHeaders(Request.Headers));
        }

        //GET api/Login
        [HttpGet]
        public BaseResponse logOut()
        {
            return this.endPoint(_s.parseHeaders(Request.Headers));
        }

        //Generic handle Function (end Point)
        public BaseResponse endPoint(BaseRequestH headers)
        {
            Console.ForegroundColor = _s.validateApiKey(headers.apiKey) ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(" ===> [ Headers ]: {0}", JsonConvert.SerializeObject(headers));
            BaseUser[] user = _db.SqlConnection<BaseUser>();
            return(_s.validateApiKey(headers.apiKey) ? new LoginResponseC(0, _s.successAccess, user[0].user_Name, user[0].password) : new BadResponse(6, _s.notGrantedPrivileges) as BaseResponse);
        }
    }
}