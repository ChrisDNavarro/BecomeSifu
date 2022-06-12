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
        public int Wins { get; set; }
        public decimal Health { get; set; }
        public decimal Attack { get; set; }
        public string HealthString { get; set; }
        public string AttackString { get; set; }
        public bool IsActive { get; set; }
        public string FightName { get; set; }
        public SolidColorBrush Background { get; set; }
        public Random RNG = new Random();
        private decimal FighterHealth;

        public async Task<int> Fight()
        {
            await Task.Run(async () =>
            {
                try
                {
                    FighterHealth = Dojos.Dojo[0].Health;
                    int round = 0;
                    while (FighterHealth > 0 && Health > 0)
                    {
                        round++;
                        LogIt.Write($"Round {round}: Hero: {FighterHealth} Enemy {Health}");
                        decimal z = decimal.Subtract(decimal.Multiply(decimal.Divide(decimal.Add(3.1M, (decimal)RNG.NextDouble()), 4M), Attack), Dojos.Dojo[0].Defense);
                        FighterHealth -= z;
                        Health -= Dojos.Dojo[0].Attack * (1 + Dojos.Dojo[0].AttackSpeedModifier);
                        await Task.Delay(10);
                    }
                }
                catch (Exception e)
                {
                    LogIt.Write($"Error Caught: {e}");
                    throw;
                }
            });

            return EvaluateFight();
        }

        private int EvaluateFight()
        {
            RadialGradientBrush background = PageHolder.MainClient.Background as RadialGradientBrush;
            try
            {
                LogIt.Write($"Reviewing Fight Results");
                if (FighterHealth <= 0 && FighterHealth < Health)
                {
                    background.GradientStops[2].Color = Colors.Green;
                    background.GradientStops[4].Color = Colors.Green;
                    background.GradientStops[5].Color = Colors.Green;
                    Task.Delay(20);
                    background.GradientStops[2].Color = Colors.SteelBlue;
                    background.GradientStops[4].Color = Colors.SteelBlue;
                    background.GradientStops[5].Color = Colors.SteelBlue;
                    return 0;
                }
                else
                {
                    background.GradientStops[2].Color = Colors.Red;
                    background.GradientStops[4].Color = Colors.Red;
                    background.GradientStops[5].Color = Colors.Red;
                    Task.Delay(20);
                    background.GradientStops[2].Color = Colors.SteelBlue;
                    background.GradientStops[4].Color = Colors.SteelBlue;
                    background.GradientStops[5].Color = Colors.SteelBlue;
                    return 1;
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
               
        }
    }
}
