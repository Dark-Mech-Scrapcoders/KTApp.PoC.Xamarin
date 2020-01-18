using KTApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTApp.Core.Services
{
    public class HotStuffService
    {
        private readonly KillTeamContext _dbContext;

        public HotStuffService(KillTeamContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Faction>> GetFactions()
        {
            return await _dbContext.Factions
                .Include(x => x.FactionDatasheets)
                .ToListAsync();
        }

        public async Task<Faction> FindFaction(string name)
        {
            return await _dbContext.Factions
                .Where(x => x.Name == name)
                .Include(x => x.FactionDatasheets)
                .FirstOrDefaultAsync();
        }
    }
}
