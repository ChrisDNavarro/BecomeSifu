using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BecomeSifu.Controls;
using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;

namespace BecomeSifu.MartialArts
{
    public class Taekwondo : Arts, IDojo
    {
        public ICommand PracticeClick => new RelayCommand(() => Practice());

        public ICommand MeditateClick => new RelayCommand(() => Meditation());

        public ICommand AutoPracticeCheck => new RelayCommand(() => StartStopAutoPractice());

        public ICommand AutoMeditateCheck => new RelayCommand(() => StartStopAutoMeditate());

        public ICommand StartStopMeditationCommand => new RelayCommand(() => StartStopMeditation());

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

        private List<string> _DefensesList = new List<string>{
            "Inside block",
            "Otside block",
            "Palm Block",
            "Scissors block",
            "9 Shaped block"
        };

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
            for (int i = 0; i < Perk.Count; i++)
            {
                Perks.Add(new Perk(i, false));
            }
        }

        public bool IsBoxing { get; } = false;

        public override void CalculateDefenseGain()
        {
            foreach (Defenses defense in Dojos.Defenses)
            {
                DefenseGain = defense.Step * Convert.ToDecimal(defense.LevelInt) * 9.9M;
            }
        }

    }
}
