using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadastro_de_contatos.Models;
using cadastro_de_contatos.Repositorio;

namespace cadastro_de_contatos.Controllers;
// aqui eu vou colocar as ações (as rotas) de pegar os dados do front. toda vez que voce criar uma nova tela dentro da view (mais
// especificamente dentro da view de contato) voce vai precisar criar um arquivo para apontar.
public class ContatoController : Controller
{
    // é necessario criar um contrutor, pra poder injetar a interface do contato repositorie.

    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio; 
    }

    public IActionResult Index()
    {
        // preciso implementar o repositorio no contaoller.
        // aqui, vou implementar o metodo buscar todos do repositorio.
        // aqui, coloquei uma variavel, já tipando ela como List<ContatoModel>.
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

        // então, eu pego o contatos e retorno para dentro da view
        return View(contatos);
        // veja que o controller vai fazer a integração com o repositorio (que por sua vez, vai fazer a inegração com o banco de dados).
        // e o controller também vai retornar para a view
    }

    public IActionResult Criar()
    {
        return View();
    }

    // para a criação da edição, vai ser necessario eu passar o ID do que eu quero alterar.
    // porem, eu preciso retornar os dados do ID atual, para mostar em tela.
    public IActionResult Editar(int id)
    {
        // agora, implementando o repositorio
        ContatoModel? contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel? contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult Apagar(int id) 
    {
        _contatoRepositorio.Apagar(id);
        return RedirectToAction("Index");
    }
    // todos esses metodos servem para get.
    // precisamos criar os metodos para outras coisas.

    // aqui, estamos criando um metodo criar, passando o contato, do tipo ContatoModel
    // fora que precisamos deixar informado de qual tipo é esse metodo:
    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        _contatoRepositorio.Adicionar(contato);
        // depois que ele fizer isso, precisamos redirecionar ele para fazer uma ação. assim:
        // estou voltando ele para a pagina index.
        // quando ele salvar o novo contato, vai voltar para o inicio. 
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
        _contatoRepositorio.Atualizar(contato);
        return RedirectToAction("Index");
    }
}

