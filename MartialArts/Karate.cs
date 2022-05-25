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
             "Jab Punch",
            "Lunge Punch",
            "Rising punch",
            "Hook punch",
            "Back Fist Strike",
            "Finger Thrust",
            "Ridge Hand",
            "Two Handed Punch",
            "Circular Punch",
            "Scissor Punch"
        };

        public Dictionary<int, string> Defenses { get; } = new Dictionary<int, string>();

        private List<string> _DefensesList = new List<string>{
            "Side block",
            "Inside circular block",
            "Sweeping block",
            "Bow & Arrow block",
            "Tiger Mouth"
        };

        public Dictionary<int, string> Kicks { get; } = new Dictionary<int, string>();

        private List<string> _KicksList = new List<string>{
            "Front kick (snap)",
            "Front kick (thrust)",
            "Back kick",
            "Round kick",
            "Jump kick",
            "Swing kick",
            "Side kick (snap)",
            "Side kick (thrust)",
            "Heel drop",
            "Stomp"
        };

        public Dictionary<int, string> Specials { get; } = new Dictionary<int, string>();

        private List<string> _SpecialsList = new List<string>{
            "Double Front Kick",
            "Mountain Punch",
            "Eagle Hand",
            "Sweep The Leg",
            "Crane Kick"
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
