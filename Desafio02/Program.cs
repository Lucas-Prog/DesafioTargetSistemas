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
            servicoDeposito.GetProdutos();
            servicoDeposito.RemoveProdutoEstoque(101, 50);

        }
    }
}
