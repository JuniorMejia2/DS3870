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
using System.Collections.Generic;
using System.Data;

namespace SpyDatabase
{
    public static class getEmployees
    {
        private class Employees
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string CodeName { get; set; }
            public Employees(string strFirstName, string strLastName, string strCodeName)
            {
                FirstName = strFirstName;
                LastName = strLastName;
                CodeName = strCodeName;
            }
        }
    }
    public static class Function1
    {
        [FunctionName("getEmployees")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string strFirstName = req.Query["FirstName"];
            string strLastName = req.Query["LastName"];
            string strCodeName = req.Query["CodeName"];

            string strQuery = "SELECT * FROM dbo.tblEmployeees where CodeName = @parCodename";
            DataSet dsSpies = new DataSet();
            string strConnection = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conSpies = new SqlConnection(strConnection))
                using (SqlCommand comSpies = new SqlCommand(strQuery, conSpies))
                {
                    SqlParameter parCodeName = new SqlParameter("parCodeName", SqlDbType.VarChar);
                    parCodeName.Value = strCodeName;
                    comSpies.Parameters.Add(parCodeName);

                    SqlParameter parFirstName = new SqlParameter("parFirstName", SqlDbType.VarChar);
                    parFirstName.Value = strFirstName;
                    comSpies.Parameters.Add(parFirstName);

                    SqlParameter parLastName = new SqlParameter("parLastName", SqlDbType.VarChar);
                    parLastName.Value = strLastName;
                    comSpies.Parameters.Add(parLastName);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsSpies.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }
        }
    }
}
