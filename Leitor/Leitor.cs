
namespace ProjetoBiblioteca
{
    public class Leitor
    {
        private static readonly HashSet<string> cpfsRegistrados = new HashSet<string>();

        private string _cpf = "";
        private string _nome = "";
        private string _email = "";

        private int _idade;

        public string CPF
        {
            get => _cpf;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CPF não pode ser nulo ou vazio.");

                value = value.Trim();

                if (cpfsRegistrados.Contains(value))
                    throw new ArgumentException("CPF já cadastrado.");

                if (_cpf != null)
                    cpfsRegistrados.Remove(_cpf); 

                _cpf = value;
                cpfsRegistrados.Add(value);
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser nulo ou vazio.");
                _nome = value.Trim();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email não pode ser nulo ou vazio.");
                _email = value.Trim();
            }
        }

        public int Idade
        {
            get => _idade;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Idade não pode ser negativa.");
                _idade = value;
            }
        }

        public List<Livro> Livros { get; private set; }

        public Leitor(string cpf, string nome, string email, int idade)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
            Idade = idade;
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            if (livro == null)
                throw new ArgumentException("Livro não pode ser nulo.");
            Livros.Add(livro);
        }

        public void RemoverLivro(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.");

            var livro = BuscarLivroPorTitulo(titulo);
            if (livro == null)
                throw new ArgumentException("Livro não encontrado.");

            Livros.Remove(livro);
        }

        public void EditarLivro(string tituloLivro, Livro novoLivro)
        {
            if (string.IsNullOrWhiteSpace(tituloLivro))
                throw new ArgumentException("Título do livro não pode ser vazio.");

            if (novoLivro == null)
                throw new ArgumentException("Novo livro não pode ser nulo.");

            var livroAntigo = BuscarLivroPorTitulo(tituloLivro);
            if (livroAntigo == null)
                throw new ArgumentException("Livro original não encontrado.");

            int index = Livros.IndexOf(livroAntigo);
            Livros[index] = novoLivro;
        }

        public Livro? BuscarLivroPorTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.");

            return Livros
                .FirstOrDefault(l => l.Titulo != null &&
                                     l.Titulo.Trim().ToLower().Contains(titulo.Trim().ToLower()));
        }


        public string ExibirLeitores()
        {
            return $"CPF: {CPF}\nNome: {Nome}\nEmail: {Email}\nIdade: {Idade}";
        }

        public List<string> ListarLivros()
        {
            if (Livros.Count == 0)
                return new List<string> { "Nenhum livro cadastrado para este leitor." };

            return Livros.Select((livro, index) =>
                $"{index + 1}. {livro.Titulo} ({livro.Escritor}, {livro.AnoPublicacao})"
            ).ToList();
        }
    }
}
