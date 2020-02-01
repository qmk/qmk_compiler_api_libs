using System;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace QMKCompilerAPI.Test
{
    public class RESTHelperTests
    {
        #region Test Setup
        private readonly Parameter goodParam = new Parameter()
        {
            Type = ParameterType.UrlSegment,
            Name = Constants.KEYBOARD_PARAM,
            Value = "planck/rev6"
        };

        private readonly Parameter badParamType = new Parameter()
        {
            Type = (ParameterType)69,
            Name = Constants.KEYBOARD_PARAM,
            Value = "planck/rev6"
        };

        private readonly Parameter badParamName = new Parameter()
        {
            Type = ParameterType.UrlSegment,
            Name = "Bad Name",
            Value = "planck/rev6"
        };

        private readonly Parameter badParamValue = new Parameter()
        {
            Type = ParameterType.UrlSegment,
            Name = Constants.KEYBOARD_PARAM,
            Value = "Bad Value"
        };

       private readonly CompileRequest goodRequest = new CompileRequest(
            new Keyboard() 
            { 
                KeyboardName = "PretendThisExists" 
            }, 
            "keymap", "layout", new string[1][]);

        private readonly string badResource = "Bad Resource";
        private readonly string goodResource = Constants.KEYBOARD;
        #endregion

        [Fact]
        public void Get_throws_if_bad_resource()
        {
            Func<Task> a1 = async () =>
            {
                await RESTHelper.DoGetRequestInternal<object>(badResource);
            };
            a1.Should().Throw<Exception>().And.Message.Contains(badResource);

            Func<Task> a2 = async () =>
            {
                await RESTHelper.DoGetRequestInternal<object>(
                    badResource,
                    goodParam);
            };
            a2.Should().Throw<Exception>().And.Message.Contains(badResource);
        }

        [Fact]
        public void Get_throws_if_bad_param()
        {
            Func<Task> a1 = async () =>
            {
                await RESTHelper.DoGetRequestInternal<object>(
                    goodResource,
                    badParamName);
            };
            a1.Should().Throw<Exception>().And.Message.Contains(badParamName.Name);

            Func<Task> a2 = async () =>
            {
                await RESTHelper.DoGetRequestInternal<object>(
                    goodResource,
                    badParamType);
            };
            a2.Should().Throw<Exception>().And.Message.Contains(badParamType.Type.ToString());

            Func<Task> a3 = async () =>
            {
                await RESTHelper.DoGetRequestInternal<object>(
                    goodResource,
                    badParamValue);
            };
            a3.Should().Throw<Exception>().And.Message.Contains(badParamValue.Value.ToString());
        }

        [Fact]
        public void Post_throws_if_bad_resource()
        {
            Func<Task> a = async () =>
            {
                await RESTHelper.DoPostRequestInternal<object>(badResource, goodRequest);
            };
            a.Should().Throw<Exception>().And.Message.Contains(badResource);
        }

        [Fact]
        public void Post_throws_if_bad_request()
        {
            Func<Task> a = async () =>
            {
                await RESTHelper.DoPostRequestInternal<object>(goodResource, null);
            };
            a.Should().Throw<Exception>().And.Message.Contains("null");
        }
    }
}
