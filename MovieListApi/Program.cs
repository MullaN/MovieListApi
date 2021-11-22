using System.Reflection;
using ListListApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ConnectionFactory>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IListRepository, ListRepository>();
builder.Services.AddSingleton<IListEntryRepository, ListEntryRepository>();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IListService, ListService>();
builder.Services.AddSingleton<IListEntryService, ListEntryService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("OMDBApi", httpClient =>
{
    httpClient.BaseAddress = new Uri($"https://www.omdbapi.com/?apikey={builder.Configuration.GetSection("Values:OMDBApiKey").Value}");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.Equals("local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();