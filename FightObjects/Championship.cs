﻿using BecomeSifu.Logging;
using BecomeSifu.Objects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BecomeSifu.FightObjects
{
    public class Championship : AllFights , IFights
    {
        public ICommand StartFighting => new RelayCommand(() => Begin());
        public Championship()
        {
            Wins = 0;
            Health = ((decimal)Wins + 1) * 100000;
            Attack = ((decimal)Wins + 1) * 10000;
            HealthString = Health.ConvertToString();
            AttackString = Attack.ConvertToString();
            FightName = this.GetType().Name;
            Background = new SolidColorBrush(Colors.Silver);
        }
        public void Won(int win)
        {
            try
            {
                Wins += win;
                LogIt.Write($"Finalizing Results: fight complete with {win} wins for a total of {Wins} wins");
                Health = ((decimal)Wins + 1) * 100000;
                Attack = ((decimal)Wins + 1) * 10000;
                HealthString = Health.ConvertToString();
                AttackString = Attack.ConvertToString();
                LogIt.Write($"Reset Healt and attack for enemy.");
                if (Wins == 1)
                {
                    Dojos.Cup[0].ButtonActive = true;
                    Dojos.Cup[0].ButtonName = "Empty Your Cup";
                    Dojos.Cup[0].Imagesource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/CupIsFull.png"));
                }
                if (Wins > 0 && Wins % 5 == 0)
                {
                    if (!Dojos.Dojo[0].Perks[1].Active && ((Wins / 5) - 1) < Dojos.Specials.Count)
                    {
                        Dojos.Specials[(Wins / 5) - 1].Enabled = true;
                        Dojos.Specials.Refresh();
                        Extensions.CreateMessage("Specials", true);
                    }
                    Dojos.Fights[3].IsActive = true;
                    if (Wins / 5 == 1)
                    {
                        Extensions.CreateMessage("Master", true);
                    }
                }
                IsActive = false;

                Dojos.Fights.Refresh();
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
        public async void Begin()
        {
            try
            {
                bool first = Convert.ToBoolean(RNG.Next(0, 2));
                LogIt.Write($"--------------FIGHT----------------");
                LogIt.Write($"Starting Championship");
                Won(await Task.Run(() => Fight()));
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }
    }
}
