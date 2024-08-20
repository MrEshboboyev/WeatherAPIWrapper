using WeatherAPIWrapper.External.HttpClients;
using WeatherAPIWrapper.Services;
using WeatherAPIWrapper.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding services lifetime
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Register HttpClient with DI
builder.Services.AddHttpClient<WeatherHttpClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WeatherAPI:BaseUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
