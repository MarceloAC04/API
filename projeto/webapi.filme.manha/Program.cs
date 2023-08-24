using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Adiciona servi�o de  Controller
builder.Services.AddControllers();

//Adiciona a servico do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Aqui come�a a configura��o do Swagger
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
