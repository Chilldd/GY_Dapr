using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprSystemManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemManageController : ControllerBase
    {
        [HttpGet("GetUserInfo")]
        public UserInfo GetUserInfo() => new UserInfo
        {
            Name = "张三",
            Sex = 0,
            Age = 15,
            Birthday = DateTime.Now,
            Address = "商丘市柘城县"
        };
    }

    public class UserInfo
    {
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
