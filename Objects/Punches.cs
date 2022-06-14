using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BecomeSifu.Objects
{
    public class Punches
    {
        public Punches(string name, int step)
        {
            ActionsViewModel punch = new ActionsViewModel();
            punch.Name = name;
            punch.Step = step + 1;
            punch.LevelInt = 0;
            punch.Level = "Lvl " + (punch.LevelInt + 1).ToString();

            punch.ExpToNext = Dojos.Dojo[0].EnergyToUnlock(punch.Step);
            punch.ExpString = punch.ExpToNext.ConvertToString();
            punch.LevelUp = $"Learn\r\n{punch.ExpString} Eng";

            if(punch.Step == 1)
            {
                punch.Enabled = true;
            }

            if (punch.Step % 2 == 0)
            {
                punch.BackgroundColor = new SolidColorBrush(Colors.LightSteelBlue);
                punch.ForegroundColor = new SolidColorBrush(Colors.DimGray);
            }
            else
            {
                punch.ForegroundColor = new SolidColorBrush(Colors.RoyalBlue);
                punch.BackgroundColor = new SolidColorBrush(Colors.Silver);
            }

            Dojos.AddPunch(punch);
        }

        public static void TryLevelUp(ActionsViewModel viewModel)
        {
            try
            {
                if (viewModel.Learned)
                {
                    if (Dojos.Dojo[0].Energy >= viewModel.ExpToNext)
                    {
                        LogIt.Write($"Learning {viewModel.Name}");
                        viewModel.Learned = true;

                        Dojos.Dojo[0].SpendEnergy(viewModel.ExpToNext);

                        if (viewModel.Step == 1)
                        {
                            if (Dojos.Dojo[0].Energy >= Dojos.Kicks[0].ExpToNext)
                            {
                                Dojos.Kicks[0].Enabled = true;
                                Dojos.Kicks.Refresh();
                            }
                            Dojos.Fights[0].IsActive = true;
                            Dojos.Fights.Refresh();
                            Extensions.CreateMessage("Kicks", false);
                            Extensions.CreateMessage("Street Fight", true);
                        }
                        if (viewModel.Step == 5 && !Dojos.Defenses[0].Learned)
                        {
                            Dojos.Defenses[0].Enabled = true;
                            Dojos.Defenses.Refresh();
                            Extensions.CreateMessage("Defense", true);
                        }
                        CompleteLevelUp(viewModel);
                    }
                }
                else
                {
                    if (Dojos.Dojo[0].Exp >= viewModel.ExpToNext && !viewModel.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {viewModel.Name}");
                        Dojos.Dojo[0].SpendExp(viewModel.ExpToNext);
                        CompleteLevelUp(viewModel);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private static void CompleteLevelUp(ActionsViewModel viewModel)
        {
            try
            {
                if (viewModel.LevelInt <= 500)
                {
                    if (500 - viewModel.LevelInt <= BoostsController.Boost)
                    {
                        viewModel.LevelInt = 500;
                    }
                    else
                    {
                        viewModel.LevelInt += BoostsController.Boost;
                    }
                    if (viewModel.LevelInt == 500)
                    {
                        LogIt.Write($"{viewModel.Name} has reached Max Level");
                        Extensions.SendMessage($"{viewModel.Name} has reached Max Level");
                        viewModel.MaxLevel = true;
                        viewModel.LevelUp = "Max Level";
                        Dojos.Punches.Refresh();
                    }

                    LevelUpExp(viewModel);

                    viewModel.Level = "Lvl " + viewModel.LevelInt.ToString();

                    viewModel.LevelUp = $"Level Up \r\n{viewModel.ExpString} Exp";

                    Dojos.Dojo[0].CalculateAll();

                    Dojos.Dojo.Refresh();
                    

                    Dojos.Punches.Refresh();

                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"{viewModel.Name} is at Max Level");
                    Extensions.SendMessage($"{viewModel.Name} is at Max Level");
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        public static void LevelUpExp(ActionsViewModel viewModel)
        {
            if (viewModel.Learned)
            {
                viewModel.ExpToNext = Dojos.Dojo[0].AttacksExpToNext(viewModel.Step, viewModel.LevelInt);
                viewModel.ExpString = viewModel.ExpToNext.ConvertToString();
                Extensions.UpdateActives();
                Dojos.Punches.Refresh();
            }
        }


    }
}
