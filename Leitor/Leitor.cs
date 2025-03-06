namespace ProjetoBiblioteca
{
    public class Leitor
    {
        public string CPF { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Livro> Livros { get; private set; }

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

        public void RemoverLivro(string titulo)
        {
            var livro = BuscarLivroPorTitulo(titulo);

            if (livro != null)
            {
                Livros.Remove(livro);
            }
        }

        public void EditarLivro(string tituloLivro, Livro novoLivro)
        {
            var livro = BuscarLivroPorTitulo(tituloLivro);

            Livros[Livros.IndexOf(livro)] = novoLivro;
        }

        public Livro BuscarLivroPorTitulo(string titulo)
        {
            return Livros.Where(l => l.Titulo.ToLower().Contains(titulo.ToLower())).FirstOrDefault();
        }

        public void ExibirLeitores()
        {
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email}");
        }

        public void ListarLivros()
        {
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
}