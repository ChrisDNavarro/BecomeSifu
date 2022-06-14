using BecomeSifu.Logging;
using BecomeSifu.Objects;
using BecomeSifu.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.Controls
{
    public class GenerateContent
    {
        public GenerateContent()
        {
            PunchesContent();
            Kicks();
            Specials();
            Defenses();            
        }

        private void PunchesContent()
        {
            try
            {
                Dictionary<int, string> punches = Dojos.Dojo[0].Punches;
                foreach (int key in punches.Keys)
                {
                    ActionsViewModel punch = new ActionsViewModel();
                    Punches.Create(punches[key], key, punch);
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
