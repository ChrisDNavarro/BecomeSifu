using BecomeSifu.Controls;
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
                FighterHealth = Dojos.Dojo[0].Health;
                while (FighterHealth > 0 && Health > 0)
                {
                    decimal z = decimal.Subtract(decimal.Multiply(decimal.Divide(decimal.Add(3.1M, (decimal)RNG.NextDouble()), 4M), Attack), Dojos.Dojo[0].Defense);
                    FighterHealth -= z;
                    Health -= Dojos.Dojo[0].Attack * (1 + Dojos.Dojo[0].AttackSpeedModifier);
                    await Task.Delay(10);
                }
            });

            return EvaluateFight();
        }

        private int EvaluateFight()
        {
            RadialGradientBrush background = PageHolder.MainClient.Background as RadialGradientBrush;

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
    }
}
