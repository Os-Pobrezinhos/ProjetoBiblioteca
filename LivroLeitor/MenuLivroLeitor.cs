namespace ProjetoBiblioteca.MenuLivroLeitor
{
    public class MenuLivroLeitor
    {
        public void exibir(List<Leitor> leitores)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=       Sistema de Biblioteca 2000      =");
                Console.WriteLine("=      Administrar Livro de Leitor.     =");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

                Console.WriteLine("[ 0 ] - Voltar;");
                Console.WriteLine("[ 1 ] - Exibir Leitores com Livros cadastrados;");
                Console.WriteLine("[ 2 ] - Pesquisar livros de um leitor por CPF;");
                Console.WriteLine("[ 3 ] - Registrar novo livro para um leitor;");
                Console.WriteLine("[ 4 ] - Editar livro de um leitor;");
                Console.WriteLine("[ 5 ] - Remover livro de um leitor;");
                Console.WriteLine("[ 6 ] - Doar livro;");
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
                            PesquisarLivrosPorCPF(leitores);
                            break;
                        case 3:
                            RegistrarLivroParaLeitor(leitores);
                            break;
                        case 4:
                            EditarLivroDeLeitor(leitores);
                            break;
                        case 5:
                            RemoverLivroDeLeitor(leitores);
                            break;
                        case 6:
                            DoarLivro(leitores);
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
        private Leitor BuscarLeitorPorCPF(List<Leitor> leitores, string tipo)
        {
            Console.Write($"Digite o CPF do leitor {tipo}: ");
            string cpf = Console.ReadLine()?.Trim() ?? "";

            return leitores.Find(l => l.CPF == cpf);
        }
        
        private Leitor BuscarLeitorPorCPF(List<Leitor> leitores)
        {
            Console.Write($"Digite o CPF do leitor: ");
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
                    leitor.ListarLivros();
                }
            }
            else
            {
                Console.WriteLine("Nenhum leitor cadastrado.");
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void PesquisarLivrosPorCPF(List<Leitor> leitores)
        {
            var leitor = BuscarLeitorPorCPF(leitores);

            if (leitor != null)
            {
                if (leitor.Livros.Count > 0)
                {
                    foreach (var livro in leitor.Livros)
                    {
                        leitor.ListarLivros();
                    }
                }
                else
                {
                    Console.WriteLine("O leitor não possui livros cadastrados.");
                }
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void RegistrarLivroParaLeitor(List<Leitor> leitores)
        {
            var leitor = BuscarLeitorPorCPF(leitores);

            if (leitor != null)
            {
                string titulo;
                do
                {
                    Console.Write("Digite o título do livro: ");
                    titulo = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(titulo)) Console.WriteLine("Título não pode ser vazio!");
                } while (string.IsNullOrWhiteSpace(titulo));

                string autor;
                do
                {
                    Console.Write("Digite o autor do livro: ");
                    autor = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(autor)) Console.WriteLine("Autor não pode ser vazio!");
                } while (string.IsNullOrWhiteSpace(autor));

                int anoPublicacao;
                bool anoValido;
                do
                {
                    Console.Write("Digite o ano de publicação do livro: ");
                    string input = Console.ReadLine()?.Trim() ?? "";
                    anoValido = int.TryParse(input, out anoPublicacao) && anoPublicacao > 0;
                    if (!anoValido) Console.WriteLine("Ano inválido! Deve ser um número positivo.");
                } while (!anoValido);

                leitor.AdicionarLivro(new Livro(titulo, autor, anoPublicacao));
                Console.WriteLine("Livro cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
            Console.ReadKey();
        }

        private void EditarLivroDeLeitor(List<Leitor> leitores)
        {
            var leitor = BuscarLeitorPorCPF(leitores);

            if (leitor != null)
            {
                Console.Write("Digite o título do livro que deseja editar: ");
                string titulo = Console.ReadLine()?.Trim() ?? "";
                var livro = leitor.BuscarLivroPorTitulo(titulo);

                if (livro != null)
                {
                    Console.Write($"Novo título (atual: {livro.Titulo}): ");
                    string novoTitulo = Console.ReadLine()?.Trim() ?? "";
                    if (!string.IsNullOrWhiteSpace(novoTitulo)) livro.Titulo = novoTitulo;

                    Console.Write($"Novo autor (atual: {livro.Autor}): ");
                    string novoAutor = Console.ReadLine()?.Trim() ?? "";
                    if (!string.IsNullOrWhiteSpace(novoAutor)) livro.Autor = novoAutor;

                    int novoAno;
                    bool anoValido;
                    do
                    {
                        Console.Write($"Novo ano (atual: {livro.AnoPublicacao}): ");
                        string input = Console.ReadLine()?.Trim() ?? "";
                        anoValido = int.TryParse(input, out novoAno) && novoAno > 0;
                        if (!string.IsNullOrWhiteSpace(input) && !anoValido)
                            Console.WriteLine("Ano inválido! Mantendo o valor atual.");
                        else if (string.IsNullOrWhiteSpace(input))
                            anoValido = true;
                    } while (!anoValido);

                    if (novoAno > 0) livro.AnoPublicacao = novoAno;

                    leitor.EditarLivro(livro.Titulo, 
                        new Livro(
                            novoTitulo, 
                            novoAutor, 
                            novoAno
                            ));
                    Console.WriteLine("Livro editado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
            Console.ReadKey();
        }

        private void RemoverLivroDeLeitor(List<Leitor> leitores)
        {
            var leitor = BuscarLeitorPorCPF(leitores);

            if (leitor != null)
            {
                Console.Write("Digite o título do livro que deseja remover: ");
                string titulo = Console.ReadLine()?.Trim() ?? "";
                var livro = leitor.BuscarLivroPorTitulo(titulo);

                if (livro != null)
                {
                    leitor.RemoverLivro(livro.Titulo);
                    Console.WriteLine("Livro removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
            Console.ReadKey();
        }

        public void DoarLivro(List<Leitor> leitores)
        {
            var doador = BuscarLeitorPorCPF(leitores, "doador");
            if (doador == null)
            {
                Console.WriteLine("Leitor doador não encontrado.");
                return;
            }

            var recebedor = BuscarLeitorPorCPF(leitores, "recebedor");
            if (recebedor == null)
            {
                Console.WriteLine("Leitor recebedor não encontrado.");
                return;
            }

            Console.Write("Digite o título do livro que deseja doar: ");
            string titulo = Console.ReadLine()?.Trim() ?? "";

            var livro = doador.BuscarLivroPorTitulo(titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado na posse do doador.");
                return;
            }

            doador.RemoverLivro(titulo);
            recebedor.AdicionarLivro(livro);

            Console.WriteLine($"O livro '{livro.Titulo}' foi doado de {doador.Nome} para {recebedor.Nome}.");
        }
    }
}