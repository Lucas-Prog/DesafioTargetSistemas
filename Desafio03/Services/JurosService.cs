using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio03.Services
{
    internal class JurosService
    {
        private readonly double taxaDeJuros = 0.025;

        public string CalculaJuros(DateTime data, double valor) {
            int diasCorridos = ContaDiasCorridos(data);
            string mensagem = "";
            if (diasCorridos > 0) {
                mensagem = $"---------------------------- \n" +
                            $"Juros Simples: {CalculaJurosSimples(diasCorridos, valor).ToString("F2")}\n" +
                            $"Juros Composto: {CalculaJurosComposto(diasCorridos, valor).ToString("F2")}";                
            }
            else {
                mensagem = "Data de Vencimento não pode ser maior que a data atual !!!";
            }
            return mensagem;
        }        

        public double CalculaJurosSimples(int diasCorridos, double valor) {
            return valor * taxaDeJuros * diasCorridos;
        }

        public double CalculaJurosComposto(int diasCorridos, double valor) {
            double juros = valor * Math.Pow(1 + taxaDeJuros, diasCorridos);
            return juros - valor;
        }
        public int ContaDiasCorridos(DateTime dataVencimento) {
            DateTime dataHojeUtc = DateTime.Now;
            TimeSpan diferenca = dataHojeUtc.Subtract(dataVencimento);

            return diferenca.Days;
        }
    }
}
