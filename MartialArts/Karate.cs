using BecomeSifu.Controls;
using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BecomeSifu.MartialArts
{
    public class Karate : Arts, IDojo
    {
        public ICommand PracticeClick => new RelayCommand(() => Practice());

        public ICommand MeditateClick => new RelayCommand(() => Meditation());

        public ICommand AutoPracticeCheck => new RelayCommand(() => StartStopAutoPractice());

        public ICommand AutoMeditateCheck => new RelayCommand(() => StartStopAutoMeditate());

        public ICommand StartStopMeditationCommand => new RelayCommand(() => StartStopMeditation());

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

        public bool IsTaekwondo { get; } = false;

        public override void CalculateAttackGain()
        {
            decimal total = 0;
            foreach (Punches punch in Dojos.Punches)
            {
                total += punch.Step * punch.LevelInt * 1.1M;
            }
            foreach (Kicks kick in Dojos.Kicks)
            {
                total += kick.Step * kick.LevelInt * 1.1M;
            }
            foreach (Specials special in Dojos.Specials)
            {
                total += special.Step * 10 * special.LevelInt * 1.1M;
            }
            AttackGain = total;
        }

        public override decimal EnergyToUnlock(int step)
        {
            return (decimal)Math.Pow(10, step) * 1.5M;
        }

        public override void Meditation()
        {
            CalculateHealthGain();
            Health += HealthGain * 1.5M;
            HealthString = Health.ConvertToString();
            HealthGainString = (HealthGain * 1.5M).ConvertToString();

            CalculateEnergyGain();
            Energy += EnergyGain * 1.5M;
            EnergyString = Energy.ConvertToString();
            EnergyGainString = (EnergyGain * 1.5M).ConvertToString();

            Dojos.Dojo.Refresh();
            Extensions.UpdateActives();
        }
    }
}
