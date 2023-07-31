using Server.Models;
using System.Text;
using MySqlConnector;

namespace Server.Repository
{
    public class UsersRepository
    {
        private readonly MySqlConnection m_Connection;
        private const string SQL_GET_ALL = "select Id, Name, Email, Pwd, Visual_theme from users;";
        private const string SQL_GET_BY_ID = "select Id, Name, Email, Pwd, Visual_theme from users where id = {0};";
        private const string SQL_GET_BY_Email = "select Id, Name, Email, Pwd, Visual_theme from users where Email = @email;";
        private const string SQL_CREATE = "insert into users(Name, Email, Pwd, Visual_theme) values(?, ?, ?, ?);";
        private const string SQL_UPDATE = "update users set Name = @name, Email = @email, Pwd = @pwd, Visual_theme = @thema  where email = @email;";
        private const string SQL_DELETE = "delete from users where id = {0};";
        public UsersRepository(MySqlConnection connect)
        {
            m_Connection = connect;
        }
        public async Task<List<UserEntity>> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);
                var reader = await command.ExecuteReaderAsync();
                List<UserEntity> files = new List<UserEntity>();
                while (reader.Read())
                {
                    files.Add(new UserEntity()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Pwd = reader.GetString(3),
                        VisualThema = reader.GetInt32(4)
                    });
                }
                return files;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }
        public async Task<UserEntity> GetById(int Id)
        {
            try
            {
                m_Connection.Open();
                var sql = string.Format(SQL_GET_BY_ID, string.Join("", Id));
                MySqlCommand command = new MySqlCommand(sql, m_Connection);
                var reader = await command.ExecuteReaderAsync();
                reader.Read();
                var result = new UserEntity()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Pwd = reader.GetString(3),
                    VisualThema = reader.GetInt32(4)
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }

        public async Task<UserEntity> GetByEmail(string Email)
        {
            try
            {
                m_Connection.Open();
                var sql = string.Format(SQL_GET_BY_Email, string.Join("", Email));
                MySqlCommand command = new MySqlCommand(sql, m_Connection);
                command.Parameters.AddWithValue($"@email", Email);
                var reader = await command.ExecuteReaderAsync();
                reader.Read();
                var result = new UserEntity()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Pwd = reader.GetString(3),
                    VisualThema = reader.GetInt32(4)
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }
        public void Create_SqlQuery(MySqlConnection conn, string script, params object[] item)
        {
            int startIndex = 0;
            int i = 0;
            var sb = new StringBuilder();
            while (startIndex < script.Length)
            {
                var endIndex = script.IndexOf('?', startIndex);
                if (endIndex == -1)
                {
                    sb.Append(script[startIndex..]);
                    break;
                }
                sb.Append(script[startIndex..endIndex]);
                sb.Append($"@pr{i++}");
                startIndex = endIndex + 1;
            }
            MySqlCommand command = new MySqlCommand(sb.ToString(), conn);
            for (i = 0; i < item.Length; i++)
            {
                command.Parameters.AddWithValue($"@pr{i}", item[i]);
            }
            command.ExecuteNonQuery();
        }
        public async Task<UserEntity> Create(UserEntity user)
        {
            try
            {
                m_Connection.Open();
                Create_SqlQuery(m_Connection, SQL_CREATE, user.Name, user.Email, user.Pwd, user.VisualThema);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }
        public async Task<UserEntity> Update(UserEntity user)
        {
            try
            {
                m_Connection.Open();
                var sql = string.Format(SQL_UPDATE, user.Email);
                MySqlCommand command = new MySqlCommand(sql, m_Connection);
                command.Parameters.AddWithValue($"@name", user.Name);
                command.Parameters.AddWithValue($"@email", user.Email);
                command.Parameters.AddWithValue($"@pwd", user.Pwd);
                command.Parameters.AddWithValue($"@thema", user.VisualThema);
                command.ExecuteNonQuery();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                m_Connection.Open();
                var sql = string.Format(SQL_DELETE, Id);
                MySqlCommand command = new MySqlCommand(sql, m_Connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_Connection.Close();
            }
        }
    }
}
