namespace ProjetoBiblioteca;

public class MenuLeitor
{
    public void exibir()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=       Sistema de Biblioteca 2000      =");
            Console.WriteLine("=          Administrar Leitores.        =");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            Console.WriteLine("[ 0 ] - Voltar;");
            Console.WriteLine("[ 1 ] - Exibir Leitores cadastrados;");
            Console.WriteLine("[ 2 ] - Pesquisar leitor por CPF;");
            Console.WriteLine("[ 3 ] - Registrar novo leitor;");
            Console.WriteLine("[ 4 ] - Editar leitor;");
            Console.WriteLine("[ 5 ] - Remover leitor;");
            Console.Write("\nSelecione a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        //
                        break;
                    case 2:
                        //
                        break;
                    case 3:
                        //
                        break;
                    case 4:
                        //
                        break;
                    case 5:
                        //
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
}