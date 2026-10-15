using Desafio03.Services;
using System.Globalization;

namespace Desafio03
{
    internal class Program
    {
        static void Main(string[] args) {
            JurosService juros = new JurosService();
            double valor;
            bool validaEntradaValor = false;
            bool validaEntradaData = false;
            DateTime data;


            Console.WriteLine("Informe o valor: ");
            do {
                validaEntradaValor = double.TryParse(Console.ReadLine(), out valor);
                if (double.IsNegative(valor)) {
                    validaEntradaValor = false;
                    Console.WriteLine("Valor negativo, informe um valor positivo:");
                }
                else {
                    if (validaEntradaValor) {

                        Console.WriteLine("Informe a data de Vencimento(dd/MM/yyyy): ");
                        do {
                            validaEntradaData = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
                            if (validaEntradaData) {
                                Console.WriteLine(juros.CalculaJuros(data, valor));
                            }
                            else {
                                Console.WriteLine("Informe uma data válida(dd/MM/yyyy): ");
                            }                       

                        } while (!validaEntradaData);

                    }
                    else {
                        Console.WriteLine("Informe um valor válido: ");
                    }
                }


            } while (!validaEntradaValor);

        }

    }
}
