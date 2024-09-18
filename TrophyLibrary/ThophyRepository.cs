using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLibrary
{
    public class ThophyRepository
    {
        private int _nextId = 1;
        private readonly List<Trophy> _trophies = new();

        public IEnumerable<Trophy> Get(int? year = null, string? competitionName = null, string? orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);
            if (year != null)
            {
                result = result.Where(t => t.Year == year);
            }
            if (competitionName != null)
            {
                result = result.Where(t => t.Competition.Contains(competitionName));
            }
            if (orderBy != null)
            {
                result = orderBy.ToLower() switch
                {
                    "year" => result.OrderBy(t => t.Year),
                    "competition" => result.OrderBy(t => t.Competition),
                    _ => throw new ArgumentException("Invalid orderBy value", nameof(orderBy))

                };
            }
            return result;
        }

    }
}
