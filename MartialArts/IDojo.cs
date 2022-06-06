using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BecomeSifu.MartialArts
{
    public interface IDojo
    {
        Dictionary<int, string> Punches { get; }
        Dictionary<int, string> Kicks { get; }
        Dictionary<int, string> Specials { get; }
        Dictionary<int, string> Defenses { get; }
        bool IsBoxing { get; }
        bool IsTaekwondo { get; }
        bool CurrentArt { get; set; }
        decimal AttackSpeedModifier { get; set; }
        void UpdateBonuses(List<int> bonuses);

        decimal AttacksExpToNext(int step, int level);
        decimal EnergyToUnlock(int step);

        ICommand PracticeClick { get; }
        ICommand MeditateClick { get; }
        ICommand AutoPracticeCheck { get; }

        ICommand AutoMeditateCheck { get; }
        ICommand StartStopMeditationCommand { get; }

        void Practice();
        void CalculateAll();
        void CalculateHealthGain();
        void CalculateDefenseGain();
        void CalculateAttackGain();
        void CalculateExpGain();
        void CalculateEnergyGain();
        void StartStopMeditation();
        void Meditation();
        void StartStopAutoPractice();
        void Timer_Tick(object source, EventArgs e);
        void StartStopAutoMeditate();
        void MeditateTimer_Tick(object source, EventArgs e);


        decimal TotalSteps { get; set; }
        decimal TotalLevels { get; set; }


        decimal Energy { get; set; }
        decimal EnergyGain { get; set; }
        string EnergyString { get; set; }
        string EnergyGainString { get; set; }

        decimal Exp { get; set; }
        decimal ExpGain { get; set; }
        string ExpString { get; set; }
        string ExpGainString { get; set; }

        decimal Attack { get; set; }
        decimal AttackGain { get; set; }
        string AttackString { get; set; }
        string AttackGainString { get; set; }


        decimal Defense { get; set; }
        decimal DefenseGain { get; set; }
        string DefenseString { get; set; }
        string DefenseGainString { get; set; }

        decimal Health { get; set; }
        decimal HealthGain { get; set; }
        string HealthString { get; set; }
        string HealthGainString { get; set; }

        bool IsMeditating { get; set; }
        Visibility MeditateOption { get; set; }
        string IsMeditatingString { get; set; }
        bool AutoMeditate { get; set; }
        bool AutoPractice { get; set; }
        Visibility CanAutoMeditate { get; set; }
        Visibility CanAutoPractice { get; set; }
        decimal Multiplier { get; set; }
        string Rate { get; set; }
        DispatcherTimer Timer { get; set; }
        DispatcherTimer MeditateTimer { get; set; }

    }
}
