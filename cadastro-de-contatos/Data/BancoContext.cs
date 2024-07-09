using System;
using cadastro_de_contatos.Models;
using Microsoft.EntityFrameworkCore;

// os usings servem como a importação no javascript. 
// aqui vamos fazer a configuração do DB
namespace cadastro_de_contatos.Data
{
        // aqui, estamos herdando tudo de DbContext para nossa classe BancoContext.
        public class BancoContext : DbContext
        {
                // esse é o construtor.
                // o construtor vai receber o nome da classe.
                // vamos injetar o DbContextOptions como parametro do metodo dessa classe.
                // vamos tipar o DbContextOptions usando a propria classe BancoContext (que esta herdadndo de DbContext)
                // depois disso, colocamos o nome de option.
                // agora, precisamos passar o options para dentro do contrutor. isso é feito usando base(options).
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                public BancoContext(DbContextOptions<BancoContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                {
                }

                // agora, vem a configuração do model para o contexo do data.
                // passando o DbSet, podemos importar o ContatoModel (que é a representação do banco de dados que a gente quer criar)
                // depois, damos um nome de como ela vai se chamar no banco de dados. 
                public DbSet<ContatoModel> Contatos { get; set; }
        }
}

