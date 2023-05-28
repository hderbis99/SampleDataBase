using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace DataBase_Student
{
    class DbStudent
    {
        public static SqlConnection GetConnection()
        {
            string databaseFileName = "StudentDataBase.mdf";
            string databaseFilePath = Path.Combine(Application.StartupPath, databaseFileName);

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlCommand checkpointCmd = new SqlCommand("CHECKPOINT", con);
                checkpointCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connection to the database failed! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return con;
        }

        public static void addStudent(Student std)
        {
            string connectionString = "INSERT INTO Table_STD (Name, Data, Payment, Contact) VALUES (@StudentName, @StudentData, @StudentPayment, @StudentContact)";
            using (SqlConnection con = GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand(connectionString, con, transaction))
                    {
                        cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
                        cmd.Parameters.Add("@StudentData", SqlDbType.Date).Value = std.Data;
                        cmd.Parameters.Add("@StudentPayment", SqlDbType.Money).Value = std.Payment;
                        cmd.Parameters.Add("@StudentContact", SqlDbType.VarChar).Value = std.Contact;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Student not inserted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Now we need to save changes to the MDF file
            SqlConnection.ClearAllPools(); // Clear connection pools to avoid file locking issues
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = Path.Combine(Application.StartupPath, "StudentDataBase.mdf"),
                IntegratedSecurity = true
            };
            string databaseFile = builder.AttachDBFilename;

            using (SqlConnection tempCon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databaseFile};Integrated Security=True"))
            {
                tempCon.Open();
                SqlCommand saveCmd = new SqlCommand("CHECKPOINT", tempCon); // Checkpoint to commit changes to the MDF file
                saveCmd.ExecuteNonQuery();
            }
        }
        public static void UpdateStudent(Student std, string id)
        {
            // The values of the Name Data etc columns will be changed to the values passed in the StudentName etc parameter.
            string connectionString = "UPDATE Table_STD SET Name = @StudentName, Data = @StudentData, Payment = @StudentPayment, Contact = @StudentContact WHERE Id = @StudentId";
            SqlConnection con = GetConnection(); 
            SqlCommand cmd = new SqlCommand(connectionString, con);  
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@StudentId", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentData", SqlDbType.Date).Value = std.Data;
            cmd.Parameters.AddWithValue("@StudentPayment", SqlDbType.Money).Value = std.Payment;
            cmd.Parameters.Add("@StudentContact", SqlDbType.VarChar).Value = std.Contact;
            try 
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Student not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close(); 
        }
        public static void DeleteStudent(string id)
        {
            //The query says that the deletion will apply to a record with the ID that is passed in the StudentID parameter.
            string connectionString = "DELETE FROM Table_STD WHERE Id = @StudentId";

            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(connectionString, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@StudentId", SqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Student not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public double GetTotalPaymentsForPeriod(DateTime startDate, DateTime endDate)
        {
            double totalPayment = 0;
            string connectionString = "SELECT SUM(Payment) FROM Table_STD WHERE Data >= @StartDate AND Data <= @EndDate";
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(connectionString, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate.AddDays(1).AddTicks(-1);

                    try
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalPayment = Convert.ToDouble(result);
                        }
                        //MessageBox.Show($"Total Payment: {totalPayment}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return totalPayment;
        }
        public static void DeleteAllRecords()
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Table_STD";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void BackupDatabase(string backupPath)
        {
            string databaseFileName = "StudentDataBase.mdf";
            string databaseFilePath = Path.Combine(Application.StartupPath, databaseFileName);
            SqlConnection con = GetConnection();

            // Zamykanie połączenia z bazą danych, jeśli istnieje
            if (con != null && con.State != ConnectionState.Closed)
            {
                con.Close();
            }

            // Tworzenie nowego połączenia z bazą danych (master)
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
            SqlConnection masterConnection = new SqlConnection(connectionString);
            masterConnection.Open();

            try
            {
                // Wykonywanie polecenia tworzącego kopię zapasową bazy danych
                string commandText = "BACKUP DATABASE [" + databaseFilePath + "] TO DISK='" + backupPath + "'";
                SqlCommand command = new SqlCommand(commandText, masterConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas tworzenia kopii zapasowej bazy danych: " + ex.Message);
            }
            finally
            {
                // Zamykanie połączenia z bazą master
                if (masterConnection != null && masterConnection.State != ConnectionState.Closed)
                {
                    masterConnection.Close();
                }
            }
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string connectionString = query; //questions.
            //Retrieves data from the database and stores it in the tbl object.
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(connectionString, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
