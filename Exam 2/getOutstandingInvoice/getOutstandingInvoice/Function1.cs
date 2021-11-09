using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace getOustandingInvoices
{
    public static class OutstandingInvoices
    {
        private class Invoice
        {
            string InvoiceNumber { get; set; }
            string CustomerID { get; set; }
            decimal Amount { get; set; }
            bool Paid { get; set; }
            public Invoice(string strInvoiceNumber, string strCustomerID, decimal decAmount, bool blPaid)
            {
                InvoiceNumber = strInvoiceNumber;
                CustomerID = strCustomerID;
                Amount = decAmount;
                Paid = blPaid;
            }
        }

        [FunctionName("getOutstandingInvoices")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string strCustomerName = req.Query["Customername"];
            int intMinInvocieValue = int.Parse(req.Query["MinInvocieValue"]);

            log.LogInformation("Outstanding Invoices - CustomerName" + strCustomerName + "| MinInvoiceValue" + intMinInvocieValue.ToString());

            string strQuery = "SELECT @parInvoiceNumber, @parCustomerID, @parAmount, @parPaid FROM tblInvoice JOIN tblCustomer on tblInvoice.CustomerID = tblCustomer.CustomerID";
            DataSet dsOutstandingInvoice = new DataSet();
            string strConnection = "Server=tcp:myserver.database.windows.net,1433;Database=myDataBase;UserID=mylogin@myserver;Password=myPassword;Trusted_Connection=False;Encrypt=True;";
            try
            {
                using (SqlConnection conInvoice = new SqlConnection(strConnection))
                using (SqlCommand comInvoice = new SqlCommand(strQuery, conInvoice))
                {
                    SqlParameter parInvoiceNumber = new SqlParameter("parInvoiceNumber", SqlDbType.VarChar);
                    parInvoiceNumber.Value = parInvoiceNumber;
                    comInvoice.Parameters.Add(parInvoiceNumber);

                    SqlParameter parCustomerID = new SqlParameter("parCustomerID", SqlDbType.VarChar);
                    parCustomerID.Value = parCustomerID;
                    comInvoice.Parameters.Add(parCustomerID);

                    SqlParameter parAmount = new SqlParameter("parAmount", SqlDbType.Decimal);
                    parAmount.Value = parAmount;
                    comInvoice.Parameters.Add(parAmount);

                    SqlParameter parPaid = new SqlParameter("parPaid", SqlDbType.Bit);
                    parPaid.Value = parPaid;
                    comInvoice.Parameters.Add(parPaid);

                    comInvoice.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }
        }
    }
}
