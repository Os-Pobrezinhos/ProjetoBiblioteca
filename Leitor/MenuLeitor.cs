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

    private Leitor? BuscarLeitorPorCPF(List<Leitor> leitores)
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
                Console.WriteLine(leitor.ExibirLeitores());
                foreach (var livro in leitor.ListarLivros())
                {
                    Console.WriteLine("  " + livro);
                }
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
            Console.WriteLine(leitor.ExibirLeitores());
            foreach (var livro in leitor.ListarLivros())
            {
                Console.WriteLine("  " + livro);
            }
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
        try
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Digite o nome do leitor: ");
            string nome = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Digite o email do leitor: ");
            string email = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Digite a idade do leitor: ");
            string idadeStr = Console.ReadLine() ?? "";
            if (!int.TryParse(idadeStr, out int idade))
                throw new ArgumentException("Idade inválida!");

            var novoLeitor = new Leitor(cpf, nome, email, idade);
            leitores.Add(novoLeitor);

            Console.WriteLine("Leitor cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar leitor: {ex.Message}");
        }

        Console.ReadKey();
    }

    private void EditarLeitor(List<Leitor> leitores)
    {
        var leitor = BuscarLeitorPorCPF(leitores);

        if (leitor != null)
        {
            try
            {
                Console.Write("Digite o novo nome do leitor: ");
                string novoNome = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(novoNome))
                    leitor.Nome = novoNome;

                Console.Write("Digite o novo email do leitor: ");
                string novoEmail = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(novoEmail))
                    leitor.Email = novoEmail;

                Console.WriteLine("Leitor editado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao editar leitor: {ex.Message}");
            }
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
