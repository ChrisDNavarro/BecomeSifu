using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using System.Windows.Media;
using System.Windows.Threading;

namespace BecomeSifu.Objects
{
    public class Punches
    {
        public Punches() { }
        public Punches(string name, int step)
        {
            ActionsViewModel punch = new ActionsViewModel();
            punch.Name = name;
            punch.Step = step + 1;
            punch.LevelInt = 0;
            punch.Level = "Lvl " + punch.LevelInt.ToString();

            punch.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].EnergyToUnlock(punch.Step);
            punch.ExpString = punch.ExpToNext.ConvertToString();
            punch.LevelUp = $"Learn\r\n{punch.ExpString} Eng";

            if(punch.Step == 1)
            {
                punch.Enabled = true;
            }

            if (punch.Step % 2 == 0)
            {
                punch.BackgroundColor = Colors.LightSteelBlue;
                punch.ForegroundColor = Colors.DimGray;
            }
            else
            {
                punch.ForegroundColor = Colors.RoyalBlue;
                punch.BackgroundColor = Colors.Silver;
            }

            PageHolder.MainWindow.DojoState.AddPunch(punch);
        }

        public static void TryLevelUp(ActionsViewModel punch)
        {
            try
            {
                if (!punch.Learned)
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Energy >= punch.ExpToNext)
                    {
                        LogIt.Write($"Learning {punch.Name}");
                        punch.Learned = true;
                        punch.Learning = true;

                        PageHolder.MainWindow.DojoState.Dojo[0].SpendEnergy(punch.ExpToNext);

                        if (punch.Step == 1)
                        {
                            if (PageHolder.MainWindow.DojoState.Dojo[0].Energy >= PageHolder.MainWindow.DojoState.Kicks[0].ExpToNext)
                            {
                                PageHolder.MainWindow.DojoState.Kicks[0].Enabled = true;
                                if (PageHolder.MainWindow.DojoState.Dojo[0].Perks[6].Active)
                                {
                                    PageHolder.MainWindow.DojoState.FightsVMs[1].IsActive = true;
                                }
                                
                            }
                            PageHolder.MainWindow.DojoState.FightsVMs[0].IsActive = true;
                            Extensions.CreateMessage("Kicks", false);
                            Extensions.CreateMessage("Street Fight", true);
                        }
                        if (punch.Step == 5 && !PageHolder.MainWindow.DojoState.Defenses[0].Learned)
                        {
                            PageHolder.MainWindow.DojoState.Defenses[0].Enabled = true;

                            Extensions.CreateMessage("Defense", true);
                        }
                        CompleteLevelUp(punch);
                    }
                }
                else
                {
                    if (PageHolder.MainWindow.DojoState.Dojo[0].Exp >= punch.ExpToNext && !punch.MaxLevel)
                    {
                        LogIt.Write($"Leveling up {punch.Name}");
                        PageHolder.MainWindow.DojoState.Dojo[0].SpendExp(punch.ExpToNext);
                        CompleteLevelUp(punch);
                    }
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private static void CompleteLevelUp(ActionsViewModel punch)
        {
            try
            {
                if (punch.LevelInt <= 500)
                {
                    if (500 - punch.LevelInt <= BoostsController.Boost)
                    {
                        punch.LevelInt = 500;
                    }
                    else
                    {
                        if (punch.Learning)
                        {
                            punch.LevelInt++;
                            punch.Learning = false;
                        }
                        else
                        {
                            punch.LevelInt += BoostsController.Boost;
                        }
                    }
                    if (punch.LevelInt == 500)
                    {
                        LogIt.Write($"{punch.Name} has reached Max Level");
                        Extensions.SendMessage($"{punch.Name} has reached Max Level");
                        punch.MaxLevel = true;
                        punch.LevelUp = "Max Level";
                        
                    }
                    else
                    {
                        LevelUpExp(punch);
                        punch.Level = "Lvl " + punch.LevelInt.ToString();
                        punch.LevelUp = $"Level Up \r\n{punch.ExpString} Exp";
                    }

                    

                    PageHolder.MainWindow.DojoState.Dojo[0].CalculateAll();

                    

                    Extensions.UpdateActives();
                }
                else
                {
                    LogIt.Write($"{punch.Name} is at Max Level");
                    Extensions.SendMessage($"{punch.Name} is at Max Level");
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
                viewModel.ExpToNext = PageHolder.MainWindow.DojoState.Dojo[0].AttacksExpToNext(viewModel.Step, viewModel.LevelInt);
                viewModel.ExpString = viewModel.ExpToNext.ConvertToString();
                Extensions.UpdateActives();
            }
        }


    }
}
