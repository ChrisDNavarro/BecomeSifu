using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public interface IDojo
    {
        Dictionary<int, string> Punches { get; }
        Dictionary<int, string> Kicks { get; }
        Dictionary<int, string> Specials { get; }
        Dictionary<int, string> Defenses { get; }

    }
}
