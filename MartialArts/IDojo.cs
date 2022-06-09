using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Perk> Perks { get; }
        bool IsBoxing { get; }
        bool CurrentArt { get; set; }
        decimal AttackSpeedModifier { get; set; }
        void UpdateBonuses(List<int> bonuses);
        bool CheckForMaxed();

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
        decimal EnergyMeditationGain { get; set; }
        string EnergyMeditationGainString { get; set; }

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
        decimal AutoSpeedMultiplier { get; set; }
        decimal EnergyGainMultiplier { get; set; }
        decimal ExpGainMultiplier { get; set; }
        string Rate { get; set; }
        DispatcherTimer Timer { get; set; }
        DispatcherTimer MeditateTimer { get; set; }

    }
}
