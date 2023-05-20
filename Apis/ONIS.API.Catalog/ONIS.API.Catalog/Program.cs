var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//Uso estas lineas porque no he podido configurar los ambientes en docker, pero los eliminare cuando ya este pasando a pasos de produccion
app.UseSwagger();
app.UseSwaggerUI();
//}

//Agregar HealthChecks

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
