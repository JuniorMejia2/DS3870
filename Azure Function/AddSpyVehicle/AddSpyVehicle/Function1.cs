using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace AddSpyVehicle
{
    public static class Function1
    {
        [FunctionName("addVehicles")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("addVehcle called at" + System.DateTime.Now.ToLongDateString());

            string strMake = req.Query["strMake"];
            string strModel = req.Query["strModel"];
            int intYear = int.Parse(req.Query["intYear"]);
            string strArmored = req.Query["blnArmored"];
            bool blnArmored = false;
                if(strArmored == "true")
                {
                    blnArmored = true;
                }
            string strVIN = req.Query["strVIN"];

            log.LogInformation("New Vehcile Passed - Make:" + strMake + " | Model:" + strModel + " | Year:" + intYear.ToString() + " | Armored" + blnArmored.ToString());

            string strQuery = "INSERT INTO  tblVehicles VALUES (@parMake, @parMode, @parArmored, @parVIN)";
            using SqlConnection conspy = new SqlConnection("MyConnectionString");
            using SqlCommand comSpy = new SqlCommand(strQuery, conspy);
            {

                SqlParameter parMake = new SqlParameter("parMake", System.Data.SqlDbType.VarChar);
                parMake.Value = strMake;
                comSpy.Parameters.Add("parMake");

                SqlParameter parModel = new SqlParameter("parModel", System.Data.SqlDbType.VarChar);
                parModel.Value = parModel;
                comSpy.Parameters.Add("parModel");

                SqlParameter parYear = new SqlParameter("parYear", System.Data.SqlDbType.Int);
                parYear.Value = parYear;
                comSpy.Parameters.Add("parYear");

                SqlParameter parArmored = new SqlParameter("parArmored", System.Data.SqlDbType.Bit);
                parArmored.Value = parArmored;
                comSpy.Parameters.Add("parArmored");

                SqlParameter parVIN = new SqlParameter("parVIN", System.Data.SqlDbType.VarChar);
                parVIN.Value = parVIN;
                comSpy.Parameters.Add("parVIN");

                comSpy.ExecuteNonQuery();
            }
            string strMessage = "Success";

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(strMessage);
        }
    }
}
