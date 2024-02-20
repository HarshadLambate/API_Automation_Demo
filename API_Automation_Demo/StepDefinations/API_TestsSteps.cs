using API_Automation_Demo.APIs.CreateUser;
using API_Automation_Demo.Utilities;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace API_Automation_Demo.StepDefinations
{
    [Binding]
    public class API_TestsSteps
    {
        TestHelper helper = new TestHelper();
        Validation_CreateUser valCreateUser = new Validation_CreateUser();
        RestApiClient client;
        HttpResponseMessage result;
        string payload;

        [Given(@"I execute POST create user API")]
        public async Task GivenIExecutePOSTCreateUserAPIAsync()
        {
            try
            {
                var env = await helper.GetEnvironmentDataAsync();
                client = new RestApiClient(env.baseUrl);
                payload = await helper.ReadJsonFileAsync(@"APIs\CreateUser\input.json") ;
                result = await client.Post(env.createUserEndpoint, payload) ;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Given(@"I validate status code '(.*)'")]
        public void GivenIValidateStatusCode(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, Convert.ToInt32(result.StatusCode));
        }

        [Then(@"I validate create user API response details")]
        public void ThenIValidateCreateUserAPIResponseDetails()
        {
            valCreateUser.ValidateAPIResponse(result.Content.ReadAsStringAsync().Result, payload);
        }

        [Given(@"I execute GET user details API")]
        public async Task GivenIExecuteGETUserDetailsAPI()
        {
            try
            {
                var env = await helper.GetEnvironmentDataAsync();
                client = new RestApiClient(env.baseUrl);
                result = await client.Get(env.getUserDetails);
                Console.WriteLine(result.StatusCode);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
