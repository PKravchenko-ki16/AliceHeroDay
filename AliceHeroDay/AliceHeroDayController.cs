using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model;
using AliceHeroDay.Model.SuperHeroDayProcedure;

namespace AliceHeroDay
{
    public class AliceSuperHeroDayController : Controller
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);

            var host = builder.Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(srv => srv.AddMvc())
            .Configure(app => app.UseMvc());

        private static ConcurrentDictionary<string, SuperHeroDaySession> _superHeroDaySession = new ConcurrentDictionary<string, SuperHeroDaySession>();

        [HttpPost("/superheroday")]
        public AliceResponse WebHook([FromBody] AliceRequest req)
        {
            try
            {
                return WebHookSuperHeroDay(req);
            }
            catch (Exception e)
            {
                return new AliceResponse { Response = new ResponseModel { Text = e.ToString() } };
            }
        }

        private static AliceResponse WebHookSuperHeroDay(AliceRequest req)
        {
            SuperHeroDayProcedure superHeroDayProcedure = new SuperHeroDayProcedure();

            if (req.Session.New && (req.Session.MessageId == 0))
            {
                _superHeroDaySession.AddOrUpdate(req.Session.SessionId, new SuperHeroDaySession() { MessageId = req.Session.MessageId },
                    (key, oldValue) => new SuperHeroDaySession() { MessageId = req.Session.MessageId });
                //это безопастно так как каждый user работает со своим уникальным ключём, 
                //и то что функция не вызывает блокировку потока на добавление и обновление ни на что не повлияет.
            }

            var response = superHeroDayProcedure.Procedure(req, _superHeroDaySession);

            //if (response.Response.EndSession)
            //{
            //    _superHeroDaySession.TryRemove(req.Session.SessionId, out SuperHeroDaySession value);
            //}

            return response;
        }
    }
}