using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using BecomeSifu.ViewModels;

namespace BecomeSifu.MartialArts
{
    public class Taekwondo : ArtsAbstract
    {
        public override CommandAbstract PracticeClick => new RelayCommand(x => Practice());

        public override CommandAbstract MeditateClick => new RelayCommand(x => Meditation());

        public override CommandAbstract AutoPracticeCheck => new RelayCommand(x => StartStopAutoPractice());

        public override CommandAbstract AutoMeditateCheck => new RelayCommand(x => StartStopAutoMeditate());

        public override CommandAbstract StartStopMeditationCommand => new RelayCommand(x => StartStopMeditation());

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
            try
            {
                Punches = _PunchesList;
                Kicks = _KicksList;
                Specials = _SpecialsList;
                Defenses = _DefensesList;
                for (int i = 0; i < Perk.Count; i++)
                {
                    Perks.Add(new Perk(i, false));
                }

                LogIt.Write($"Built dictionaries");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public override bool IsBoxing { get; } = false;

       

        public override void CalculateDefenseGain()
        {
            try
            {
                foreach (ActionsViewModel defense in PageHolder.MainWindow.DojoState.Defenses)
                {
                    DefenseGain += defense.Step * Convert.ToDecimal(defense.LevelInt) * .09M;
                }
                LogIt.Write();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

    }
}
