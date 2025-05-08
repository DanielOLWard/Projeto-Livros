/* Passo a Passo CodeFirst
 * 1 - Crio e configuro as Models
 * 2 - Crio e configuro o Context
 * 3 - Realizo o migration
 * 4 - Criar as Interfaces
 * 5 - Criar os Repositories
 * 6 - Criar os Controllers
*/

using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjetoLivros.Context;
using ProjetoLivros.Inteface;
using ProjetoLivros.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Avisa que a aplicacao usa controllers
builder.Services.AddControllers();

// Adiciono o Gerador de Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LivrosContext>(); // Define onde esta o Contexto no Codigo

/* Para realizar o CodeFirst adicione a linha acima e os codigos comentados abaixo
 * dotnet ef migrations add Inicial // Crio a migration para o C# identificar o banco de dados
 * dotnet ef database update // Crio o Banco de dados
*/

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "livros",
            ValidAudience = "livros",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-blaster-super-secreta-de-seguranca-so-senai"))
        };
    });

builder.Services.AddAuthentication();

var app = builder.Build();

// Avisa o .Net que eu tenho Controllers
app.MapControllers();

// Aplica o Swagger
app.UseSwagger();
app.UseSwaggerUI(options => // Faz o Swagger abrir direto
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();