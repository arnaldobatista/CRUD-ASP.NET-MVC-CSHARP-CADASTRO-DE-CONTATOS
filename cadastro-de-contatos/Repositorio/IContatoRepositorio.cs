using System;
using cadastro_de_contatos.Models;

// a interface é a assinatura do contrato.
// vamos criar todos os metodos que vamos usar no repositorio.

namespace cadastro_de_contatos.Repositorio
{
	public interface IContatoRepositorio
	{
        // aqui, vamos colocar como deve ser nossos metodos.
        // é necessario importar o do cadastro_de_contatos.Models;
        // precisamos passar o metodo adicionar;
        // o acicionar precisa add algo, então, como parametro, vamos colocar o contato de parametro, porem, colocando ContatoModel antes para a tipagem.
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> BuscarTodos();
        ContatoModel? ListarPorId(int id);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}

