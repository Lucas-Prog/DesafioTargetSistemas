using Desafio03.Services;
using System.Globalization;

namespace Desafio03
{
    internal class Program
    {
        static void Main(string[] args) {
            JurosService juros = new JurosService();

            Console.WriteLine("Informe o valor: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe a data de Vencimento(dd/MM/yyyy): ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(juros.CalculaJuros(data, valor));
        }
    }
}
