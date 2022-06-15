using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public class Boxing : ArtsAbstract
    {
        public override CommandAbstract PracticeClick => new RelayCommand(x => Practice());

        public override CommandAbstract MeditateClick => new RelayCommand(x => Meditation());

        public override CommandAbstract AutoPracticeCheck => new RelayCommand(x => StartStopAutoPractice());

        public override CommandAbstract AutoMeditateCheck => new RelayCommand(x => StartStopAutoMeditate());

        public override CommandAbstract StartStopMeditationCommand => new RelayCommand(x => StartStopMeditation());

        private List<string> _PunchesList = new List<string>{
            "Jab",
            "Cross",
            "Lead Hook",
            "Rear Hook",
            "Lead Uppercut",
            "Rear Uppercut"
        };

        private List<string> _DefensesList = new List<string>{
            "FootWork",
            "Guard",
            "Slip",
            "Parry",
            "Counter"
        };

        /// <summary>
        /// To The Body for Boxing
        /// </summary>
        private List<string> _KicksList = new List<string>{
            "Body Blows",
        };

        private List<string> _SpecialsList = new List<string>{
            "1 2",
            "1 2 3",
            "3 4 3 4",
            "1 2 5 2",
            "1 6 3 2"
        };

        public Boxing()
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

        public override bool IsBoxing { get; } = true;
    }
}
