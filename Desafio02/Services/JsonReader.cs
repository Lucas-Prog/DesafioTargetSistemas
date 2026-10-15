using Desafio02.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Desafio02.Services
{
    internal class JsonReader
    {
        string path = @"C:\Users\Mantega\Desktop\Curso\Desafio\DesafioTargertSistemas\Desafio02\Assets\Json.json";

        public List<Produto> GetEstoque() {
            List<Produto> deposito = new List<Produto>();

            JsonNode jsonPuro = null;
            JsonArray jsonTratado = null;

            try {
                jsonPuro = JsonNode.Parse(File.ReadAllText(path));
                jsonTratado = jsonPuro["estoque"]?.AsArray();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            if (jsonTratado != null) {
                foreach (JsonNode item in jsonTratado) {
                    deposito.Add(new Produto(
                        item["codigoProduto"].GetValue<int>(),
                        item["descricaoProduto"].GetValue<string>(),
                        item["estoque"].GetValue<int>()
                    ));
                }

                return deposito;
            }
            else {
                throw new Exception("Estoque Vazio");
            }

        }
        
    }

}
