namespace ProjetoBiblioteca
{
    public class LivroLeitor
    {
        public Livro Livro { get; set; }
        public Leitor Leitor { get; set; }

        public LivroLeitor(Livro livro, Leitor leitor)
        {
            Livro = livro; 
            Leitor = leitor; 
        }
    }
}