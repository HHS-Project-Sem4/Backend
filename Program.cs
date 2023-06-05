using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<outdoorFusionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=outdoorfusionserver.database.windows.net;Database=OutdoorFusion;User Id=floep;Password=WaaromWilDePausNietGecremeerdWorden?HijLeeftNog;")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
