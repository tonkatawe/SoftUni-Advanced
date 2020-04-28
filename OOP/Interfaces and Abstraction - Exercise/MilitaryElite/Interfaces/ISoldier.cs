using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface ISoldier
    {
        string FirstName { get; }
        string LastName { get; }
        int Id { get; }
    }
}
