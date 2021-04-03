using SamuraiApp.Domain;
using System;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IBattleRepo
    {
        IEnumerable<Battle> GetAllBattle();
        Battle GetBattleById(int id);
        void UpdateBattle(int id, string Name, DateTime Date, string City, string Country);       

    }
}
