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
    //public static class getEmployees
    //{
    //    private class Employees
    //    {
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public string CodeName { get; set; }
    //        public Employees(string strFirstName, string strLastName, string strCodeName)
    //        {
    //            FirstName = strFirstName;
    //            LastName = strLastName;
    //            CodeName = strCodeName;
    //        }
    //    }
    //}
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

         // 1.--------------------------------------------------
            string strQuery = "SELECT FirstName, LastName, CodeName FROM dbo.tblEmployeees";
            DataSet dsSpies = new DataSet();
            string strConnection = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conSpies = new SqlConnection(strConnection))
                using (SqlCommand comSpies = new SqlCommand(strQuery, conSpies))
                {
                    //SqlParameter parFirstName = new SqlParameter("FirstName", SqlDbType.VarChar);
                    //parFirstName.Value = strFirstName;
                    //comSpies.Parameters.Add(parFirstName);

                    //SqlParameter parLastName = new SqlParameter("LastName", SqlDbType.VarChar);
                    //parLastName.Value = strLastName;
                    //comSpies.Parameters.Add(parLastName);

                    //SqlParameter parCodeName = new SqlParameter("CodeName", SqlDbType.VarChar);
                    //parCodeName.Value = strCodeName;
                    //comSpies.Parameters.Add(parCodeName);

                    SqlDataAdapter daSpies = new SqlDataAdapter(comSpies);
                    daSpies.Fill(dsSpies);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsSpies.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            //2.--------------------------------------------------
            string strQuerey2 = "SELECT FirstName, LastName, City, State, AgencyName FROM tbl.Employeees LEFT JOIN tblAgencies ON tblEmployeees.Angency = tbl.Agencies.AgencyID";
            DataSet dsEmployee = new DataSet();
            string strConnection2 = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try {
                using (SqlConnection conEmployee = new SqlConnection(strConnection))
                using (SqlCommand comEmployee = new SqlCommand(strQuery, conEmployee))
                {
                    SqlDataAdapter daEmployee = new SqlDataAdapter(comEmployee);
                    daEmployee.Fill(dsEmployee);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsEmployee.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            //.3--------------------------------------------------
            string strQuerey3 = "SELECT Model, VIN FROM dbo.tblVehicles WHERE Model = @parFord";
            DataSet dsVehicle = new DataSet();
            string strConnection3 = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conVehicle = new SqlConnection(strConnection))
                using (SqlCommand comVehicle = new SqlCommand(strQuery, conVehicle))
                {
                    SqlParameter parFord = new SqlParameter("ParFord", SqlDbType.VarChar);
                    parFord.Value = strFord;
                    comVehicle.Parameters.Add(parFord);

                    SqlDataAdapter daVehicle = new SqlDataAdapter(comVehicle);
                    daVehicle.Fill(dsVehicle);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsVehicle.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            //4.--------------------------------------------------
            string strQuerey4 = "SELECT Agents, Mission, AgentRole FROM dbo.tblAssignments JOIN tblMissions ON tblAssignments.AssignmentID=tblMissions.MissionID WHERE Mission = '@parOperationAwesomeEagle' AND AgentRole = '@parLeadFieldAgent'";
            DataSet dsAssignments = new DataSet();
            string strConnection4 = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conAssignments = new SqlConnection(strConnection))
                using (SqlCommand comAssignments = new SqlCommand(strQuery, conAssignments))
                {
                    SqlParameter parOperationAwesomeEagle = new SqlParameter("parOperationAwesomeEagle", SqlDbType.VarChar);
                    parOperationAwesomeEagle.Value = strOperationAwesomeEagle;
                    comAssignments.Parameters.Add(parOperationAwesomeEagle);

                    SqlParameter parLeadFieldAgent = new SqlParameter("parLeadFieldAgent", SqlDbType.VarChar);
                    parLeadFieldAgent.Value = strLeadFieldAgent;
                    comAssignments.Parameters.Add(parLeadFieldAgent);

                    SqlDataAdapter daAssignments = new SqlDataAdapter(comAssignments);
                    daAssignments.Fill(dsAssignments);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsAssignments.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            //5.--------------------------------------------------
            string strQuerey5 = "SELECT FirstName, LastName, NationalAffilication FROM tblAgencies JOIN tblEmployees ON tbAgencies.AgencyID = tblEmployeees.Agency WHERE NationalAffiliation = '@parCanada'";
            DataSet dsAgencies = new DataSet();
            string strConnection5 = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conAgencies = new SqlConnection(strConnection))
                using (SqlCommand comAgencies = new SqlCommand(strQuery, conAgencies))
                {
                    SqlParameter parCanada = new SqlParameter("parCanada", SqlDbType.VarChar);
                    parCanada.Value = strCanada;
                    comAgencies.Parameters.Add(parCanada);

                    SqlDataAdapter daAgencies = new SqlDataAdapter(comAgencies);
                    daAgencies.Fill(dsAgencies);
                    return new OkObjectResult(JsonConvert.SerializeObject(dsAgencies.Tables[0]));
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            //6.--------------------------------------------------
            string strQuerey6 = "SELECT Agent, AgentRole, Mission FROM tblAssignments Where Agent = '@parAgentInCharge' AND Mission = '@parBookDrop'";
            DataSet dsAssignments2 = new DataSet();
            string strConnection6 = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conAssignments2 = new SqlConnection(strConnection))
                using (SqlCommand comAssignments2 = new SqlCommand(strQuery, conAssignments2))
                {
                    SqlParameter parAgentInCharge = new SqlParameter("parAgentInCharge", SqlDbType.VarChar);
                    parAgentInCharge.Value = strAgentInCharge;
                    comAssignments2.Parameters.Add(parAgentInCharge);

                    SqlParameter parBookDrop = new SqlParameter("parBookDrop", SqlDbType.VarChar);
                    parBookDrop.Value = strBookDrop;
                    comAssignments2.Parameters.Add(parBookDrop);
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }
        }
    }
}
