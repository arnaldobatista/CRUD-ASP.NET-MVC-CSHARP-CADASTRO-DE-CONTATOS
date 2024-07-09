using System;
using cadastro_de_contatos.Data;
using cadastro_de_contatos.Models;
// A pasta repositorio serve para colocar os respositorios. essa pasta vai ter todos os metodos  do crud fazendo contato com a tabela de contatos
namespace cadastro_de_contatos.Repositorio
{
    // para implementar uma interface em uma classe, se usa : IContatoRepositorio 
	public class ContatoRepositorio : IContatoRepositorio
    {
        // aqui vamos extrair. criamos uma variavel do tipo BancoContext, ela é privada. somente essa classe pode ver ela.
        // como ela é privada, temos que colocar o nome dela iniciando com _
        private readonly BancoContext _bancoContext;

        // para podermos injetar o contexto, precisamos fazer um contructor, e passar o contexto para o contructor.
        // passamos primeiro o tipo BancoContext depois colocamos a propriedade dele: bancoContext.
        // porem. não tem como usar o bancoContext fora do contexto do contructor direto.
        // é preciso criar extrair uma variavel para poder ter acesso.

        public ContatoRepositorio(BancoContext bancoContext)
		{
            // aqui, é só colocar o _bancoContext sendo a mesma coisa que o bancoContext.
            // assim, poderemos acessar o bancoContext fora do contexto do contructor.
            _bancoContext = bancoContext;
        }
        // aqui, assinamos o contrato confome a interface estabeleceu.
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // aqui, fazemos a implementação do contexto, que fara o trabalho de inserir propriamente dito no banco de dados.
            // para inserirmos podermos fazer a implementação do contexto, precisamos injetar o contexto para dentro do contatoRepositorio

            // agora, para criar essa manipulação, é assim:
            _bancoContext.Contatos.Add(contato);
            // depois desse comando, precisamos comittar esse comando ainda.
            // agora, damos o save.
            _bancoContext.SaveChanges();

            // depois, é só retornar o contato.
            return contato;
        }

        // aqui, vamos pegar tudo que esta na tabela contatos e vai retornar em uma lista
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        // aqui, estamos buscando o contato por um ID especifico. 
        public ContatoModel? ListarPorId(int id)
        {
            // estamos chamando o banco, dentro da tabela contatos e pesquisando por um ID.
            // precisamos fazer uma expressão para localizar. 
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        // preciso salvar os novos dados atualizados no id informado (só que esse metodo não pega o ID 
        public ContatoModel Atualizar(ContatoModel contato)
        {
            // ai é só criar uma variavel
            ContatoModel? contatoDb = ListarPorId(contato.Id);

            // agora é só verificar

            if (contatoDb == null) throw new System.Exception("Id não existe");

            // caso encontre, ele vai fazer a requisição para a atualização.
            // nesse caso, não é necessario passar o ID novamente, porque ele ja pegou o ID no ContatoModel? contatoDb = ListarPorId(contato.Id);
            // aqui, aparentemente ele mexe na estrutura do objeto primeiro, e depois voce manda o objeto para o update.

            contatoDb.Nome = contato.Nome; 
            contatoDb.Email = contato.Email;
            contatoDb.Telefone = contato.Telefone;

            _bancoContext.Contatos.Update(contatoDb);
            // nunca se esqueça de salvar as alterações.
            _bancoContext.SaveChanges();

            // logo após, retorne o contato atualizado

            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel? contatoDb = ListarPorId(id);

            if (contatoDb == null) throw new System.Exception("Id não existe");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
