using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhaoXi.NET5.WebApp
{
    public class Program
    {
        /// <summary>
        /// 控制台---程序的入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ///1.创建一个主机的建造者
            IHostBuilder builder = CreateHostBuilder(args);
            //2.建造者Build下--得到一个主机
            IHost host = builder.Build();
            //3.主机启动运行
            host.Run();

            //主机：宿主，服务器---IIS,Nginx
            //.NET Core中已经自带主机~~不用依赖于IIS，不需要依赖于其他的主机；内置的主机 Kestral
            //

        }

        /// <summary>
        /// 配置主机结构
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //1.创建一个默认主机---抽象
            var bulder = Host.CreateDefaultBuilder(args);

            //2.配置成了一个Web主机--web服务器---怎么配?  通过一个委托来配置
            bulder = bulder.ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();  //使用Startup 来配置
                   });

            return bulder;
        }
    }
}
