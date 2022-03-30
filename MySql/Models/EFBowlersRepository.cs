﻿using System;
using System.Linq;

namespace MySql.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlersRepository(BowlingDbContext temp)
        {
            _context = temp;

        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        
    }
}
