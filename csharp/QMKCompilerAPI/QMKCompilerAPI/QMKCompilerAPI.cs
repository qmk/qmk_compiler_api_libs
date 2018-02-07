using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QMKCompilerAPI.Internal;
using RestSharp;
using static QMKCompilerAPI.Constants;

namespace QMKCompilerAPI
{
    // ReSharper disable once InconsistentNaming
    public static class QMKCompilerAPI
    {
        private static readonly RestClient Client = new RestClient(BASE);

        public static async Task<List<string>> GetKeyboards() => await DoRequestInternal<List<string>>(KEYBOARDS);

        public static async Task<Keyboard> GetKeyboard(string name)
        {
            var parameter = new Parameter
            {
                Type = ParameterType.UrlSegment,
                Name = KEYBOARD_PARAM,
                Value = name
            };

            var result = await DoRequestInternal<KeyboardRootResult>(KEYBOARD, parameter);
            return result.Keyboards[name];
        }

        private static async Task<T> DoRequestInternal<T>(string resource, params Parameter[] parameters) => await DoRequestInternal<T>(resource, Method.GET, parameters);
        private static async Task<T> DoRequestInternal<T>(string resource, Method method = Method.GET, params Parameter[] parameters)
        {
            var request = new RestRequest(resource, method)
            {
                DateFormat = "yyyy-MM-dd HH:mm:ss UTC"
            };

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            var result = await Client.ExecuteGetTaskAsync<T>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }

            throw new Exception();
        }
    }
}
