using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace InsertAndDeleteFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //1.

            string strQuery = "INSERT INTO tblAgency ('AgencyName','AgencyID','City','State','Nation') VALUES ('@Central Intelligence Agency','@39220c1e-21bb-46e4-a2af-19b72c1643f3','@Nashville','@TN','@US') ";
            string strConnection = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parAgencyName = new SqlParameter("parAgencyName", SqlDbType.VarChar);
                    parAgencyName.Value = "Central Intelligence Agency";
                    comSpyAgencies.Parameters.Add(parAgencyName);

                    SqlParameter parAgencyID = new SqlParameter("parAgencyID", SqlDbType.VarChar);
                    parAgencyID.Value = "39220c1e-21bb-46e4-a2af-19b72c1643f3";
                    comSpyAgencies.Parameters.Add(parAgencyID);

                    SqlParameter parCity = new SqlParameter("parCity", SqlDbType.VarChar);
                    parCity.Value = "Nashville";
                    comSpyAgencies.Parameters.Add(parCity);

                    SqlParameter parState = new SqlParameter("parState", SqlDbType.VarChar);
                    parState.Value = "TN";
                    comSpyAgencies.Parameters.Add(parState);

                    SqlParameter parNation = new SqlParameter("parNation", SqlDbType.VarChar);
                    parNation.Value = "US";
                    comSpyAgencies.Parameters.Add(parNation);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommandText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }

            //2.

            string strQuery2 = "INSERT INTO tblVehicles ('Make','Model','Year','Armored','Vin') VALUES ('@parToyota','@parTundra','@2000','@0','@7J3ZZ56T7834500003')";
            string strConnection2 = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parMake = new SqlParameter("parMake", SqlDbType.VarChar);
                    parMake.Value = "Toyota";
                    comSpyAgencies.Parameters.Add(parMake);

                    SqlParameter parModel = new SqlParameter("parModel", SqlDbType.VarChar);
                    parModel.Value = "Tundra";
                    comSpyAgencies.Parameters.Add(parModel);

                    SqlParameter parYear = new SqlParameter("parYear", SqlDbType.NVarChar);
                    parYear.Value = "2000";
                    comSpyAgencies.Parameters.Add(parYear);

                    SqlParameter parArmored = new SqlParameter("parArmored", SqlDbType.Bit);
                    parArmored.Value = "Unarmored";
                    comSpyAgencies.Parameters.Add(parArmored);

                    SqlParameter parVin = new SqlParameter("parVin", SqlDbType.VarChar);
                    parVin.Value = "7J3ZZ56T7834500003";
                    comSpyAgencies.Parameters.Add(parVin);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommandText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }

            //3.

            string strQuery3 = "INSERT INTO tblEmployee ('FirstName','LastName','Codename','StreetAddress','Zip','Country','Agency',) VALUES('@FirstName','@LastName','@Codename','@StreetAddress','@Zip','@Country','@Agency')";
            string strConnection3 = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parFirstName = new SqlParameter("parFirstName", SqlDbType.VarChar);
                    parFirstName.Value = "Sterling";
                    comSpyAgencies.Parameters.Add(parFirstName);

                    SqlParameter parLastName = new SqlParameter("parLastName", SqlDbType.VarChar);
                    parLastName.Value = "Archer";
                    comSpyAgencies.Parameters.Add(parLastName);

                    SqlParameter parCodeName = new SqlParameter("parCodename", SqlDbType.VarChar);
                    parCodeName.Value = "Duchess";
                    comSpyAgencies.Parameters.Add(parCodeName);

                    SqlParameter parStreetAddress = new SqlParameter("parStreetAddress", SqlDbType.VarChar);
                    parStreetAddress.Value = "1 Hogan Place";
                    comSpyAgencies.Parameters.Add(parStreetAddress);

                    SqlParameter parZip = new SqlParameter("parZip", SqlDbType.Int);
                    parZip.Value = "10013";
                    comSpyAgencies.Parameters.Add(parStreetAddress);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommandText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }

            //4.

            string strQuery4 = "UPDATE tblVehicles SET Armored = @parArmored WHERE VIN = @parVin";
            string strConnection4 = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parArmored = new SqlParameter("parArmored", SqlDbType.Bit);
                    parArmored.Value = "1";
                    comSpyAgencies.Parameters.Add(parArmored);

                    SqlParameter parVin = new SqlParameter("parVin", SqlDbType.VarChar);
                    parVin.Value = "7J3ZZ56T7834500003";
                    comSpyAgencies.Parameters.Add(parVin);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommandText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }

            //5.

            string strQuery5 = "DELETE FROM tblEmployees WHERE FirstName = '@parFirstName' AND LastName = '@parLastName' AND Codename = '@parCodeName' AND StreetAddress1 = '@StreetAddress1' AND City = '@parCity' AND State= '@parState' AND ZIP = '@parZIP' AND Country = '@parCountry' AND Agency = '@parAgency'  ";
            string strConnection5 = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parFirstName = new SqlParameter("parFirstName", SqlDbType.VarChar);
                    parFirstName.Value = "Sterling";
                    comSpyAgencies.Parameters.Add(parFirstName);

                    SqlParameter parLastName = new SqlParameter("parLastName", SqlDbType.VarChar);
                    parLastName.Value = "Archer";
                    comSpyAgencies.Parameters.Add(parLastName);

                    SqlParameter parCodeName = new SqlParameter("parCodeName", SqlDbType.VarChar);
                    parCodeName.Value = "Duchess";
                    comSpyAgencies.Parameters.Add(parCodeName);

                    SqlParameter StreetAddress1 = new SqlParameter("StreetAddress1", SqlDbType.VarChar);
                    StreetAddress1.Value = "1 Hogan Place";
                    comSpyAgencies.Parameters.Add(StreetAddress1);

                    SqlParameter parCity = new SqlParameter("parCity", SqlDbType.VarChar);
                    parCity.Value = "New York";
                    comSpyAgencies.Parameters.Add(parCity);

                    SqlParameter parState = new SqlParameter("parState", SqlDbType.VarChar);
                    parState.Value = "NY";
                    comSpyAgencies.Parameters.Add(parState);

                    SqlParameter parZIP = new SqlParameter("parZIP", SqlDbType.VarChar);
                    parZIP.Value = "10013";
                    comSpyAgencies.Parameters.Add(parZIP);

                    SqlParameter parCountry = new SqlParameter("parCountry", SqlDbType.VarChar);
                    parCountry.Value = "US";
                    comSpyAgencies.Parameters.Add(parCountry);

                    SqlParameter parAgency = new SqlParameter("parAgency", SqlDbType.VarChar);
                    parAgency.Value = "Central Intelligence Agency";
                    comSpyAgencies.Parameters.Add(parAgency);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommandText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }

            //6.

            string strQuery6 = " INSERT tblAssignment (AssignmentID, Mission, Agnet, AgentRole) VALUES (CONVERT(varchar(50), NEWID()), @parMission, @parAgent, @parAgentRole)";
            string strConnection6 = "Not Provided";
            try
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies))
                {
                    SqlParameter parMission = new SqlParameter("parMission", SqlDbType.VarChar);
                    parMission.Value = "Spicy Chili";
                    comSpyAgencies.Parameters.Add(parMission);

                    SqlParameter parAgent = new SqlParameter("parAgent", SqlDbType.VarChar);
                    parAgent.Value = "Lana Kane";
                    comSpyAgencies.Parameters.Add(parAgent);

                    SqlParameter parAgentRole = new SqlParameter("parAgentRole", SqlDbType.VarChar);
                    parAgentRole.Value = "Primary Agenty";
                    comSpyAgencies.Parameters.Add(parAgentRole);
                }
            }
            catch (Exception ex)
            {
                return OkObjectResult(ex.Message.ToString());
            }
        }
    }
}
