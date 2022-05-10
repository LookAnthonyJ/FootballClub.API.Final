using FootballClub.Models.Models.Club;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballClub.Services.Abstractions
{
    public interface IClubService
    {
        Task<ClubExtendedModel> GetById(int id);

        Task<IEnumerable<ClubBaseModel>> Get();

        Task<ClubBaseModel> Insert(ClubCreateModel model);

        Task<ClubBaseModel> Update(ClubUpdateModel model);

        Task<bool> Delete(int id);
    }
}
