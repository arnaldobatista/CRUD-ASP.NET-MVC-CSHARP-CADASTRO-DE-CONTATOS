using cadastro_de_contatos.Data;
using cadastro_de_contatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
// preciso configurar as credenciais do banco de dados.
// vou iniciar o AddEntityFrameworkSqlServer de dentro do Services, passando o AddDbContext.
// preciso tipar o AddDbContext como BancoContext.
// estou dizendo que eu vou usar o sql server, e o contexto que eu vou usar é o BancoContext.
// para acessar o banco de dados, precisamos usar o  o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
// eu ja coloque as linhas para poder resolver a injeção de dependencia do BancoContext no codigo acima.
// agora, preciso resolver a injeção de dependencia do IContatoRepositorio
// toda vez que meu IContatoRepositorio for chamada eu quero que ele resolva chamar o ContatoRepositorio.
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

