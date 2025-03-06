using ProjetoBiblioteca.MenuLivroLeitor;

namespace ProjetoBiblioteca;

class Program
{
    static List<Leitor> leitores = new List<Leitor>();

    public static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=       Sistema de Biblioteca 2000      =");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            Console.WriteLine("[ 0 ] - Sair;");
            Console.WriteLine("[ 1 ] - Administrar Leitores;");
            Console.WriteLine("[ 2 ] - Administrar Livros de Leitor;");
            Console.Write("\nSelecione a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        new MenuLeitor().exibir(leitores);
                        break;
                    case 2:
                        new MenuLivroLeitor.MenuLivroLeitor().exibir(leitores);
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o sistema;");
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
}