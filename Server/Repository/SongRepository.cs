using MySqlConnector;
using Server.Models;
using System.Text.Json;
using System.Text;

namespace Server.Repository
{
    public class SongRepository
    {
        private readonly MySqlConnection m_Connection;
        private const string SQL_GET_ALL = "select Id, Name, Singer, Path, Owner_id, Genre_id, Visibility  from PlayList;";
        private const string SQL_CREATE = "insert into users(Name, Singer, Path, Owner_id, Genre_id, Visibility) values(?, ?, ?, ?);";
        private const string SQL_UPDATE = "update PlayList set Name = @name, User_id = @user, Description = @description where Id = @Id;";
        private const string SQL_DELETE = "delete from PlayList where id = {0};";// переделать на ?
        public SongRepository(MySqlConnection connect)
        {
            m_Connection = connect;
        }
        public async Task<List<PlayList>> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);
                var reader = await command.ExecuteReaderAsync();
                List<PlayList> files = new List<PlayList>();
                while (reader.Read())
                {
                    files.Add(new PlayList()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        UserId = Convert.ToInt32(reader.GetString(2)),
                        Description = ConvToData(reader.GetString(3))
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
        private void Create_SqlQuery(MySqlConnection conn, string script, params object[] item)
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
        public async Task<PlayList> Create(PlayList playList)
        {
            try
            {
                m_Connection.Open();
                Create_SqlQuery(m_Connection, SQL_CREATE, playList.Name, playList.UserId, ConvToJson(playList.Description));
                return playList;
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
        public async Task<PlayList> Update(PlayList playList)
        {
            try
            {
                m_Connection.Open();
                var sql = string.Format(SQL_UPDATE, playList.Id);
                MySqlCommand command = new MySqlCommand(sql, m_Connection);
                command.Parameters.AddWithValue($"@name", playList.Name);
                command.Parameters.AddWithValue($"@user", playList.UserId);
                command.Parameters.AddWithValue($"@description", ConvToJson(playList.Description));
                command.ExecuteNonQuery();
                return playList;
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
        private string ConvToJson(List<Description> Description)
        {
            string result = "";
            result += JsonSerializer.Serialize(Description);
            return result;
        }
        private List<Description> ConvToData(string json)
        {
            List<Description> descriptions = JsonSerializer.Deserialize<List<Description>>(json);
            return descriptions;
        }
    }
}
