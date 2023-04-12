using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CourseCompanion;
using CourseCompanion.Shared.Services;
using CourseCompanion.Shared.State;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped(typeof(ICourseService), typeof(CourseService));
builder.Services.AddSingleton<StateContainer>();

builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();

