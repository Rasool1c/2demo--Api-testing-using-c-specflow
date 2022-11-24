using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _2demo.Hooks;
using Log = Serilog.Log;
using Newtonsoft.Json;
using _2demo.Steps;
namespace _2demo.Models
{
    public class getMethods
    {
        RestClient client = new RestClient();
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();
        HttpStatusCode statusCode;
        JObject obs = new JObject();
        public static string OrgUri1 = "https://crudcrud.com/api/e37e21001a7446f793dcda3d55a04e2b/";
        public static string OrgEndpoint1 = "users";
        public string newResource()
        {
            var client = new RestClient(OrgUri1);
            var request = new RestRequest(OrgEndpoint1, Method.Get);
            var response = client.Execute(request);
            var catcher = response.Content;
            List<dynamic> models = JsonConvert.DeserializeObject<List<dynamic>>(catcher);
            var newRes = models[0]._id;
            return newRes;
        }
        public void uri(string uri)
        {
            client = new RestClient(uri);
            Log.Information("uri is given");
        }
        public void httpGet(string endpoint)
        {
            request = new RestRequest(endpoint, Method.Get);
            Log.Information("resource is entered");
            Log.Debug("HTTP method selected as GET");
        }
        public void getExcute()
        {
            response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public void getParse(string comparison)
        {
            JObject obs = JObject.Parse(response.Content);
            Log.Debug("Response is parsed");
            Console.WriteLine(obs);
            var expected = obs["name"].ToString();
            if (expected.Contains(comparison))
            {
                Console.WriteLine("response is validated,"+expected);
                Log.Information("status code matched");
            }
            else
            {
                Console.WriteLine("response not natched,"+expected);
                Log.Information("error, invalid response");
            }
            //Assert.That(obs["name"].ToString(), Is.EqualTo(comparison));
            Log.Information("Validating the response");
        }
        public void getValidate(long httpCode)
        {

            statusCode = response.StatusCode;
            var scodes = (int)statusCode;
            Log.Debug("validating status code");
            Console.WriteLine(scodes);
            if (scodes == httpCode)
            {
                Console.WriteLine("success");
                Log.Information("status code matched");
            }
            else
            {
                Console.WriteLine("error");
                Log.Information($"Error: {statusCode}");
            }
        }
    }
}
