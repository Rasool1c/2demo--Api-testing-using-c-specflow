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
using System.Security.Cryptography.X509Certificates;
using _2demo.Models;
using _2demo.Steps;
using Newtonsoft.Json;

namespace _2demo.Models
{
    
    public class putMethods
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
        public void httpPut(string resource)
        {
            request = new RestRequest(resource, Method.Put);
            Log.Information("resource is entered");
            Log.Debug("HTTP method selected as PUT");
        }
        public void putFormat()
        {
            request.RequestFormat = DataFormat.Json;
            Log.Information("Data format is given as json");
            request.AddBody(new
            {
                id = "1089187",
                name = "rasool a",
                age = "22",
                location = "banglore",
                domain = "testing"
            });
            Log.Information("Added json Body");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
        }
        public void putExcute()
        {
            response = client.Execute(request);
            Log.Debug("Request is executed");
            Console.WriteLine(response.Content);
        }
        public void putValidate(long httpCode)
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
        public void putVerifyByGet()
        {
            GetPosDefinitions newGet = new GetPosDefinitions();
            newGet.GivenIGivenValidUriAndEndpoints();
            newGet.WhenIChooseTheRespectiveHttpMethodTypeAsGet();
            newGet.WhenIExcuteTheRequest();
            newGet.ThenIParseAndValidateTheResponse();
            
        }
    }
}
