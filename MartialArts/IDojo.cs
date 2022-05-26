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
        bool IsBoxing { get; }
        bool CurrentArt { get; set; }

        decimal AttacksExpToNext(int step, decimal previousExp);
        decimal EnergyToUnlock(int step);

        decimal TotalSteps { get; set; }
        decimal TotalLevels { get; set; }


        decimal Energy { get; set; }
        decimal Exp { get; set; }
        decimal Attack { get; set; }
        decimal Defense { get; set; }
        decimal Health { get; set; }
        bool IsMeditating { get; set; }
        void Practice()
        {

        }
        void Meditate()
        {

        }
        void EmptyCup()
        {

        }

    }
}
