using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using _2demo.Models;

namespace _2demo.Steps
{
    [Binding]
    public class PutPosDefinitions
    {
        putMethods obj = new putMethods();

        [Given(@"I given valid uri")]
        public void GivenIGivenValidUri()
        {
            obj.uri(PostPosDefinitions.OrgUri);
        }

        [When(@"I enter valid endpoint and choose http method")]
        public void WhenIEnterValidEndpointAndChooseHttpMethod()
        {
            var given = PostPosDefinitions.OrgEndpoint+"/"+ obj.newResource();
            Console.WriteLine(given);
            obj.httpPut(given);
        }

        [When(@"I enter the valid body and format details")]
        public void WhenIEnterTheValidBodyAndFormatDetails()
        {
            obj.putFormat();
        }

        [When(@"I excute the request")]
        public void WhenIExcuteTheRequest()
        {
            obj.putExcute();
        }

        [Then(@"I parse the response and validate it")]
        public void ThenIParseTheResponseAndValidateIt()
        {
            obj.putValidate(200);
            obj.putVerifyByGet();
        }
    }
}
