using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZhaoXi.NET6.AuthenticationCenter.Utility;

namespace ZhaoXi.NET6.AuthenticationCenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private ICustomJWTService _ICustomJWTService;
        public AuthenticationController(ICustomJWTService customJWTService)
        {
            this._ICustomJWTService = customJWTService;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>() { 1, 2, 3, 4, 6, 7 };
        }

        [Route("Login")]
        [HttpPost]
        public string Login(string name, string password)
        {
            //������ȥ��֤���ݿ⣬��֤�û����������Ƿ���ȷ
            if ("Richard".Equals(name) && "123456".Equals(password)) //����Ϊ��֤ͨ����
            {
                //��Ӧ������Token 
                string token = this._ICustomJWTService.GetToken(name, password);
                return JsonConvert.SerializeObject(new
                {
                    result = true,
                    token
                });

            }
            else
            {
                return JsonConvert.SerializeObject(new
                {
                    result = false,
                    token = ""
                });
            }
        }
    }
}