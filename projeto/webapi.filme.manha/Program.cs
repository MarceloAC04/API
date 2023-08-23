var builder = WebApplication.CreateBuilder(args);

//Adiciona servi�o de  Controller
builder.Services.AddControllers();

var app = builder.Build();


//Adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
