namespace ProjetoBiblioteca;

public class Livro
{
    //public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    protected List<Livro> livros = [];

    public Livro(string titulo, string autor, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
    }
    
    //protected int contadorId = 1;

    public void AdicionarLivro(Livro livro)
    {
        //livro.Id = contadorId++;
        livros.Add(livro);
    }

    public void EditarLivro(int indice, string novoTitulo, string novoAutor, int novoAno)
    {
        if (indice >= 0 && indice < livros.Count)
        {
            if (!string.IsNullOrWhiteSpace(novoTitulo))
                livros[indice].Titulo = novoTitulo;

            if (!string.IsNullOrWhiteSpace(novoAutor))
                livros[indice].Autor = novoAutor;

            if (novoAno > 0)
                livros[indice].AnoPublicacao = novoAno;
        }
    }

    public void RemoverLivro(int indice)
    {
        if (indice >= 0 && indice < livros.Count)
        {
            livros.RemoveAt(indice);
        }
    }
}
