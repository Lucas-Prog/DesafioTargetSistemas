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
        private readonly string path = Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Vendas.json"
        );

        //GetJson pega o json puro/string no arquivo e o converte para o tipo para melhor manipulação e o retorna.
        public JsonArray? GetJson() {
            JsonArray jsonArray = new JsonArray();
            string jsonString;
            try {
                jsonString= File.ReadAllText(path); ;
                JsonNode jsonPuro = JsonNode.Parse(jsonString);
                jsonArray = jsonPuro["vendas"].AsArray();

                return jsonArray;
            }
            catch (Exception ex) {
                Console.WriteLine($"Arquivo invalido: {ex.Message}");
                return null;
            }
        }
    }
}
