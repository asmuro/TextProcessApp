using System.Windows;

namespace TextProcess
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Thread.Sleep(2000);

            //var client = new RestClient("http://localhost:7166");
            //var request = new RestRequest("TextProcess/GetName?name=cso");
            //var response = client.ExecuteGet(request);

            

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //var product = JsonSerializer.Deserialize<Class1>(response.Content!, options)!;

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
        }
    }
}
