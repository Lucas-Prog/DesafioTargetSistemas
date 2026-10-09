using Desafio01.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Desafio01.Services
{
    internal class JsonReader
    {
        string path = @"C:\Users\Mantega\Desktop\Curso\Desafio\DesafioTargertSistemas\Desafio01\Assets\Vendas.json";

        //GetJson pega o json puro/string no arquivo e o converte para o tipo para melhor manipulação e o retorna.
        public List<Venda> GetVendas() {
            List<Venda> vendas = new List<Venda>();
            JsonArray jsonArray = null;

            try {
                string t = File.ReadAllText(path);

                JsonNode jsonPuro = JsonNode.Parse(t);
                jsonArray = jsonPuro["vendas"]?.AsArray();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            string vendedor;
            double valor;
            foreach(JsonNode jsonItem in jsonArray) {
                vendedor = jsonItem["vendedor"]?.GetValue<string>();
                valor = jsonItem["valor"]?.GetValue<double>() ?? 0.0;

                Venda item = new Venda(vendedor, valor);
            }

            return vendas;
        }
    }
}
