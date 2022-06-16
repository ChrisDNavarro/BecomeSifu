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
                List<string> punches = PageHolder.MainWindow.DojoState.Dojo[0].Punches;
                foreach (string key in punches)
                {
                    new Punches(key, punches.IndexOf(key));
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
                List<string> kicks = PageHolder.MainWindow.DojoState.Dojo[0].Kicks;
                foreach (string key in kicks)
                {
                    new Kicks(key, kicks.IndexOf(key));
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
                List<string> specials = PageHolder.MainWindow.DojoState.Dojo[0].Specials;
                foreach (string key in specials)
                {
                    new Specials(key, specials.IndexOf(key));
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
                List<string> Defenses = PageHolder.MainWindow.DojoState.Dojo[0].Defenses;
                foreach (string key in Defenses)
                {
                    new Defenses(key, Defenses.IndexOf(key));
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
