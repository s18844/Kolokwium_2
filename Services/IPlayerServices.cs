using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IPlayerServices
    {
        Championship_Team GetTeams(int id);

        void SetPlayer();
    }
}
