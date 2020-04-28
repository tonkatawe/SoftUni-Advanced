using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public interface IRepair
    {
        string Part { get; }
        int Hours { get; }
    }
}
