using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
                FighterHealth = Dojos.BoundDojo[0].Health;
                while (FighterHealth > 0 || Health > 0)
                {
                    FighterHealth -=
                        decimal.Subtract(decimal.Multiply(decimal.Add(3.1M, decimal.Divide((decimal)RNG.NextDouble(), 4M)), Attack), Dojos.BoundDojo[0].Defense);
                    Health -= Dojos.BoundDojo[0].Attack * (1 + Dojos.BoundDojo[0].AttackSpeedModifier);
                    await Task.Delay(10);
                }
            });

            return EvaluateFight();
        }

        private int EvaluateFight()
        {
            return FighterHealth <= 0
                ? 0
                : 1;
        }
    }
}
