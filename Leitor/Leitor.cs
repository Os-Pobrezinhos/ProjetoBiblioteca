namespace ProjetoBiblioteca;

public class Leitor
{
    public string CPF { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Livro> Livros { get; private set; }
    protected List<Leitor> Leitores = [];

    public Leitor(string cpf, string nome, string email)
    {
        CPF = cpf;
        Nome = nome;
        Email = email;
        Livros = new List<Livro>();
    }

    public void AdicionarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void RemoverLivro(int indice)
    {
        if (indice >= 0 && indice < Livros.Count)
        {
            Livros.RemoveAt(indice);
        }
    }

    public void EditarLivro(int indice, string novoTitulo, string novoAutor, int novoAno)
    {
        if (indice >= 0 && indice < Livros.Count)
        {
            if (!string.IsNullOrWhiteSpace(novoTitulo))
                Livros[indice].Titulo = novoTitulo;

            if (!string.IsNullOrWhiteSpace(novoAutor))
                Livros[indice].Autor = novoAutor;

            if (novoAno > 0)
                Livros[indice].AnoPublicacao = novoAno;
        }
    }

    public List<Livro> BuscarLivroPorTitulo(string titulo)
    {
        return Livros.Where(l => l.Titulo.ToLower().Contains(titulo.ToLower())).ToList();
    }
    public void ExibirInformacoes()
    {
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Email: {Email}");

        if (Livros.Count > 0)
        {
            Console.WriteLine("Livros:");
            for (int i = 0; i < Livros.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Livros[i].Titulo} ({Livros[i].Autor}, {Livros[i].AnoPublicacao})");
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro cadastrado para este leitor.");
        }
    }

}