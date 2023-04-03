
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using RestSharp;
using utilities;

namespace extensions
{
    public class APIActions : CommponsOps
    {

        private static void setRequestHeaders() {
            httpRequest.AddHeader("Accept", "application/json");
            httpRequest.AddHeader("Content-Type", "application/json");
        }

    [AllureStep("Get Data From Server")]
    public static void Get(string queryParam)
      {
            httpRequest = new RestRequest(queryParam, Method.Get);
            setRequestHeaders();
            httpResponse = client.Execute(httpRequest);
            Assert.True(httpResponse.IsSuccessful);
        }

     [AllureStep("Get Status Code")]
    public static string GetStatusCode()
      {
           return httpResponse.StatusCode.ToString();
      }


    [AllureStep("Get Data From Response")]
    public static dynamic GetDeserializeResponse()
      {
            dynamic response = JObject.Parse(httpResponse.Content);
            return response;
      }

     [AllureStep("Post Data To Server")]
     public static void Post(string queryParam, string body)
       {
            httpRequest = new RestRequest(queryParam, Method.Post);
            httpRequest.AddBody(body);
            setRequestHeaders();
            httpResponse = client.Execute(httpRequest);
            Assert.True(httpResponse.IsSuccessful);
        }

     [AllureStep("Delete Data From Server")]
     public static void Delete(string queryParam)
       {
            httpRequest = new RestRequest(queryParam, Method.Delete);
            setRequestHeaders();
            httpResponse = client.Execute(httpRequest);
            Assert.True(httpResponse.IsSuccessful);
        }

     [AllureStep("Put Data To Server")]
     public static void Put(string queryParam, string body)
        {
            httpRequest = new RestRequest(queryParam, Method.Put);
            httpRequest.AddBody(body);
            setRequestHeaders();
            httpResponse = client.Execute(httpRequest);
            Assert.True(httpResponse.IsSuccessful);
        }

        public static string CreateRequest(Dictionary<string, string> dictionary, string requestBody)
        {
            foreach (string key in dictionary.Keys)
            {
                requestBody = requestBody.Replace("{" + key + "}", dictionary[key]);
            }
            return requestBody;
        }

    }
}
