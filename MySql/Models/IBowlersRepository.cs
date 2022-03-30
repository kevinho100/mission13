using System;
using System.Linq;

namespace MySql.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }


    }
}

