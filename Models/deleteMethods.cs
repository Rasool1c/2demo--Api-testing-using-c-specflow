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
using _2demo.Steps;
using Newtonsoft.Json;

namespace _2demo.Models
{
    public class deleteMethods
    {
        RestClient client = new RestClient();
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();
        HttpStatusCode statusCode;
        JObject obs = new JObject();
        public string newResource()
        {
            var client = new RestClient(getMethods.OrgUri1);
            var request = new RestRequest(getMethods.OrgEndpoint1, Method.Get);
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
        public void httpDelete(string resource)
        {
            request = new RestRequest(resource, Method.Delete);
            Log.Information("resource is entered");
            Log.Debug("HTTP method selected as DELETE");
        }
        public void deleteExcute()
        {
            response = client.Execute(request);
            Log.Debug("Request is executed");
            Console.WriteLine(response.Content);
        }
        public void deleteValidate()
        {

            statusCode = response.StatusCode;
            var scodes = (int)statusCode;
            Log.Debug("validating status code");
            Console.WriteLine(scodes);
            if (scodes == 200)
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
