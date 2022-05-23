using BecomeSifu.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public class Karate : Arts, IDojo
    {
        public Dictionary<int, string> Punches { get; } = new Dictionary<int, string>();

        private List<string> _PunchesList = new List<string>{
            "Forefist",
            "Hammerfist",
            "Backfist",
            "Knifehand",
            "FourKknuckleStrike",
            "EagleStrike",
            "TigerClaw",
            "PincerHand",
            "ScissorFinger",
            "ChestnutFist"
        };

        public Dictionary<int, string> Defenses { get; } = new Dictionary<int, string>();

        private List<string> _DefensesList = new List<string>{
            "Forefist",
            "Hammerfist",
            "Backfist",
            "Knifehand",
            "FourKknuckleStrike",
            "EagleStrike",
            "TigerClaw",
            "PincerHand",
            "ScissorFinger",
            "ChestnutFist"
        };

        public Dictionary<int, string> Kicks { get; } = new Dictionary<int, string>();

        private List<string> _KicksList = new List<string>{
            "Forefist",
            "Hammerfist",
            "Backfist",
            "Knifehand",
            "FourKknuckleStrike",
            "EagleStrike",
            "TigerClaw",
            "PincerHand",
            "ScissorFinger",
            "ChestnutFist"
        };

        public Dictionary<int, string> Specials { get; } = new Dictionary<int, string>();

        private List<string> _SpecialsList = new List<string>{
            "Forefist",
            "Hammerfist",
            "Backfist",
            "Knifehand",
            "FourKknuckleStrike",
            "EagleStrike",
            "TigerClaw",
            "PincerHand",
            "ScissorFinger",
            "ChestnutFist"
        };

        public Karate()
        {
            for (int i = 0; i < _PunchesList.Count; i++)
            {
                Punches[i] = _PunchesList[i];
            }
            for (int i = 0; i < _KicksList.Count; i++)
            {
                Kicks[i] = _KicksList[i];
            }
            for (int i = 0; i < _SpecialsList.Count; i++)
            {
                Specials[i] = _SpecialsList[i];
            }
            for (int i = 0; i < _DefensesList.Count; i++)
            {
                Defenses[i] = _DefensesList[i];
            }
        }

        public bool IsBoxing { get; } = false;
    }
}
