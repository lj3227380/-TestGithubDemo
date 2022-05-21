using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Utility.Filters;

namespace WebApp.Controllers
{

    //项目已经上线—且正常运行
    //产品经理—来个新需求 
    //1.停止服务器
    //2.升级代码---修改之前的代码
    //3.重新测试
    //4.重新发布
    //5.启动服务器


    //一、修改之前的代码
    //1.之前的代码会被影响----需要大量的测试工作
    //2.违背了开闭原则
    //3.修改之前的代码---增加相同的业务逻辑---代码差不多----大量的重复代码
    //4.代码很臃肿 
    //要让之前的代码不受影响---最好是不要动之前的代码

    //二、如何解决上面的问题？
    //--AOP出场---面向切面编程
    //1.不会破坏之前的代码
    //2.测试工作就会减少~~

    //三、ASP.NETCore6. AOP---Filter
    //1.授权---Authorize
    //2.资源--Resource
    //3.异常--Exception
    //4.方法前后---Action
    //5.AlwayRunResult6.结果前后---Result

    //四、ResourceFilter---资源Filter  经验---如果框架提供的是接口/抽象类---就是用来扩展的
    //1.扩展后标记在Action上
    // 2.执行顺序：  
    //a.CustomResourceFilterAttribute.OnResourceExecuting
    //b.控制器的构造函数
    //c.Action方法
    //d.CustomResourceFilterAttribute.OnResourceExecuted

    //五、ResouceFilter适合做什么?
    //1.天生就是为了缓存而生的。。  为设么呢？  

    //六、AOP：价值
    //1.不用修改之前的代码，就可以新增新的功能

    //七、Filter多种注册
    //1.方法注册：仅对当前方法生效
    //2.控制器（类）注册，对当前控制器下的所有方法都生效
    //3.全局注册：对整个项目中的所有的方法都生效


    //八、ActionFilter
    //1 直接实现IActionFilter 来扩展
    //2.执行顺序
    //    a.实例化控制器
    //    b.CustomActionFilterAttribute.OnActionExecuting
    //    c.执行Action
    //    d.CustomActionFilterAttribute.OnActionExecuted

    //九、ActionFilter 适合做什么？
    //1. 能不能做缓存？  ----当然是可以的---不推荐--为什么不推荐？
    //2. 因为Resoucefilter 做缓存性能更高，更快~~
    //3. 日志---为什么？--日志就要记录最真实的数据；


    //十、Log4net/Nlog    1   or   2  关于Nlog---去找助教老师去领取资源
    //详细看课件




    // [CustomCacheResourceFilter] //控制器（类）注册，对当前控制器下的所有方法都生效
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        { 
            logger.LogInformation($"{this.GetType().FullName}  被构造。。。");

            _logger = logger;
        }

        //[CustomCacheResourceFilter] 
        //[CustomLogActionFilterAttribute()]
        [TypeFilter(typeof(CustomLogActionFilterAttribute))]
        public IActionResult Index()
        {
            _logger.LogInformation($"Index 被执行。。。");
            //IActionFilter

            ViewBag.date = DateTime.Now.ToString();
            return View();
        }

        //[CustomCacheResourceFilter] //方法注册：仅对当前方法生效
        public IActionResult Index1()
        {
            {
                //这里是已经写好的业务逻辑
            }
            {
                //直接在这里改动
            }
            return View();
        }

        public IActionResult Index2()
        {
            {
                //这里是已经写好的业务逻辑
            }
            {
                //直接在这里改动
            }
            return View();
        }

    }
}