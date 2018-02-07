# C# Library for the QMK Compile API

Provides access to all the API endpoints as well as an automated process of submitting a compilation request and downloading the result.

## Usage example
```cs
// Get the names of all keyboards
List<string> keyboards = await QMKCompilerAPI.GetKeyboardsAsync();

// Select one of the compatible keyboards, for example the Planck and request the keyboard information
Keyboard kb = await QMKCompilerAPI.GetKeyboardAsync("planck/rev5");

// Create a compilation request
var request = new CompileRequest(kb, "KEYMAP", "my_layout_name", new []{
    new [] { /* keycodes... */ },
    // more layers...
});

// Submit the request
CompileRequestResult result = await QMKCompilerAPI.CompileKeyboardAsync(request);

// Periodically check the current status
CompilationStatus status = await QMKCompilerAPI.GetCompilationStatusAsync(result);

// Finally if it is sucessfull, download the firmware
var filepath = "./mykeymap.hex"
await QMKCompilerAPI.DownloadFirmwareAsync(status, filepath);
```

This process can also be fully automated in the following way
```cs
AutoCompilationResult result = await QMKCompilerAPI.CompileAndDownloadAsync(kb, request);
if(result.Success)
{
    result.Save(filepath);
}
```
This will submit a request and periodically check if the compilation is done or has failed.
In either of those cases it will return a result object that will contain info whether it succeeded and if so the data for the firmare. If it didn't succeed it will contain the error information as well.