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
        /// ����̨---��������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ///1.����һ�������Ľ�����
            IHostBuilder builder = CreateHostBuilder(args);
            //2.������Build��--�õ�һ������
            IHost host = builder.Build();
            //3.������������
            host.Run();

            //������������������---IIS,Nginx
            //.NET Core���Ѿ��Դ�����~~����������IIS������Ҫ���������������������õ����� Kestral
            //

        }

        /// <summary>
        /// ���������ṹ
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //1.����һ��Ĭ������---����
            var bulder = Host.CreateDefaultBuilder(args);

            //2.���ó���һ��Web����--web������---��ô��?  ͨ��һ��ί��������
            bulder = bulder.ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();  //ʹ��Startup ������
                   });

            return bulder;
        }
    }
}
