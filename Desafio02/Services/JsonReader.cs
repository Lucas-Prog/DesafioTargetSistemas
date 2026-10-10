using Desafio02.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Desafio02.Services
{
    internal class JsonReader
    {
        string path = @"C:\Users\Mantega\Desktop\Curso\Desafio\DesafioTargertSistemas\Desafio01\Assets\Vendas.json";

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
                            jsonTratado["codigoProduto"].GetValue<int>(),
                            jsonTratado["descricaoProduto"]?.GetValue<string>(),
                            jsonTratado["estoque"].GetValue<int>()
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
