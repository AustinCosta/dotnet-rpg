global using dotnet_rpg.Models;
using dotnet_rpg.Data;
using dotnet_rpg.Services.CharacterService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Auto Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Register the character service
//Now the web api knows it has to use the CharacterService class whenever a controller wants to inject
//the ICharacterService
builder.Services.AddScoped<ICharacterService, CharacterService>();

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
