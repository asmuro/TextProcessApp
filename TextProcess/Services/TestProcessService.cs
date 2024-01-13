using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;
using Domain.Enums;
using System.Collections.Generic;
using Domain.Classes;
using System.Threading.Tasks;

namespace TextProcess.Services
{
    public class TestProcessService : ITestProcessService
    {
        #region ITestProcessService

        public async Task<IEnumerable<OrderType>> GetOrderOptions()
        {
            var client = new RestClient("http://localhost:7166");
            var request = new RestRequest($"TextProcess/GetOrderOptions");
            var response = await client.ExecuteGetAsync(request);
            return JsonSerializer.Deserialize<IEnumerable<OrderType>>(response.Content!)!;            
        }

        public async Task<string> GetOrderedText(string textToOrder, OrderType orderTypeSelected)
        {
            var client = new RestClient("http://localhost:7166");
            var request = new RestRequest($"TextProcess/GetOrderedText?textToOrder={textToOrder}&orderOption={(int)orderTypeSelected}");
            var response = await client.ExecuteGetAsync(request);
            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            return data.ToString();
        }

        public async Task<TextStatistics> GetStatistics(string textToAnalyze)
        {
            var client = new RestClient("http://localhost:7166");
            var request = new RestRequest($"TextProcess/GetStatistics?textToAnalyze={textToAnalyze}");
            var response = await client.ExecuteGetAsync(request);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TextStatistics>(response.Content!, options)!;            
        }

        ////http://localhost:7166/TextProcess/GetOrderedText?textToOrder=las%20cosas%20para%20ordenar&orderOption=0
        //var client = new RestClient("http://localhost:7166");
        //var request = new RestRequest($"TextProcess/GetOrderedText?textToOrder={TextToOrder}&orderOption={(int)OrderTypeSelected}");
        //var response = client.ExecuteGet(request);
        //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
        //OrderedText = data.ToString();

        //var options = new JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true
        //};
        //var product = JsonSerializer.Deserialize<Class1>(response.Content!, options)!;

        // deserialize json string response to JsonNode object
        //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;

        //http://localhost:7166/TextProcess/GetStatistics?textToAnalyze=el%20texto%20para%20analizar

        #endregion
    }
}
