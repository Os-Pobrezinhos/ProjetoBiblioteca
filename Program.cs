namespace ProjetoBiblioteca;

class Program
{
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
            Console.WriteLine("[ 2 ] - Administrar Livros;");
            Console.Write("\nSelecione a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        MenuLeitor menuLeitor = new MenuLeitor();
                        menuLeitor.exibir();
                        break;
                    case 2:
                        MenuLivro menuLivro = new MenuLivro();
                        menuLivro.exibir();
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