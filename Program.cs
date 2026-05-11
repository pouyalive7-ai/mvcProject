using MyLibrary;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ConfigurationsLeser>();
builder.Services.AddScoped(sp => new DatenbankKontext(
    sp.GetRequiredService<ConfigurationsLeser>().GetConnectionString()));

builder.Services.AddScoped<FahrzeugRepository>();


builder.Services.AddMvc();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "My API", Version = "v1" });
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public class ConfigurationsLeser
{
    private readonly IConfiguration _configuration;

    public ConfigurationsLeser(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("mypostgres");
    }
}