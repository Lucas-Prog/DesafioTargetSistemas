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
                    Console.WriteLine(vendaService.ToString(venda));
                }
                catch (ArgumentException ex) { 
                    Console.WriteLine(ex.Message); 
                }
            }
        }
    }
}
