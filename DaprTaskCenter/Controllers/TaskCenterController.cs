using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaprTaskCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCenterController : ControllerBase
    {
        private readonly DaprClient client;

        public TaskCenterController(DaprClient client)
        {
            this.client = client;
        }

        [HttpGet("GetTaskInfo")]
        public async Task<TaskInfo> GetTaskInfo()
        {
            var userInfo = await client.InvokeMethodAsync<UserInfo>(HttpMethod.Get, "SystemManage", "api/SystemManage/GetUserInfo");
            return new TaskInfo()
            {
                TaskGroup = "Group1",
                TaskName = "TestTask",
                StartTime = DateTime.Now,
                Status = 0,
                UserInfo = userInfo
            };
        }
    }

    public class TaskInfo
    {
        public string TaskGroup { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public int Status { get; set; }
        public UserInfo UserInfo { get; set; }
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
