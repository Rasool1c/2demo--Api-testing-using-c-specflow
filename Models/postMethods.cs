using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;
using _2demo.Hooks;
using AventStack.ExtentReports;
using static _2demo.Helper;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace _2demo.Models
{
    public class postMethods
    {
        RestClient client = new RestClient();
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();
        HttpStatusCode statusCode;
        JObject obs = new JObject();
        public void uri(string uri)
        {
            client = new RestClient(uri);
            Log.Information("uri is given");
            
        }
        public void httpPost(string resource)
        {
            request = new RestRequest(resource, Method.Post);
            Log.Information("resource is entered");
            Log.Debug("HTTP method selected as POST");
        }
        public void postFormat()
        {
            request.RequestFormat = DataFormat.Json;
            Log.Information("Data format is given as json");
            request.AddBody(new
            {
                id = "1089187",
                name = "rasool",
                age = "22",
                location = "banglore",
                domain = "testing"
            });
            Log.Information("Added json Body");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
        }
        public void postExcute()
        {
            response = client.Execute(request);
            Log.Debug("Request is executed");
            Console.WriteLine(response.Content);

        }
        public void postParse(string comparison)
        {
            JObject obs = JObject.Parse(response.Content);
            Log.Debug("Response is parsed");
            Console.WriteLine(obs);
            var todo = obs["name"].ToString();
            var expected = obs["name"].ToString();
            Console.WriteLine(expected);
            if (todo.Contains(comparison))
            {
                Console.WriteLine("response is validated");
                Log.Information("status code matched");
            }
            else
            {
                Console.WriteLine("response not natched");
                Log.Information("error, invalid response");
            }
            Assert.That(obs["name"].ToString(), Is.EqualTo(comparison));
            Log.Information("Validating the response");
        }
        public void postValidate(long httpCode)
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
