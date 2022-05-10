using AutoMapper;
using FootballClub.Data;
using FootballClub.Data.Entities;
using FootballClub.Models.Models.Player;
using FootballClub.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballClub.Services.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballClubDbContext _context;
        private readonly IMapper _mapper;
        public PlayerService(FootballClubDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Players.FindAsync(id);
            _context.Players.Remove(entity);
            return await SaveAsync() > 0;
        }

        public async Task<IEnumerable<PlayerBaseModel>> Get()
        {
            var players = await _context.Players.ToListAsync();
            return _mapper.Map<IEnumerable<PlayerBaseModel>>(players);
        }

        public async Task<PlayerExtendedModel> GetById(int id)
        {
            var player = await _context.Players.FindAsync(id);
            return _mapper.Map<PlayerExtendedModel>(player);
        }

        public async Task<PlayerBaseModel> Insert(PlayerCreateModel model)
        {
            var entity = _mapper.Map<Player>(model);

            await _context.Players.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<PlayerBaseModel>(entity);
        }

        public async Task<PlayerBaseModel> Update(PlayerUpdateModel model)
        {
            var entity = await _context.Players.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Player not found");
            }
            _mapper.Map(model, entity);

            _context.Players.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<PlayerBaseModel>(entity);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
