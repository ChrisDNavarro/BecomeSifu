using System;
using System.Collections.Generic;
using System.Text;
using BecomeSifu.Controls;
using BecomeSifu.Objects;

namespace BecomeSifu.MartialArts
{
    public class Taekwondo : Arts, IDojo
    {
        private Dictionary<int, string> _Punches = new Dictionary<int, string>();
        public Dictionary<int, string> Punches { get => _Punches;}

        private List<string> _PunchesList = new List<string>{
            "Fore fist",
            "Hammer fist",
            "Back fist",
            "Knifehand",
            "Four Kknuckle Strike",
            "Eagle Strike",
            "Tiger Claw",
            "Pincer Hand",
            "Scissor Finger",
            "Chestnut Fist"
        };

        private Dictionary<int, string> _Defenses = new Dictionary<int, string>();
        public Dictionary<int, string> Defenses { get => _Defenses; }

        private List<string> _DefensesList = new List<string>{
            "Fore fist",
            "Hammer fist",
            "Back fist",
            "Knifehand",
            "Four Kknuckle Strike",
            "Eagle Strike",
            "Tiger Claw",
            "Pincer Hand",
            "Scissor Finger",
            "Chestnut Fist"
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

        private Dictionary<int, string> _Specials = new Dictionary<int, string>();
        public Dictionary<int, string> Specials { get => _Specials; }

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
