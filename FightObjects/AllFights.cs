using BecomeSifu.Controls;
using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace BecomeSifu.FightObjects
{
    public class AllFights
    {        
        public static Random RNG = new Random();
        private static decimal FighterHealth;

        public static async Task<int> Fight(decimal health, decimal attack)
        {
            await Task.Run(async () =>
            {
                try
                {
                    FighterHealth = PageHolder.MainWindow.DojoState.Dojo[0].Health;
                    int round = 0;
                    while (FighterHealth > 0 && health > 0)
                    {
                        round++;
                        LogIt.Write($"Round {round}: Hero: {FighterHealth} Enemy {health}");
                        decimal z = decimal.Subtract(decimal.Multiply(decimal.Divide(decimal.Add(3.1M, (decimal)RNG.NextDouble()), 4M), attack), PageHolder.MainWindow.DojoState.Dojo[0].Defense);
                        FighterHealth -= z;
                        health -= PageHolder.MainWindow.DojoState.Dojo[0].Attack * (1 + PageHolder.MainWindow.DojoState.Dojo[0].AttackSpeedModifier);
                        await Task.Delay(10);
                    }
                }
                catch (Exception e)
                {
                    LogIt.Write($"Error Caught: {e}");
                    throw;
                }
            });

            return EvaluateFight(health);
        }

        private static int EvaluateFight(decimal health)
        {            
            try
            {
                LogIt.Write($"Reviewing Fight Results");
                return FighterHealth <= 0 && FighterHealth < health
                    ? 0 
                    : 1;
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
               
        }

    }
}
