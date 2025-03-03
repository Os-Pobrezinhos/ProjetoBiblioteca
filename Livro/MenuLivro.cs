namespace ProjetoBiblioteca;

public class MenuLivro
{
    private List<Livro> livros = new List<Livro>();

    public void exibir()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=       Sistema de Biblioteca 2000      =");
            Console.WriteLine("=           Administrar Livros.         =");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            Console.WriteLine("[ 0 ] - Voltar;");
            Console.WriteLine("[ 1 ] - Exibir livros disponíveis;");
            Console.WriteLine("[ 2 ] - Pesquisar livro pelo nome;");
            Console.WriteLine("[ 3 ] - Registrar novo livro;");
            Console.WriteLine("[ 4 ] - Editar livro;");
            Console.WriteLine("[ 5 ] - Remover livro;");
            Console.Write("\nSelecione a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        ListarLivros();
                        break;
                    case 2:
                        PesquisarLivroPorTitulo();
                        break;
                    case 3:
                        RegistrarLivro();
                        break;
                    case 4:
                        EditarLivro();
                        break;
                    case 5:
                        RemoverLivro();
                        break;
                    case 0:
                        Console.WriteLine("Voltando ao menu principal;");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }
    }

    private void ListarLivros()
    {
        if (livros.Count > 0)
        {
            foreach (var livro in livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.AnoPublicacao}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void PesquisarLivroPorTitulo()
    {
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine()?.Trim() ?? "";
        var livro = livros.Find(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

        if (livro != null)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.AnoPublicacao}");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void RegistrarLivro()
    {
        string titulo;
        do
        {
            Console.Write("Digite o título do livro: ");
            titulo = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(titulo)) Console.WriteLine("Título não pode ser vazio!");
        } while (string.IsNullOrWhiteSpace(titulo));

        string autor;
        do
        {
            Console.Write("Digite o autor do livro: ");
            autor = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(autor)) Console.WriteLine("Autor não pode ser vazio!");
        } while (string.IsNullOrWhiteSpace(autor));

        int anoPublicacao;
        bool anoValido;
        do
        {
            Console.Write("Digite o ano de publicação do livro: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            anoValido = int.TryParse(input, out anoPublicacao) && anoPublicacao > 0;
            if (!anoValido) Console.WriteLine("Ano inválido! Deve ser um número positivo.");
        } while (!anoValido);

        livros.Add(new Livro(titulo, autor, anoPublicacao));
        Console.WriteLine("Livro cadastrado com sucesso!");
        Console.ReadKey();
    }

    private void EditarLivro()
    {
        Console.Write("Digite o título do livro que deseja editar: ");
        string titulo = Console.ReadLine()?.Trim() ?? "";
        var livro = livros.Find(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

        if (livro != null)
        {

            Console.Write($"Novo título (atual: {livro.Titulo}): ");
            string novoTitulo = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(novoTitulo)) livro.Titulo = novoTitulo;


            Console.Write($"Novo autor (atual: {livro.Autor}): ");
            string novoAutor = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(novoAutor)) livro.Autor = novoAutor;


            int novoAno;
            bool anoValido;
            do
            {
                Console.Write($"Novo ano (atual: {livro.AnoPublicacao}): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                anoValido = int.TryParse(input, out novoAno) && novoAno > 0;
                if (!string.IsNullOrWhiteSpace(input) && !anoValido)
                    Console.WriteLine("Ano inválido! Mantendo o valor atual.");
                else if (string.IsNullOrWhiteSpace(input))
                    anoValido = true;
            } while (!anoValido);

            if (novoAno > 0) livro.AnoPublicacao = novoAno;

            Console.WriteLine("Livro editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
        Console.ReadKey();
    }

    private void RemoverLivro()
    {
        Console.Write("Digite o título do livro que deseja remover: ");
        string titulo = Console.ReadLine()?.Trim() ?? "";
        var livro = livros.Find(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

        if (livro != null)
        {
            livros.Remove(livro);
            Console.WriteLine("Livro removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
        Console.ReadKey();
    }
}