using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace lab13_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_to_db = Path.GetFullPath("../../../lab13_14/PhoneBook_db.mdf");
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path_to_db + ";Trusted_Connection=Yes;MultipleActiveResultSets=True";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
            }

            List<Contact> contacts_in_list = ShowDB(connection);

            if (CheckIfKeyIsInDB(connection, "Belka")) {
                Delete(connection, "Belka");
                ShowDB(connection);
            }
            
            Add(connection, "Belka", "+375444654455");
            ShowDB(connection);

            Update(connection, "Belka", "Belka", "123");
            ShowDB(connection);

            if (CheckIfKeyIsInDB(connection, "Aleks"))
            {
                Delete(connection, "Aleks");
                ShowDB(connection);
            }
            Add(connection, "Aleks", "987");

            contacts_in_list = ShowDB(connection);

            Console.WriteLine("\nWe will use data from db without connection using DataSet:");

            string sql = "SELECT * FROM Contacts";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            
            connection.Close();
            Console.WriteLine("Connection closed, but we still have data, and we can operate with it\n");
            
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine(dt.TableName);
                foreach (DataColumn column in dt.Columns)
                {
                    Console.Write("{0}\t", column.ColumnName);
                }
                Console.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                    {
                        Console.Write("{0}\t", cell);
                    }
                    Console.WriteLine();
                }
            }

            Console.Read();
        }

        static bool CheckIfKeyIsInDB(SqlConnection connection, string who)
        {
            string sql_check_count = "SELECT COUNT(*) from Contacts WHERE ([Name] = @who)";
            SqlCommand checker = new SqlCommand(sql_check_count, connection);
            checker.Parameters.AddWithValue("@who", who);

            return (int)checker.ExecuteScalar() > 0;
            // int number_of_keys = (Int32)checker.ExecuteScalar();
            // return number_of_keys >= 1;
        }

        static void Update(SqlConnection connection, string who, string new_name, string new_number)
        {
            string sqlExpression = String.Format("UPDATE Contacts SET Name='{0}', Number='{1}' WHERE Name='{2}'", new_name, new_number, who);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("\n updated: {0}", number);
        }

        static void Add(SqlConnection connection, string new_name, string new_number)
        {
            string sqlExpression = String.Format("INSERT INTO Contacts (Name, Number) VALUES ('{0}', '{1}')", new_name, new_number);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("\n added: {0}", number);
        }

        static void Delete(SqlConnection connection, string who)
        {
            string sqlExpression = String.Format("DELETE  FROM Contacts WHERE Name='{0}'", who);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("\n deleted: {0}", number);
        }

        static List<Contact> ShowDB(SqlConnection connection)
        {
            List<Contact> contacts = new List<Contact>();
            string sqlExpression = "SELECT * FROM Contacts";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("\nContacts");
            if (reader.HasRows)
            {
                Console.WriteLine("{0} \t{1}", reader.GetName(0), reader.GetName(1));

                while (reader.Read())
                {
                    object name = reader.GetValue(0);
                    object number = reader.GetValue(1);
                    contacts.Add(new Contact(name.ToString(), number.ToString()));
                    Console.WriteLine("{0} \t{1}", name, number);
                }
            }
            reader.Close();
            return contacts;
        }
    }
}
