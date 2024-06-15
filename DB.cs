using System.Data.SqlClient;
using System.Data;
using System;

namespace DatabaseProject.Models
{
    public class DB
    {
        public SqlConnection connection;
        public DB()
        {
            string constring = "Data Source=Jana;Initial Catalog=PHMS;Integrated Security=True";
            connection = new SqlConnection(constring);
        }
        public DataTable ReadTable(string table_name)
        {
            DataTable dt = new DataTable();
            string query = "select medicine_id,medicine_name,quantity,dose,category,price from " + table_name;
            Console.WriteLine(query);
            if (connection.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            else
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
        }

        public DataTable Getmedicine(string medicine_id)
        {
            DataTable dt = new DataTable();
            string query = $"select medicine_id,medicine_name,quantity,dose,category,price from medicine where medicine_id ={medicine_id}  ";
            Console.WriteLine(query);
            if (connection.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            else
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                dt.Load(cmd.ExecuteReader());
                return dt;

            }
        }







        public string Insert(Medicine med)
        {
            string query = $"insert into medicine(medicine_id, medicine_name, quantity, dose, category,price) " +
                $"values('{med.medicine_id}', '{med.medicine_name}', '{med.quantity}', '{med.dose}','{med.category}','{med.price}')";

            SqlCommand cmd = new SqlCommand(query, connection);
            string res = "";    // this is for storing error messages (if any) and returning them from the function 

            try
            {
                if (connection.State == ConnectionState.Open)
                {


                    res = cmd.ExecuteNonQuery().ToString();


                }
                else
                {
                    connection.Open();
                    res = cmd.ExecuteNonQuery().ToString();

                }
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
                res = err.Message;
            }
            finally
            {
                connection.Close();
            }
            return res;
        }



        public string DeleteMedicine(string medicine_id)
        {
            string msg = "";
            string query = $"delete from medicine where medicine_id={medicine_id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
               


                if (connection.State == ConnectionState.Open)
                {


                    msg = cmd.ExecuteNonQuery().ToString();


                }
                else
                {
                    connection.Open();
                    msg = cmd.ExecuteNonQuery().ToString();

                }

            }
            catch (SqlException err)
            {
                msg = err.Message;
            }
            finally
            {
                connection.Close();
            }
            return msg;

        }


        public string Update(Medicine med)
        {
            string query = "update medicine set medicine_name=@medicine_name, " +
                "quantity=@quantity, dose=@dose, category=@category, price=@price where medicine_id=@medicine_id";

            SqlCommand cmd = new SqlCommand(query, connection);
            string res = "";

            try
            {
                int.TryParse(med.medicine_id, out int medicineId);
                int.TryParse(med.quantity, out int quantity);
                int.TryParse(med.dose, out int dose);
                int.TryParse(med.price, out int price);

                cmd.Parameters.AddWithValue("@medicine_id", medicineId);
                cmd.Parameters.AddWithValue("@medicine_name", med.medicine_name ?? string.Empty);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@dose", dose);
                cmd.Parameters.AddWithValue("@category", med.category ?? string.Empty);
                cmd.Parameters.AddWithValue("@price", price);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                res = cmd.ExecuteNonQuery().ToString();
            }
            catch (SqlException err)
            {
                res = err.Message;
            }
            finally
            {
                connection.Close();
            }
            return res;
        }
        


    }
}
