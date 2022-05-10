using AutoMapper;
using FootballClub.Data;
using FootballClub.Data.Entities;
using FootballClub.Models.Models.Club;
using FootballClub.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballClub.Services.Implementations
{
    public class ClubService : IClubService
    {
        private readonly FootballClubDbContext _context;
        private readonly IMapper _mapper;
        public ClubService(FootballClubDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(entity);
            return await SaveAsync() > 0;
        }

        public async Task<IEnumerable<ClubBaseModel>> Get()
        {
            var clubs = await _context.Clubs.ToListAsync();
            return _mapper.Map<IEnumerable<ClubBaseModel>>(clubs);
        }

        public async Task<ClubExtendedModel> GetById(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            return _mapper.Map<ClubExtendedModel>(club);
        }

       
        public async Task<ClubBaseModel> Insert(ClubCreateModel model)
        {
            var entity = _mapper.Map<Club>(model);

            await _context.Clubs.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<ClubBaseModel>(entity);
        }

        public async Task<ClubBaseModel> Update(ClubUpdateModel model)
        {
            var entity = await _context.Clubs.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Club not found");
            }
            _mapper.Map(model, entity);

            _context.Clubs.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<ClubBaseModel>(entity);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
