using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BrushTicket
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("请输入要刷的id:");
            string id = Console.ReadLine();

            Console.WriteLine("要刷多少票?");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("间隔秒?");
            int interval = Convert.ToInt32(Console.ReadLine());



            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Proxy = new WebProxy("222.74.65.69", 56210),
                PreAuthenticate = true,
                UseDefaultCredentials = false,
            };

            
            for (int i = 0; i < count; i++)
            {
                string u = Guid.NewGuid().ToString("N");
                string t = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString();
                HttpClient client = new HttpClient(httpClientHandler);
                //client.().setProxy("192.168.101.1", 5608);
                //client.getParams().setAuthenticationPreemptive(true);
                ////如果代理需要密码验证，这里设置用户名密码  
                //client.getState().setProxyCredentials(AuthScope.ANY, new UsernamePasswordCredentials("llying.iteye.com", "llying"));  


                var result = await client.GetAsync($"http://lsfzlt.mschina2014.com/index/index/_like.html?id={id}&u={u}&t={t}");
                string resultStr = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"{i}-{resultStr}");
                Thread.Sleep(interval * 1000);
            }
        }
    }
}
