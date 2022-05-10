using FootballClub.Models.Models.Player;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballClub.Services.Abstractions
{
    public interface IPlayerService
    {
        Task<PlayerExtendedModel> GetById(int id);

        Task<IEnumerable<PlayerBaseModel>> Get();

        Task<PlayerBaseModel> Insert(PlayerCreateModel model);

        Task<PlayerBaseModel> Update(PlayerUpdateModel model);

        Task<bool> Delete(int id);
    }
}
