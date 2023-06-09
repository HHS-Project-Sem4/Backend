using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<outdoorFusionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=outdoorfusionserver.database.windows.net;Database=OutdoorFusion;User Id=floep;Password=WaaromWilDePausNietGecremeerdWorden?HijLeeftNog;")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder =>
   {
       builder.WithOrigins("http://localhost:3000", "https://dev--outdoorfusion-dashboard.netlify.app/", "https://outdoorfusion-dashboard.netlify.app/")
              .AllowAnyMethod()
              .AllowAnyHeader();
   });

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
