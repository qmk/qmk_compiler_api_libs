using QMKCompilerAPI.Internal;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using static QMKCompilerAPI.Constants;

namespace QMKCompilerAPI
{
    // ReSharper disable once InconsistentNaming
    public static class QMKCompilerAPI
    {
        /// <summary>
        /// Get a list of all available keyboards.
        /// </summary>
        /// <returns>A <list type="string"></list> with the names of all available keyboards.</returns>
        public static async Task<List<string>> GetKeyboardsAsync() => await RESTHelper.DoGetRequestInternal<List<string>>(KEYBOARDS);

        /// <summary>
        /// Get information about a keyboard.
        /// </summary>
        /// <param name="name">Name of the keyboard.</param>
        /// <returns>A <see cref="Keyboard"/> which contains information about the keyboard.</returns>
        public static async Task<Keyboard> GetKeyboardAsync(string name) =>
            (await RESTHelper.DoGetRequestInternal<KeyboardRootResult>(KEYBOARD,
                new Parameter { Type = ParameterType.UrlSegment, Name = KEYBOARD_PARAM, Value = name })).Keyboards[name];

        /// <summary>
        /// Request a layout to be compiled.
        /// </summary>
        /// <param name="request">Information for the complation request.</param>
        /// <returns>A <see cref="CompileRequestResult"/> containing the result of the request.</returns>
        public static async Task<CompileRequestResult> CompileKeyboardAsync(CompileRequest request) =>
            await RESTHelper.DoPostRequestInternal<CompileRequestResult>(COMPILE, request);

        /// <summary>
        /// Check the status of a compilation.
        /// </summary>
        /// <param name="result">The result object acquired from <see cref="CompileKeyboard"/></param>
        /// <returns>A <see cref="CompilationStatus"/> containing the information about the current status of the compilation.</returns>
        public static async Task<CompilationStatus> GetCompilationStatusAsync(CompileRequestResult result) =>
            await RESTHelper.DoGetRequestInternal<CompilationStatus>(COMPILE_CHECK,
                new Parameter { Type = ParameterType.UrlSegment, Name = COMPILE_CHECK_PARAM, Value = result.JobId });
    }
}