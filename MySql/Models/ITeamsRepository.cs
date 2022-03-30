using System;
using System.Linq;

namespace MySql.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get;  }
    }
}
