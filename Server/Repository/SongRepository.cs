using MySqlConnector;
using Server.Models;
using System.Text.Json;
using System.Text;

namespace Server.Repository
{
    public class SongRepository
    {
        private readonly MySqlConnection m_Connection;
        private const string SQL_GET_ALL = "select Id, Name, Singer, Path, Owner_id, Genre_id, TypeFile_id, SongStatus_id  from Songs;";
        private const string SQL_GET_ByID = "select Id, Name, Singer, Path, Owner_id, Genre_id, TypeFile_id, SongStatus_id  from Songs where Id = @Id;";
        private const string SQL_CREATE = "insert into songs(Name, Singer, Path, Owner_id, Genre_id, TypeFile_id, SongStatus) values(?, ?, ?, ?, ?);";
        private const string SQL_UPDATE = "update Songs set Name = @name, User_id = @user, Genre_id = @genre_id, SongStatus_id = @SongStatus_id where Id = @Id;";
        private const string SQL_DELETE = "delete from Songs where id = ?;";// переделать на ?
        public SongRepository(MySqlConnection connect)
        {
            m_Connection = connect;
        }
        //public async Task<List<SongEntity>> GetAll()
        //{
        //    try
        //    {
        //        m_Connection.Open();
        //        MySqlCommand command = new MySqlCommand(SQL_GET_ALL, m_Connection);
        //        var reader = await command.ExecuteReaderAsync();
        //        List<SongEntity> files = new List<SongEntity>();
        //        while (reader.Read())
        //        {
        //            files.Add(new SongEntity()
        //            {
        //                Id = reader.GetInt32(0),
        //                Name = reader.GetString(1),
        //                Singer = reader.GetString(2),
        //                Path = reader.GetString(3),
        //                OwnerId = reader.GetInt32(4),
        //                GenreId = reader.GetInt32(5),
        //                TypeFileId = reader.GetInt32(6),
        //                SongStatusId = reader.GetInt32(7),
        //            });
        //        }
        //        return files;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        m_Connection.Close();
        //    }
        //}
        //private void Create_SqlQuery(MySqlConnection conn, string script, params object[] item)
        //{
        //    int startIndex = 0;
        //    int i = 0;
        //    var sb = new StringBuilder();
        //    while (startIndex < script.Length)
        //    {
        //        var endIndex = script.IndexOf('?', startIndex);
        //        if (endIndex == -1)
        //        {
        //            sb.Append(script[startIndex..]);
        //            break;
        //        }
        //        sb.Append(script[startIndex..endIndex]);
        //        sb.Append($"@pr{i++}");
        //        startIndex = endIndex + 1;
        //    }
        //    MySqlCommand command = new MySqlCommand(sb.ToString(), conn);
        //    for (i = 0; i < item.Length; i++)
        //    {
        //        command.Parameters.AddWithValue($"@pr{i}", item[i]);
        //    }
        //    command.ExecuteNonQuery();
        //}
        //public async Task<SongEntity> Create(SongEntity song)
        //{
        //    try
        //    {
        //        m_Connection.Open();
        //        Create_SqlQuery(m_Connection, SQL_CREATE, song.Name, song.UserId, ConvToJson(song.Description));
        //        return song;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        m_Connection.Close();
        //    }
        //}
        ////public async Task<SongEntity> Update(SongEntity song)
        ////{
        ////    try
        ////    {
        ////        m_Connection.Open();
        ////        var sql = string.Format(SQL_UPDATE, song.Id);
        ////        MySqlCommand command = new MySqlCommand(sql, m_Connection);
        ////        command.Parameters.AddWithValue($"@name", song.Name);
        ////        command.Parameters.AddWithValue($"@user", song.UserId);
        ////        command.Parameters.AddWithValue($"@description", ConvToJson(song.Description));
        ////        command.ExecuteNonQuery();
        ////        return song;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw ex;
        ////    }
        ////    finally
        ////    {
        ////        m_Connection.Close();
        ////    }
        ////}
        //public async Task<bool> Delete(int Id)
        //{
        //    try
        //    {
        //        m_Connection.Open();
        //        var sql = string.Format(SQL_DELETE, Id);
        //        MySqlCommand command = new MySqlCommand(sql, m_Connection);
        //        command.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        m_Connection.Close();
        //    }
        //}
    }
}
