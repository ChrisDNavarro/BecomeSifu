using BecomeSifu.Abstracts;
using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace BecomeSifu.MartialArts
{
    public class Karate : ArtsAbstract
    {
        public override CommandAbstract PracticeClick => new RelayCommand(x => Practice());

        public override CommandAbstract MeditateClick => new RelayCommand(x => Meditation());

        public override CommandAbstract AutoPracticeCheck => new RelayCommand(x => StartStopAutoPractice());

        public override CommandAbstract AutoMeditateCheck => new RelayCommand(x => StartStopAutoMeditate());

        public override CommandAbstract StartStopMeditationCommand => new RelayCommand(x => StartStopMeditation());

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

        private List<string> _DefensesList = new List<string>{
            "Side block",
            "Inside circular block",
            "Sweeping block",
            "Bow & Arrow block",
            "Tiger Mouth"
        };

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

        private List<string> _SpecialsList = new List<string>{
            "Double Front Kick",
            "Mountain Punch",
            "Eagle Hand",
            "Sweep The Leg",
            "Crane Kick"
        };

        public Karate()
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

        public override decimal EnergyToUnlock(int step)
        {
            try
            {
                LogIt.Write();
                return (decimal)Math.Pow(10, step) * 1.5M;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }


    }
}
