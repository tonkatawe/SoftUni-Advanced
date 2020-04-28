using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public interface IMission
    {
        string Name { get; }
        string State { get; }
        void CompleteMission();
    }
}
