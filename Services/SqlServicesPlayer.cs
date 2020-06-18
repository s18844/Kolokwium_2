using Kolokwium2.Models;
using Kolokwium2.Wyjatki;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class SqlServicesPlayer : IPlayerServices
    {
        private readonly PlayerContext _context;

        public SqlServicesPlayer(PlayerContext context)
        {
            _context = context;
        }

        public Championship_Team GetTeams(int id)
        {   
            
            var result = _context.Championship_Teams.Include(e => e.IdChampionship).SingleOrDefault(e => e.IdChampionship == id);
            if (result == null)
            {
                throw new DoNotFoundPlayer($"Wystapil blad i tutaj odpowiedni komunikat");
            }
            //Sortowanie
          //  result.Score = result.Championship.OrderByDescending(e => e.Order).ToList();
            return result;
        }

        public void SetPlayer()
        {
            //Problem z internetem znowu przez burze ... brak czasu na skonczenie
            throw new NotImplementedException();
        }
    }
}
