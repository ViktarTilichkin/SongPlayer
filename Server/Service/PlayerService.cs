using Server.Repository;


namespace Server.Service
{
    public class PlayerService
    {
        private readonly SongRepository m_Service;
        public PlayerService(SongRepository rep)
        {
            new List<int>().Chunk(5);
            m_Service = rep ?? throw new ArgumentNullException(nameof(rep));
        }

        public async Task GetListSong() { }
        public async Task GetSongById(int idTrack) { }
    }
}
