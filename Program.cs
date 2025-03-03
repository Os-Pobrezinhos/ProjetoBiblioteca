namespace ProjetoBiblioteca;

class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while(running){
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("=       Sistema de Biblioteca 2000      =");   
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            Console.WriteLine("[ 0 ] - Sair;");
            Console.WriteLine("[ 1 ] - Cadastrar leitor;");
            Console.WriteLine("[ 2 ] - Listar leitores cadastrados;");
            Console.WriteLine("[ 3 ] - Buscar leitor;");
            Console.WriteLine("[ 4 ] - Editar leitor;");
            Console.WriteLine("[ 5 ] - Excluir leitor;");
            Console.WriteLine("[ 6 ] - Adicionar livro ao leitor;");
            Console.WriteLine("[ 7 ] - Editar livro do leitor;");
            Console.WriteLine("[ 8 ] - Remover livro do leitor;");
            Console.WriteLine("[ 9 ] - Doar livro para outro leitor;");
            Console.WriteLine("[ 10 ] - Pesquisar livro específico;");
            Console.Write("\nSelecione a opção desejada: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            //CadastrarLeitor();
                            break;
                        case 2:
                            // ListarTodosLeitores();
                            break;
                        case 3:
                            // BuscarLeitorPorCPF();
                            break;
                        case 4:
                            // EditarLeitor();
                            break;
                        case 5:
                            // ExcluirLeitor();
                            break;
                        case 6:
                            // AdicionarLivroAoLeitor();
                            break;
                        case 7:
                            // EditarLivroDoLeitor();
                            break;
                        case 8:
                            // RemoverLivroDoLeitor();
                            break;
                        case 9:
                            // DoarLivro();
                            break;
                        case 10:
                            // PesquisarLivro();
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