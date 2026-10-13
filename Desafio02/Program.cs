using Desafio02.Services;
using Desafio02.Model;

namespace Desafio02
{
    internal class Program
    {
        static void Main(string[] args) {
            List<Produto> json = new JsonReader().GetEstoque();
            Dictionary<int, Produto> ddeposito = new Dictionary<int, Produto>();

            foreach (var item in json) { 
                ddeposito.Add(item.CodigoProduto, item);
            }

            Deposito deposito = new Deposito(ddeposito);
            ServicoDeposito servicoDeposito = new ServicoDeposito(deposito);

            string opcaoMenu = "";
            do {
                Console.Clear();
                Console.WriteLine("Sistema Estoque Desafio 02 Target Sistemas");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Lançar movimentação");
                Console.WriteLine("2 - Sair");
                opcaoMenu = Console.ReadLine();

                if (opcaoMenu == "1") {
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Lançar entrada");
                    Console.WriteLine("2 - Lançar saida");
                    Console.WriteLine("0 - Pressione qualquer tecla para voltar ao menu...");
                    string opcaoLancamento = Console.ReadLine();

                    if (opcaoLancamento == "1") {
                        Console.Clear();
                        Console.WriteLine("Informe o código identificador do produto: ");
                        bool verificaProduto = false;
                        do {
                            string codProduto = Console.ReadLine();
                            verificaProduto = servicoDeposito.VerificaProduto(int.Parse(codProduto));
                            if (verificaProduto) {
                                Console.WriteLine("Informe a quantidade: ");
                                int quantidadeEntrada = int.Parse(Console.ReadLine());
                                servicoDeposito.AddProdutoEstoque(int.Parse(codProduto), quantidadeEntrada);
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey();
                            }
                            else {
                                Console.WriteLine("Produto informado inexistente");
                            }
                        } while (!verificaProduto);
                    }
                    else if (opcaoLancamento == "2") {
                        Console.Clear();
                        Console.WriteLine("Informe o código identificador do produto: ");
                        bool verificaProduto = false;
                        do {
                            string codProduto = Console.ReadLine();
                            verificaProduto = servicoDeposito.VerificaProduto(int.Parse(codProduto));
                            if (verificaProduto) {
                                Console.WriteLine("Informe a quantidade: ");
                                int quantidadeEntrada = int.Parse(Console.ReadLine());
                                servicoDeposito.RemoveProdutoEstoque(int.Parse(codProduto), quantidadeEntrada);
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey();
                            }
                            else {
                                Console.WriteLine("Produto informado inexistente");
                            }
                        } while (!verificaProduto);
                    }
                    else {

                    }
                }

            } while (opcaoMenu != "2");
        }
    }
}
