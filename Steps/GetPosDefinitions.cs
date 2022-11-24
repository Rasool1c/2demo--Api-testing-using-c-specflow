using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using _2demo.Models;
using Newtonsoft.Json;

namespace _2demo.Steps
{
    [Binding]
    public class GetPosDefinitions
    {
        getMethods obj = new getMethods();
        [Given(@"I given valid uri and endpoints")]
        public void GivenIGivenValidUriAndEndpoints()
        {          
            obj.uri(PostPosDefinitions.OrgUri);
        }

        [When(@"I choose the respective http method type as get")]
        public void WhenIChooseTheRespectiveHttpMethodTypeAsGet()
        {
            var given = PostPosDefinitions.OrgEndpoint+"/"+ obj.newResource();
            Console.WriteLine(given);
            obj.httpGet(given);
        }

        [When(@"i excute the request")]
        public void WhenIExcuteTheRequest()
        {
            obj.getExcute();
            
        }

        [Then(@"i parse and validate the response")]
        public void ThenIParseAndValidateTheResponse()
        {
            obj.getParse("rasool");
            obj.getValidate(200);
        }

    }
}
