using _2demo.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace _2demo.Steps
{
    [Binding]
    public class DeletePosDefinitions
    {
        deleteMethods obj = new deleteMethods();
        [Given(@"I give A valid uri")]
        public void GivenIGiveAValidUri()
        {
            obj.uri(PostPosDefinitions.OrgUri);
        }

        [When(@"I enter S valid endpoint and choose http method")]
        public void WhenIEnterSValidEndpointAndChooseHttpMethod()
        {
            var given = PostPosDefinitions.OrgEndpoint + "/" + obj.newResource();
            obj.httpDelete(given);
        }

        [When(@"I excute request")]
        public void WhenIExcuteRequest()
        {
            obj.deleteExcute();
        }

        [Then(@"I validate the response using get method")]
        public void ThenIValidateTheResponseUsingGetMethod()
        {
            obj.deleteValidate();

        }
    }
}
