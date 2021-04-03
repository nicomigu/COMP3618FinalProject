using SamuraiApp.Domain;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ISamuraiRepo
    {
        IEnumerable<Samurai> GetAllSamurai();
        Samurai GetSamuraiById(int id);
        void UpdateSamurai(int id, string Name, int Age, string Town);
        void AddSamuraiToBattle(int SamuraiId, int BattleId);
    }
}
