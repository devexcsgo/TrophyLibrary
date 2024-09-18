using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TrophyLibrary
{
    public class ThophyRepository
    {
        private int _nextId = 1;
        private readonly List<Trophy> _trophies = new();

        public ThophyRepository()
        {
            _trophies.Add(new Trophy { Id = 1, Competition = "World Cup", Year = 1974 });
            _trophies.Add(new Trophy { Id = 2, Competition = "World Cup", Year = 1978 });
            _trophies.Add(new Trophy { Id = 3, Competition = "World Cup", Year = 1982 });
            _trophies.Add(new Trophy { Id = 4, Competition = "World Cup", Year = 1986 });
            _trophies.Add(new Trophy { Id = 5, Competition = "World Cup", Year = 1990 });
            _trophies.Add(new Trophy { Id = 6, Competition = "World Cup", Year = 1994 });
            _trophies.Add(new Trophy { Id = 7, Competition = "World Cup", Year = 1998 });
            _trophies.Add(new Trophy { Id = 8, Competition = "World Cup", Year = 2002 });
            _trophies.Add(new Trophy { Id = 9, Competition = "World Cup", Year = 2006 });
            _trophies.Add(new Trophy { Id = 10, Competition = "World Cup", Year = 2010 });
            _trophies.Add(new Trophy { Id = 11, Competition = "World Cup", Year = 2014 });
            _trophies.Add(new Trophy { Id = 12, Competition = "World Cup", Year = 2018 });
            _trophies.Add(new Trophy { Id = 13, Competition = "World Cup", Year = 2022 });
        }

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
        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }
        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }
            _trophies.Remove(trophy);
            return trophy;
        }
        public Trophy? Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }
            existingTrophy.Competition = trophy.Competition;
            existingTrophy.Year = trophy.Year;
            return existingTrophy;
        }

    }
}
