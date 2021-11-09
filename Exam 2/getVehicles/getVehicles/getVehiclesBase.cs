namespace getVehicles
{
    public static class getVehiclesBase
    {

        [FunctionName("getVehicles")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string strMinMilesPerLiter = req.Query["MinMilesPerLiter"];

            log.LogInformation("C# HTTP trigger function processed a request.");

            Vehicle Maverick = new Vehicle(2022, "Ford", "Maverick", "78re540jk93j", 31);
            Vehicle Prius = new Vehicle(2010, "Toyota", "Prius", "VH5820req", 42);
            Vehicle UniMog = new Vehicle(1990, "Mercedes", "UniMog", "MIL839", 2.6);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            Vehicle[] arrVehicles = new Vehicle[] { Maverick, Prius, UniMog };
            List<Vehicle> getVehicles = new List<Vehicle>();

            foreach (Vehicle vhlVehicles in arrVehicles)
            {
                if (strMinMilesPerLiter == vhlVehicles.VIN)
                {
                    getVehicles.Add(vhlVehicles);
                }
                if (getVehicles.Count > 0)
                {
                    return new OkObjectResult(getVehicles);
                }
                else return new OkObjectResult("Vehicles Not Found");
            }
        }
    }
}