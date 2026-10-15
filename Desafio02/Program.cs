using Desafio02.Services;
using Desafio02.Model;

namespace Desafio02
{
    internal class Program
    {
        static void Main(string[] args) {
            List<Produto> json = new JsonReader().GetEstoque();
            Dictionary<int, Produto> deposito = new Dictionary<int, Produto>();

            foreach (var item in json) { 
                deposito.Add(item.CodigoProduto, item);
            }

            Deposito modelosDeposito = new Deposito(deposito);
            ServicoDeposito servicoDeposito = new ServicoDeposito(modelosDeposito);

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
                        MenuEntrada(servicoDeposito);
                    }
                    else if (opcaoLancamento == "2") {
                        MenuSaida(servicoDeposito);
                    }
                }

            } while (opcaoMenu != "2");
        }

        private static void MenuEntrada(ServicoDeposito servicoDeposito) {
            Console.Clear();
            Console.WriteLine("Informe o código identificador do produto: ");

            int codProduto;
            int quantidadeEntrada;
            bool verificaProduto = false;
            do {
                if (int.TryParse(Console.ReadLine(), out codProduto)) {
                    verificaProduto = servicoDeposito.VerificaProduto(codProduto);
                    if (verificaProduto) {

                        do {
                            Console.WriteLine("Informe a quantidade: ");
                            if (int.TryParse(Console.ReadLine(), out quantidadeEntrada)) {
                                servicoDeposito.AddProdutoEstoque(codProduto, quantidadeEntrada);
                            }else {
                                Console.WriteLine("Informe apenas a quantidade sem utilização de letras ou simbolos:");
                            }
                        } while (quantidadeEntrada <= 0);

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();


                    }else {
                        Console.WriteLine("Produto informado inexistente, informe um código válido:");
                    }

                }else {
                    Console.WriteLine("Informe o código sem utilização de letras ou simbolos:");
                }
            } while (!verificaProduto);
        }
        private static void MenuSaida(ServicoDeposito servicoDeposito) {
            int codProduto;
            int quantidadeEntrada;
            bool verificaProduto = false;
            bool verificaProdutoRemovido = true;
            Console.Clear();
            Console.WriteLine("Informe o código identificador do produto: ");
            do {
                if (int.TryParse(Console.ReadLine(), out codProduto)) {
                    verificaProduto = servicoDeposito.VerificaProduto(codProduto);
                    if (verificaProduto) {

                        do {
                            Console.WriteLine("Informe a quantidade a ser retirada: ");
                            if (int.TryParse(Console.ReadLine(), out quantidadeEntrada)) {
                                if(servicoDeposito.RemoveProdutoEstoque(codProduto, quantidadeEntrada)) {
                                    verificaProdutoRemovido = false;
                                }
                            }
                            else {
                                Console.WriteLine("Informe apenas a quantidade sem utilização de letras ou simbolos:");
                            }

                        } while (quantidadeEntrada <= 0 || verificaProdutoRemovido);

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();

                    }
                    else {
                        Console.WriteLine("Produto informado inexistente, informe o código do produto:");
                    }
                }
                else {
                    Console.WriteLine("Informe o código sem utilização de letras ou simbolos:");
                }

            } while (!verificaProduto);
        }

    }
}
