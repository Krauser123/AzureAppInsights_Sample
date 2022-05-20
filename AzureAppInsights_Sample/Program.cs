var builder = WebApplication.CreateBuilder(args);

//Load environment name var
var envName = builder.Environment.EnvironmentName;

// Add appSettings per environment
builder.Configuration.AddJsonFile($"appsettings.{envName.ToLower()}.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add ApplicationInsights settings
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
    options.EnableAdaptiveSampling = Convert.ToBoolean(builder.Configuration["ApplicationInsights:EnableAdaptiveSampling"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
