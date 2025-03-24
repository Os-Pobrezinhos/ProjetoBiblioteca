
namespace ProjetoBiblioteca
{
    public class Livro
    {
        private string _titulo = "";
        private string _subtitulo = "";
        private string _escritor = "";
        private string _editora = "";
        private string _genero = "";
        private string _tipoCapa = "";
        private int _anoPublicacao;
        private int _numeroDePaginas;

        public string Isbn { get; init; }

        public string Titulo
        {
            get => _titulo;
            set => _titulo = ValidarTexto(value, "Título");
        }

        public string Subtitulo
        {
            get => _subtitulo;
            set => _subtitulo = ValidarTexto(value, "Subtítulo");
        }

        public string Escritor
        {
            get => _escritor;
            set => _escritor = ValidarTexto(value, "Escritor");
        }

        public string Editora
        {
            get => _editora;
            set => _editora = ValidarTexto(value, "Editora");
        }

        public string Genero
        {
            get => _genero;
            set => _genero = ValidarTexto(value, "Gênero");
        }

        public string TipoCapa
        {
            get => _tipoCapa;
            set => _tipoCapa = ValidarTexto(value, "Tipo da Capa");
        }

        public int AnoPublicacao
        {
            get => _anoPublicacao;
            set
            {
                int anoAtual = DateTime.Now.Year;
                if (value < 1970 || value > anoAtual)
                    throw new ArgumentException($"Ano de publicação deve estar entre 1970 e {anoAtual}.");
                _anoPublicacao = value;
            }
        }

        public int NumeroDePaginas
        {
            get => _numeroDePaginas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Número de páginas deve ser maior que zero.");
                _numeroDePaginas = value;
            }
        }

        public Livro(
            string isbn,
            string titulo,
            string subtitulo,
            string escritor,
            string editora,
            string genero,
            int anoPublicacao,
            string tipoCapa,
            int numeroDePaginas)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN não pode ser vazio.");

            Isbn = isbn.Trim();
            Titulo = titulo;
            Subtitulo = subtitulo;
            Escritor = escritor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            TipoCapa = tipoCapa;
            NumeroDePaginas = numeroDePaginas;
        }

        private string ValidarTexto(string? valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{campo} não pode ser nulo ou vazio.");
            return valor.Trim();
        }
    }
}
