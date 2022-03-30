using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySql.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFTeamsRepository (BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Team> Teams => _context.Teams.Include(x => x.TeamName);
    }
}

