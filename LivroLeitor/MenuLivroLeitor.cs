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

        private Leitor? BuscarLeitorPorCPF(List<Leitor> leitores, string tipo = "")
        {
            Console.Write($"Digite o CPF do leitor {tipo}: ");
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
                        Console.WriteLine("  " + livro);
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
                foreach (var livro in leitor.ListarLivros())
                    Console.WriteLine(livro);
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
                try
                {
                    Console.Write("Digite o ISBN do livro: ");
                    string isbn = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o título do livro: ");
                    string titulo = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o subtítulo do livro: ");
                    string subtitulo = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o escritor: ");
                    string escritor = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite a editora: ");
                    string editora = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o gênero: ");
                    string genero = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o tipo da capa: ");
                    string tipoCapa = Console.ReadLine()?.Trim() ?? "";

                    Console.Write("Digite o ano de publicação: ");
                    if (!int.TryParse(Console.ReadLine(), out int ano))
                        throw new ArgumentException("Ano inválido!");

                    Console.Write("Digite o número de páginas: ");
                    if (!int.TryParse(Console.ReadLine(), out int paginas))
                        throw new ArgumentException("Número de páginas inválido!");

                    var livro = new Livro(isbn, titulo, subtitulo, escritor, editora, genero, ano, tipoCapa, paginas);
                    leitor.AdicionarLivro(livro);

                    Console.WriteLine("Livro cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cadastrar livro: {ex.Message}");
                }
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
                try
                {
                    leitor.RemoverLivro(titulo);
                    Console.WriteLine("Livro removido com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
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

            try
            {
                var livro = doador.BuscarLivroPorTitulo(titulo);
                if (livro == null)
                    throw new ArgumentException("Livro não encontrado na posse do doador.");

                doador.RemoverLivro(titulo);
                recebedor.AdicionarLivro(livro);

                Console.WriteLine($"O livro '{livro.Titulo}' foi doado de {doador.Nome} para {recebedor.Nome}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao doar livro: {ex.Message}");
            }
            Console.ReadKey();
        }

        private void EditarLivroDeLeitor(List<Leitor> leitores)
        {
            Console.WriteLine("(Funcionalidade não implementada pois o ISBN é imutável e criar novo objeto pode confundir a lógica. Recomenda-se remover e cadastrar novamente caso deseje editar.)");
            Console.ReadKey();
        }
    }
}
