namespace ProjetoBiblioteca;

public class MenuLeitor
{
    private List<Leitor> leitores = new List<Leitor>();
    private List<Livro> livros = new List<Livro>();

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
                        ListarLeitores();
                        break;
                    case 2:
                        PesquisarLeitorPorCPF();
                        break;
                    case 3:
                        RegistrarLeitor();
                        break;
                    case 4:
                        EditarLeitor();
                        break;
                    case 5:
                        RemoverLeitor();
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

    private void ListarLeitores()
    {
        if (leitores.Count > 0)
        {
            foreach (var leitor in leitores)
            {
                leitor.ExibirInformacoes();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Nenhum leitor cadastrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void PesquisarLeitorPorCPF()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine()?.Trim() ?? "";

        var leitor = leitores.Find(l => l.CPF == cpf);
        
        if (leitor != null)
        {
            leitor.ExibirInformacoes();
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void RegistrarLeitor()
    {
        string cpf;
        bool cpfValido;
        do
        {
            Console.Write("Digite o CPF do leitor: ");
            cpf = Console.ReadLine()?.Trim() ?? "";
            cpfValido = !string.IsNullOrWhiteSpace(cpf) && !leitores.Exists(l => l.CPF == cpf);
            
            if (!cpfValido)
            {
                if (string.IsNullOrWhiteSpace(cpf)) Console.WriteLine("CPF não pode ser vazio!");
                else Console.WriteLine("CPF já cadastrado!");
            }
        } while (!cpfValido);

        string nome;
        do
        {
            Console.Write("Digite o nome do leitor: ");
            nome = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(nome)) Console.WriteLine("Nome não pode ser vazio!");
        } while (string.IsNullOrWhiteSpace(nome));

        string email;
        do
        {
            Console.Write("Digite o email do leitor: ");
            email = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(email)) Console.WriteLine("Email não pode ser vazio!");
        } while (string.IsNullOrWhiteSpace(email));

        leitores.Add(new Leitor(cpf, nome, email));
        Console.WriteLine("Leitor cadastrado com sucesso!");
        Console.ReadKey();
    }

    private void EditarLeitor()
    {
        Console.Write("Digite o CPF do leitor que deseja editar: ");
        string cpf = Console.ReadLine()?.Trim() ?? "";
        
        var leitor = leitores.Find(l => l.CPF == cpf);
        
        if (leitor != null)
        {
            Console.Write("Digite o novo nome do leitor: ");
            string novoNome = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(novoNome)) leitor.Nome = novoNome;

            Console.Write("Digite o novo email do leitor: ");
            string novoEmail = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(novoEmail)) leitor.Email = novoEmail;

            Console.WriteLine("Leitor editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
        Console.ReadKey();
    }

    private void RemoverLeitor()
    {
        Console.Write("Digite o CPF do leitor que deseja remover: ");
        string cpf = Console.ReadLine()?.Trim() ?? "";
        
        var leitor = leitores.Find(l => l.CPF == cpf);
        if (leitor != null)
        {
            leitores.Remove(leitor);
            Console.WriteLine("Leitor removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
        Console.ReadKey();
    }
}