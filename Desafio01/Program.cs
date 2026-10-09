using Desafio01.Models;
using Desafio01.Services;

namespace Desafio01
{
    internal class Program
    {
        static void Main(string[] args) {
            List<Venda> vendas = new List<Venda>();
            JsonReader jsonReader = new JsonReader();


            vendas = jsonReader.GetVendas();


        }
    }
}
