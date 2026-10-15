using Desafio01.Models;
using Desafio01.Services;
using System.Text.Json.Nodes;

namespace Desafio01
{
    internal class Program
    {
        static void Main(string[] args) {
            JsonReader jsonReader = new JsonReader();
            VendedorService vendedorService = new VendedorService();
            List<Venda> vendas = new List<Venda>();
            List<Vendedor> vendedores = new List<Vendedor>();
            JsonArray jsonArray = jsonReader.GetJson();

            string nomeVendedor;
            double valorVenda = 0.0;
            int contadorVendedores = 0;

            if (jsonArray != null) {
                foreach (JsonNode item in jsonArray) {

                    if (item["vendedor"] != null && item["valor"] != null) {
                        nomeVendedor = item["vendedor"].GetValue<string>();
                        valorVenda = item["valor"].GetValue<double>();

                        if (!String.IsNullOrWhiteSpace(nomeVendedor) && valorVenda >= 0.0) {
                            vendas.Add(new Venda(nomeVendedor, valorVenda));

                            if (!vendedores.Any(item => item.Nome == nomeVendedor)) {
                                contadorVendedores++;
                                vendedores.Add(new Vendedor(contadorVendedores, nomeVendedor));
                            }
                        }
                    }
                }
                foreach (Vendedor item in vendedores) {
                    List<Venda> vendasSeparadas = vendas.FindAll(x => x.Vendedor == item.Nome);

                    Console.WriteLine($"Vendedor {item.Nome}, Comissão: {vendedorService.CalculaComissao(vendasSeparadas)}");
                }
            }
        }
    }
}
