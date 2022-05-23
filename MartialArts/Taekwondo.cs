using System;
using System.Collections.Generic;
using System.Text;
using BecomeSifu.Controls;
using BecomeSifu.Objects;

namespace BecomeSifu.MartialArts
{
    public class Taekwondo : Arts, IDojo
    {
        public Dictionary<int, string> Punches { get; } = new Dictionary<int, string>();

        private List<string> _PunchesList = new List<string>{
            "Fore fist",
            "Hammer fist",
            "Back fist",
            "Knifehand",
            "Four Knuckle Strike",
            "Eagle Strike",
            "Tiger Claw",
            "Pincer Hand",
            "Scissor Finger",
            "Chestnut Fist"
        };

        public Dictionary<int, string> Defenses { get; } = new Dictionary<int, string>();

        private List<string> _DefensesList = new List<string>{
            "Inside block",
            "Otside block",
            "Palm Block",
            "Scissors block",
            "9 Shaped block"
        };

        private Dictionary<int, string> _Kicks = new Dictionary<int, string>();
        public Dictionary<int, string> Kicks { get => _Kicks; }

        private List<string> _KicksList = new List<string>{
            "Front Kick",
            "Side Kick",
            "Roundhouse Kick",
            "Back Kick",
            "Crescent Kick",
            "Hook Kick",
            "Reverse Turning Kick",
            "Axe Kick",
            "Scissor Kick",
            "Flying Side Kick"
        };

        public Dictionary<int, string> Specials { get; } = new Dictionary<int, string>();

        private List<string> _SpecialsList = new List<string>{
            "Flying Side Kick",
            "Tornado Kick",
            "540 Kick",
            "720 Kick",
            "Triple Aero Kicks"
        };

        public Taekwondo()
        {
            for (int i = 0; i < _PunchesList.Count; i++ )
            {
                Punches[i] = _PunchesList[i];
            }
            for (int i = 0; i < _KicksList.Count; i++)
            {
                _Kicks[i] = _KicksList[i];
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
