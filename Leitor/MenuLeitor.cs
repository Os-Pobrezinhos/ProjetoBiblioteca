namespace ProjetoBiblioteca;

public class MenuLeitor
{
    public void exibir(List<Leitor> leitores)
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
                        ListarLeitores(leitores);
                        break;
                    case 2:
                        PesquisarLeitorPorCPF(leitores);
                        break;
                    case 3:
                        RegistrarLeitor(leitores);
                        break;
                    case 4:
                        EditarLeitor(leitores);
                        break;
                    case 5:
                        RemoverLeitor(leitores);
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
    private Leitor BuscarLeitorPorCPF(List<Leitor> leitores)
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpf = Console.ReadLine()?.Trim() ?? "";

        return leitores.Find(l => l.CPF == cpf);
    }

    private void ListarLeitores(List<Leitor> leitores)
    {
        if (leitores.Count > 0)
        {
            foreach (var leitor in leitores)
            {
                leitor.ExibirLeitores();
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

    private void PesquisarLeitorPorCPF(List<Leitor> leitores)
    {
        var leitor = BuscarLeitorPorCPF(leitores);

        if (leitor != null)
        {
            leitor.ExibirLeitores();
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void RegistrarLeitor(List<Leitor> leitores)
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

    private void EditarLeitor(List<Leitor> leitores)
    {
        var leitor = BuscarLeitorPorCPF(leitores);

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

    private void RemoverLeitor(List<Leitor> leitores)
    {
        var leitor = BuscarLeitorPorCPF(leitores);

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