using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;


namespace REF00013457.DAL
{
    public class ProductManager

        {
            private readonly string connectionString = "your_connection_string_here";

        public void Create(Product c)
        {
            var connection = new SQLiteConnection();
            try
            {
                var sql = $"INSERT INTO pt_product (pt_id_13457, pt_name_13457, pt_remaining_13457, pt_priority_13457, pt_purchase_level_13457, pt_price_13457) " +
                          $"VALUES ({c.Id}, '{c.Name}', {c.Remaining}, {c.Priority}, {c.PurchaseLevel}, {c.Price})";
                var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }


        public void Update(Product c)
        {
            var connection = new SQLiteConnection(connectionString);
            try
            {
                var sql = $"UPDATE pt_product SET pt_name_13457 = '{c.Name}', pt_remaining_13457 = {c.Remaining}, pt_priority_13457 = {c.Priority}, pt_purchase_level_13457 = {c.PurchaseLevel}, pt_price_13457 = {c.Price} WHERE pt_id_13457 = {c.Id}";
                var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        public void Delete(int pt_id_13457)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    var sql = $"DELETE FROM pt_product WHERE pt_id_13457 = {pt_id_13457}";
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Product GetById(int pt_id_13457)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    var sql = $"SELECT * FROM pt_product WHERE pt_id_13457 = {pt_id_13457}";
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var p = new Product
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Name = Convert.ToString(reader.GetValue(1)),
                            Remaining = Convert.ToInt32(reader.GetValue(2)),
                            Priority = Convert.ToInt32(reader.GetValue(3)),
                            PurchaseLevel = Convert.ToInt32(reader.GetValue(4)),
                            Price = Convert.ToDecimal(reader.GetValue(5))
                        };
                        return p;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }


        public List<Product> GetAll()
        {
            var result = new List<Product>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    var sql = "SELECT * FROM pt_product";
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var p = new Product
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Name = Convert.ToString(reader.GetValue(1)),
                            Remaining = Convert.ToInt32(reader.GetValue(2)),
                            Priority = Convert.ToInt32(reader.GetValue(3)),
                            PurchaseLevel = Convert.ToInt32(reader.GetValue(4)),
                            Price = Convert.ToDecimal(reader.GetValue(5))
                        };
                        result.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
    }
}
