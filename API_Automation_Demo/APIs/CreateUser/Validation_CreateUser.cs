using API_Automation_Demo.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace API_Automation_Demo.APIs.CreateUser
{
    public class Validation_CreateUser
    {
        public void ValidateAPIResponse(string response, string payload)
        {
            var jsonObjResponse = JsonConvert.DeserializeObject<CreateApiResponse>(response);
            var jsonObjPayload = JsonConvert.DeserializeObject<Input>(payload);

            Console.WriteLine(jsonObjResponse.name);
            Assert.AreEqual(jsonObjResponse.name, jsonObjPayload.name);
            Assert.AreEqual(jsonObjPayload.job, jsonObjPayload.job);

            Assert.IsNotNull(jsonObjResponse.id, "Id should not be null");
            Assert.IsNotNull(jsonObjResponse.createdAt, "Created date should not be null");
        }
    }
}
