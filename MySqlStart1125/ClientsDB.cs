using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MySqlStart1125
{
    internal class ClientsDB
    {
        MySqlConnection connection;

        internal void SetConnection(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public bool Insert(Client client)
        {
            bool result = false;
            if (connection == null)
                return result;

            connection.Open();
            
            MySqlCommand cmd = new MySqlCommand("insert into `Clients` Values (0, @fname, @lname);select LAST_INSERT_ID();",
                 connection);
            // путем добавления значений в запрос через параметры мы используем экранирование опасных символов
            cmd.Parameters.Add(new MySqlParameter("fname", client.FirstName));

            // можно указать параметр через отдельную переменную
            MySqlParameter lname = new MySqlParameter("lname", client.LastName);
            cmd.Parameters.Add(lname);
            try
            {
                // выполняем запрос через ExecuteScalar, получаем id вставленной записи
                // если нам не нужен id, то в запросе убираем часть select LAST_INSERT_ID(); и выполняем команду через ExecuteNonQuery
                int id = (int)(ulong)cmd.ExecuteScalar();
                if (id > 0)
                {
                    MessageBox.Show(id.ToString());
                    // назначаем полученный id обратно в объект для дальнейшей работы
                    client.ID = id;
                    result = true;
                }
                else
                {
                    MessageBox.Show("Запись не добавлена");
                }
            }
            catch (Exception ex)
            {           
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return result;
        }

        internal List<Client> SelectAll()
        {
            List<Client> clients = new List<Client>();
            if (connection == null)
                return clients;

            connection.Open();
            var command = new MySqlCommand("select `id`, `Fname`, `Lname` from `Clients` ", connection);
            try
            {
                // выполнение запроса, который возвращает результат-таблицу
                MySqlDataReader dr = command.ExecuteReader();
                // в цикле читаем построчно всю таблицу
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string fname = string.Empty;
                    // проверка на то, что столбец имеет значение
                    if (!dr.IsDBNull(1))
                        fname = dr.GetString("Fname");
                    string lname = dr.GetString("Lname");
                    clients.Add(new Client
                    {
                        ID = id,
                        FirstName = fname,
                        LastName = lname
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return clients;
        }

        internal bool Update(Client edit)
        {
            bool result = false;    
            if (connection == null)
                return result;

            connection.Open();
            var mc = new MySqlCommand($"update `Clients` set `Fname`=@fname, `Lname`=@lname where `id` = {edit.ID}" , connection);
            mc.Parameters.Add(new MySqlParameter("fname", edit.FirstName));
            mc.Parameters.Add(new MySqlParameter("lname", edit.LastName));

            try
            {
                mc.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return result;
        }


        internal bool Remove(Client remove)
        {
            bool result = false;
            if (connection == null)
                return result;
            
            connection.Open();
            var mc = new MySqlCommand($"delete from `Clients` where `id` = {remove.ID}", connection);
            try
            {
                mc.ExecuteNonQuery ();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return result;
        }
    }
}
