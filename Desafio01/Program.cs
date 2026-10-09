using Desafio01.Models;
using Desafio01.Services;

namespace Desafio01
{
    internal class Program
    {
        static void Main(string[] args) {
            JsonReader jsonReader = new JsonReader();
            VendaService vendaService = new VendaService();
            List<Venda> vendas = jsonReader.GetVendas();


            foreach (Venda venda in vendas) {
                try {
                    Console.WriteLine(vendaService.GetComissao(venda.Valor).ToString("F2"));
                }
                catch (ArgumentException ex) { 
                    Console.WriteLine(ex.Message); 
                }
            }
        }
    }
}
