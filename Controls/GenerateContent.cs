using BecomeSifu.Logging;
using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.Controls
{
    public class GenerateContent
    {
        public GenerateContent()
        {
            Punches();
            Kicks();
            Specials();
            Defenses();            
        }

        private void Punches()
        {
            try
            {
                Dictionary<int, string> punches = Dojos.Dojo[0].Punches;
                foreach (int key in punches.Keys)
                {
                    Punches punch = new Punches(punches[key], key);
                    Dojos.AddPunch(punch);
                    LogIt.Write($"Populated Punches observale list.");
                }
            }
            catch (Exception e )
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void Kicks()
        {
            try
            {
                Dictionary<int, string> kicks = Dojos.Dojo[0].Kicks;
                foreach (int key in kicks.Keys)
                {
                    Kicks kick = new Kicks(kicks[key], key);
                    Dojos.AddKick(kick);
                    LogIt.Write($"Populated Kicks observale list.");
                }
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void Specials()
        {
            try
            {
                Dictionary<int, string> specials = Dojos.Dojo[0].Specials;
                foreach (int key in specials.Keys)
                {
                    Specials special = new Specials(specials[key], key);
                    Dojos.AddSpecial(special);
                }
                LogIt.Write($"Populated Specials observale list.");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

        private void Defenses()
        {
            try
            {
                Dictionary<int, string> Defenses = Dojos.Dojo[0].Defenses;
                foreach (int key in Defenses.Keys)
                {
                    Defenses defense = new Defenses(Defenses[key], key);
                    Dojos.AddDefense(defense);
                }
                LogIt.Write($"Populated Defenses observale list.");
            }
            catch (Exception e)
            {
                LogIt.Write($"Error Caught: {e}");
                throw;
            }
        }

    }
}
