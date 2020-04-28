using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public interface ICommando
    {
        IReadOnlyList<Mission> Missions { get; }
    }
}
