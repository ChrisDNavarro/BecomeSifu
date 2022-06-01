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

        public async Task<int> Fight(bool goesFirst)
        {
            await Task.Run(async () =>
            {
                FighterHealth = Dojos.BoundDojo[0].Health;
                if (goesFirst)
                {
                    while (FighterHealth > 0 || Health > 0)
                    {
                        FighterAttack();
                        await Task.Delay(10);
                        EnemyAttack();
                    }
                }
                else
                {
                    while (FighterHealth > 0 || Health > 0)
                    {
                        EnemyAttack();
                        await Task.Delay(10);
                        FighterAttack();
                    }
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

        private void EnemyAttack()
        {
            FighterHealth -=
                decimal.Subtract(decimal.Multiply(decimal.Add(3.01M, (decimal)RNG.NextDouble()) / 4 , Attack) , Dojos.BoundDojo[0].Defense);
        }

        private void FighterAttack()
        {
            Health -= Dojos.BoundDojo[0].Attack;
        }
    }
}
