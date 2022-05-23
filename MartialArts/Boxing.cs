using BecomeSifu.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public class Boxing : Arts, IDojo
    {
        private Dictionary<int, string> _Punches = new Dictionary<int, string>();
        public Dictionary<int, string> Punches { get => _Punches; }

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

        private Dictionary<int, string> _Defenses = new Dictionary<int, string>();
        public Dictionary<int, string> Defenses { get => _Defenses; }

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

        private Dictionary<int, string> _Kicks = new Dictionary<int, string>();
        public Dictionary<int, string> Kicks { get => _Kicks; }

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

        private Dictionary<int, string> _Specials = new Dictionary<int, string>();
        public Dictionary<int, string> Specials { get => _Specials; }

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

        public Boxing()
        {
            for (int i = 0; i < _PunchesList.Count; i++)
            {
                _Punches[i] = _PunchesList[i];
            }
            for (int i = 0; i < _KicksList.Count; i++)
            {
                _Kicks[i] = _KicksList[i];
            }
            for (int i = 0; i < _SpecialsList.Count; i++)
            {
                _Specials[i] = _SpecialsList[i];
            }
            for (int i = 0; i < _DefensesList.Count; i++)
            {
                _Defenses[i] = _DefensesList[i];
            }
        }
    }
}
