using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using _2demo.Models;
using NPOI.SS.Formula.Functions;

namespace _2demo.Steps
{
    [Binding]
    public class PostPosDefinitions
    {
        postMethods obj = new postMethods();
        public static string OrgUri = "https://crudcrud.com/api/e37e21001a7446f793dcda3d55a04e2b/";
        public static string OrgEndpoint = "users";

        [Given(@"I given valid uri and endpoint")]
        public void GivenIGivenValidUriAndEndpoint()
        { 
            
            obj.uri(OrgUri);            
        }

        [When(@"I choose the respective http method type as post")]
        public void WhenIChooseTheRespectiveHttpMethodTypeAsPost()
        {
            obj.httpPost(OrgEndpoint);
        }

        [When(@"I enter the body and format details")]
        public void WhenIEnterTheBodyAndFormatDetails()
        {
            obj.postFormat();
        }

        [Then(@"I excute the request and parse the response")]
        public void ThenIExcuteTheRequestAndParseTheResponse()
        {
            obj.postExcute();
            obj.postParse("rasool");
        }

        [Then(@"I validate the response")]
        public void ThenIValidateTheResponse()
        {                       
            obj.postValidate(201);
        }
    }
}
