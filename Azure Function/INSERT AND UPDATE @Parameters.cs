            /* INSERT */

            string strQuery = "INSERT INTO tblEmployee VALUES('@FirstName','@LastName','@Codename','@StreetAddress','@City','@State','@ZIP','@Country','@Agency')";
            string strConnection = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try 
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies)) 
                {
                    SqlParameter parFirstName = new SqlParameter("FirstName", SqlDbType.VarChar);
                    parCodename.Value = "Sterling";
                    comSpyAgencies.Parameters.Add(FirstName);

                    SqlParameter LastName = new SqlParameter("LastName", SqlDbType.VarChar);
                    parCodename.Value = "Archer";
                    comSpyAgencies.Parameters.Add(LastName);

                    SqlParameter CodeName = new SqlParameter("CodeName", SqlDbType.VarChar);
                    parCodename.Value = "Duchess";
                    comSpyAgencies.Parameters.Add(CodeName);

                    SqlParameter StreetAddress = new SqlParameter("StreetAddress", SqlDbType.VarChar);
                    parCodename.Value = "10 E BroadStreet";
                    comSpyAgencies.Parameters.Add(StreetAddress);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommanText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }


            /* UPDATE */


            string strQuery = "UPDATE tblEmployees SET @FirstName = 'Mallory' WHERE @CodeName = 'Duchess'";
            string strConnection = "Server=tcp:ttu-bburchfield-ds870.database.windows.net,1433;Initial Catalog=ds3870;Persist Security Info=False;User ID=bburchfield;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try 
            {
                using (SqlConnection conSpyAgencies = new SqlConnection(strConnection))
                using (SqlCommand comSpyAgencies = new SqlCommand(strQuery, conSpyAgencies)) 
                {
                    SqlParameter parFirstName = new SqlParameter("FirstName", SqlDbType.VarChar);
                    parCodename.Value = "Mallory";
                    comSpyAgencies.Parameters.Add(FirstName);

                    SqlParameter CodeName = new SqlParameter("CodeName", SqlDbType.VarChar);
                    parCodename.Value = "Duchess";
                    comSpyAgencies.Parameters.Add(CodeName);

                    comSpyAgencies.Connection = conSpyAgencies;
                    comSpyAgencies.CommanText = strQuery;
                    Connection.Open()
                    comSpyAgencies.ExecuteNonQuerey();
                    conSpyAgencies.Close();
                }
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message.ToString());
            }