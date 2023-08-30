using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona serviço de  Controller
builder.Services.AddControllers();

//Adiciona a servico do Swagger
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de filmes - Introdução da sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Marcelo",
            Url = new Uri("https://github.com/MarceloAC04")
        }
    });
    //Configura o Swagger para usar o arquivo XML gerado
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();
//Aqui começa a configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
