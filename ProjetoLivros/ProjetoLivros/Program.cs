/* Passo a Passo CodeFirst
 * 1 - Crio e configuro as Models
 * 2 - Crio e configuro o Context
 * 3 - Realizo o migration
 * 4 - Criar as Interfaces
 * 5 - Criar os Repositories
 * 6 - Criar os Controllers
*/

using ProjetoLivros.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LivrosContext>(); // Define onde esta o Contexto no Codigo

/* Para realizar o CodeFirst adicione a linha acima e os codigos comentados abaixo
 * dotnet ef migrations add Inicial // Crio a migration para o C# identificar o banco de dados
 * dotnet ef database update // Crio o Banco de dados
*/

var app = builder.Build();

app.Run();