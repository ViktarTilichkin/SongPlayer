using Server.Models;
using Server.Repository;

namespace Server.Service
{
    public class UserService
    {
        private readonly UsersRepository m_Service;
        public UserService(UsersRepository rep)
        {
            new List<int>().Chunk(5);
            m_Service = rep ?? throw new ArgumentNullException(nameof(rep));
        }
        public async Task<List<UserEntity>> GetAll()
        {
            return await m_Service.GetAll();
        }
        public async Task<UserEntity> GetById(int id)
        {
            return await m_Service.GetById(id);
        }
        public async Task<UserEntity> Create(RegUser user1)
        {
            UserEntity user = new UserEntity();
            user.Email = user1.Email;
            user.Name = user1.Name;
            user.Pwd = user1.Password;
            user.VisualThema = "";
            return await m_Service.Create(user);
        }
        public async Task<UserEntity> Update(UserEntity user)
        {
            return await m_Service.Update(user);
        }
        public async Task<bool> Delete(int id)
        {
            return await m_Service.Delete(id);
        }
    }
}
