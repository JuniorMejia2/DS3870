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

namespace Practice_Attempt_1
{
    public static class PracticeExam2
    {
        public class Employees
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Codename { get; set; }
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int ZIP { get; set; }
            public string Country { get; set; }
            public string Agency { get;set }
            public Employees (string strFirstName, string strLastName, string strCodeName, string strStreetAddress, string strCity, string strState, int intZIP, string strCountry, string strAgency)
            {
                FirstName = strFirstName;
                LastName = strLastName;
                Codename = strCodeName;
                StreetAddress = strStreetAddress;
                City = strCity;
                State = strState;
                ZIP = intZIP;
                Country = strCountry;
                Agency = strAgency;
            }
        }

        [FunctionName("AddEmployees")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("AddEmployees" + System.DateTime.Now.ToLongDateString());

            string strFirstName = req.Query["strFirstBane"];
            string strLastName = req.Query["strLastName"];
            string strCodeName = req.Query["strCodeName"];
            string strStreetAddress = req.Query["strStreetAddress"];
            string strCity = req.Query["strCity"];
            string strState = req.Query["strState"];
            int intZip = int.Parse(req.Query["intZIP"]);
            string strCountry = req.Query["strCountry"];
            string strAgency = req.Query["strAgency"];

            log.LogInformation("New Employyee's Hired - FirstName:" + strFirstName + " | LastName:" + strLastName + " | CodeName:" + strCodeName + "| StreetAddress" + strStreetAddress + "| City" + strCity + "| State" + strState + "| Zip" + intZip.ToString() + "| Country" + strCountry + "| Agency" + strAgency);

            string strQuery = "INSERT INTO tblEmployees VALUES (@parFirstName, @parLastName, @parCodeName, @parStreetAddress, @parCity, @parState, @parZIP, @parCountry, @parAgency)";
            using SqlConnection conspy = new SqlConnection("Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password=Mickey2021!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand comSpy = new SqlCommand(strQuery, conspy);
            {
                SqlParameter parFirstName = new SqlParameter("parFirstName", System.Data.SqlDbType.VarChar);
                parFirstName.Value = strFirstName;
                comSpy.Parameters.Add("parFirstName");

                SqlParameter parLastName = new SqlParameter("parLastName", System.Data.SqlDbType.VarChar);
                parLastName.Value = parLastName;
                comSpy.Parameters.Add("parLastName");

                comSpy.ExecuteNonQuery();
            }
        }
    }
}
