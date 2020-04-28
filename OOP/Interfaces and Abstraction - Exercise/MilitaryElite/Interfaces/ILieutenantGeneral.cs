using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        IReadOnlyList<IPrivate> Privates { get; }
    }
}
