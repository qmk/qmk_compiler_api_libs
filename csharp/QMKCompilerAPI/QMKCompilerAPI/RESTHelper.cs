using RestSharp;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("QMKCompilerAPI.Test")]

namespace QMKCompilerAPI
{
    // ReSharper disable once InconsistentNaming
    internal static class RESTHelper
    {
        private static readonly RestClient Client = new RestClient(Constants.BASE);

        public static async Task<T> DoGetRequestInternal<T>(string resource, params Parameter[] parameters)
        {
            var request = CreateRequest(resource, Method.GET, parameters);
            var response = await Client.ExecuteGetTaskAsync<T>(request);
            return TryGetResultOrThrow(response);
        }

        public static async Task<T> DoPostRequestInternal<T>(string resource, object body)
        {
            var request = CreateRequest(resource, Method.POST);
            request.AddParameter("body", body, ParameterType.RequestBody);
            var response = await Client.ExecutePostTaskAsync<T>(request);
            return TryGetResultOrThrow(response);
        }

        private static IRestRequest CreateRequest(string resource, Method method, params Parameter[] parameters)
        {
            var request = new RestRequest(resource, method) { DateFormat = "yyyy-MM-dd HH:mm:ss UTC", };
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            return request;
        }

        private static T TryGetResultOrThrow<T>(IRestResponse<T> response)
        {
            if (response.IsSuccessful)
            {
                return response.Data;
            }

            throw new Exception(response.Content, response.ErrorException);
        }
    }
}