using RestSharp;

namespace Korann.Infrastructure
{
    public class ApiClient : IApiClient
    {
        private readonly IRestClient _client;

        public ApiClient(IRestClient client)
        {
            _client = client;
        }

        public TData Get<TData>(string resource) where TData : new()
        {
            var response = _client.Get<TData>(new RestRequest(resource));
            return response.Data;
        }

        public TData Post<TData>(string resource) where TData : new()
        {
            var response = _client.Post<TData>(new RestRequest(resource));
            return response.Data;
        }

        public TData Put<TData>(string resource) where TData : new()
        {
            var response = _client.Put<TData>(new RestRequest(resource));
            return response.Data;
        }

        public TData Delete<TData>(string resource) where TData : new()
        {
            var response = _client.Delete<TData>(new RestRequest(resource));
            return response.Data;
        }
    }

    public interface IApiClient
    {
        TData Get<TData>(string resource) where TData : new();

        TData Post<TData>(string resource) where TData : new();

        TData Put<TData>(string resource) where TData : new();

        TData Delete<TData>(string resource) where TData : new();
    }
}