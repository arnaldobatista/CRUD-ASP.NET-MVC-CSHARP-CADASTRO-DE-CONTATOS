using System;
namespace cadastro_de_contatos.Models
{
	public class ContatoModel
	{
 	 	public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

