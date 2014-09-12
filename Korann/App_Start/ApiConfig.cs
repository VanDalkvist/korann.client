using System;
using Autofac;
using RestSharp;
using RestSharp.Injection;

namespace Korann.App_Start
{
    public class ApiConfig
    {
        public static void RegisterRestClients(ContainerBuilder builder)
        {
            const string host = "http://localhost:3001";

            builder.RegisterInstance((Func<string, IRestClient>)(url => (IRestClient)new RestClient(url)));
            builder.RegisterInstance((Func<string, Method, IRestRequest>)((resource, method) => (IRestRequest)new RestRequest(resource, method)));
            builder.RegisterType<RestSharpFactory>().As<IRestSharpFactory>();
            builder.RegisterInstance(new RestClient(host)).As<IRestClient>();
        }
    }
}