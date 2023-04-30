using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<Private> Privates { get; }
    }
}
