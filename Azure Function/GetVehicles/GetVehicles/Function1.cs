using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GetVehicles
{
    public static class getVehicles
    {
        private class Brand
        {
            public string Name { get; set; }
            public string StreetAddress {get; set;}
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public Brand (string strName, string strStreetAddress, string strCity, string strState, string strZip) 
            {
                Name = strName;
                StreetAddress = strStreetAddress;
                City = strCity;
                State = strState;
                Zip = strZip;
            }

        }
        private class Vehicle 
        { 
            public object Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double MPG { get; set; }
            public Vehicle (object objBrand, string strModel, int intYear, double dblMPG) 
            {
                Brand = objBrand;
                Model = strModel;
                Year = intYear;
                MPG = dblMPG;
            }
        }
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Brand 


            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
