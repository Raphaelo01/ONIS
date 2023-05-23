using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ONIS.API.Catalog;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Host.RegisterHostConfigurations();
builder.Services.AddSwaggerGen(setupAction =>
{
    //Sin esto no podremos ver los detalles de la autenticacion
    setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this API"
    });

    //Sin estas lineas aunque nos autentiquemos no nos mostrara info porque no se envia automaticamente la autorizacion 
    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{
                Reference=new OpenApiReference{
                    Type=ReferenceType.SecurityScheme,
                    Id="CityInfoApiBearerAuth"
                }
            },new List<string>()
        }

    });
}

);
builder.Services.RegisterDataServices(builder.Configuration);
var configurationAutenticationSecurityForKey = builder.Configuration["Authentication:SecretForKey"] ?? string.Empty;
//Con este codigo habilitamos la autenticacion simple
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configurationAutenticationSecurityForKey))
        };
    }
    );

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
