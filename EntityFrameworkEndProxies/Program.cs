using EntityFrameworkEndProxies.Data;
using EntityFrameworkEndProxies.Models;
using ScreenSound.Banco;

var context = new Context();
var artistaDAL = new DAL<Artista>(context);


void ExibirMenu()
{
    Console.WriteLine(@"
    1 - Adicionar Artista
    2 - Alterar Artista
    3 - Listar Artista
    4 - Deletar Artista
    5 - Adicionar Música
    6 - Listar Músicas");

    Console.Write("\nEntre com a opção: ");
    string option = Console.ReadLine()!;

    switch (option)
    {
        case "1":
            AdicionarArtista();
            break;
        case "2":
            AlterarArtista();
            break;
        case "3":
            ListarArtista();
            break;
        case "4":
            DeletarArtista();
            break;
            case "5":
            AdicionarMusica();
            break;
            case "6":
            ListarMusica();
            break;
        default:
            break;
    }
}

void ListarMusica()
{
    Console.Write("Artista: ");
    string artistaName = Console.ReadLine()!;


    var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(artistaName));
    artistaRecuperado.ExibirDiscografia();

}




void AdicionarMusica()
{
    Console.Write("Artista: ");
    string artistaName = Console.ReadLine()!;

    var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(artistaName));

    Console.Write("Música: ");
    string tituloDaMusica = Console.ReadLine()!;

    Console.Write("Ano Música: ");
    string anoLancamento = Console.ReadLine()!;

    artistaRecuperado.AdicionarMusica(new Musica(tituloDaMusica) { AnoLancamento = Convert.ToInt32(anoLancamento) });

    Console.WriteLine($"A música {tituloDaMusica} de {artistaName} foi registrada com sucesso!");

    artistaDAL.Atualizar(artistaRecuperado);

}

void DeletarArtista()
{
    Console.Write("Artista: ");
    string artistaName = Console.ReadLine();

    var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(artistaName));

    artistaDAL.Deletar(artistaRecuperado);


    Console.WriteLine("Remoção realizada . . .\n\n\n");
    Console.ReadLine();
    ExibirMenu();
}



void ListarArtista()
{
    foreach (Artista a in artistaDAL.Listar())
    {
        Console.WriteLine($"Artista: {a}");
    }

    
    Console.ReadLine();
    ExibirMenu();
}





void AlterarArtista()
{
    Console.Write("Artista: ");
    string artistaName = Console.ReadLine();

    Console.Write("Novo Artista: ");
    string novoNome = Console.ReadLine();

    Console.Write("\nBIO: ");
    string bio = Console.ReadLine();

    var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(artistaName));
    artistaRecuperado.Nome = novoNome;
    artistaRecuperado.Bio = bio;

    artistaDAL.Atualizar(artistaRecuperado);

    Console.WriteLine("Alteração realizada . . .\n\n\n");
    Console.ReadLine();
    ExibirMenu();
}




void AdicionarArtista()
{
    Console.Write("Artista: ");
    string artistaName = Console.ReadLine();

    Console.Write("\nBIO: ");
    string bio = Console.ReadLine();

    Artista artista = new Artista(artistaName, bio);
    artistaDAL.Adicionar(artista);
    Console.WriteLine("Artista Cadastrado . . .\n\n\n");


    Console.ReadLine();
    ExibirMenu();

}



ExibirMenu();

