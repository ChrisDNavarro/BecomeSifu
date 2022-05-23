using BecomeSifu.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.Controls
{
    public class GenerateAttacks
    {

        public GenerateAttacks()
        {
            Punches();
            Kicks();
            Specials();
        }

        private void Punches()
        {
            Dictionary<int, string> punches = Dojos.Dojo.Punches;
            foreach (int key in punches.Keys)
            {
                Punches punch = new Punches(punches[key], key);
                Dojos.AddPunch(punch);
            }
        }

        private void Kicks()
        {
            Dictionary<int, string> kicks = Dojos.Dojo.Kicks;
            foreach (int key in kicks.Keys)
            {
                Kicks kick = new Kicks(kicks[key], key);
                Dojos.AddKick(kick);
            }
        }

        private void Specials()
        {
            Dictionary<int, string> specials = Dojos.Dojo.Specials;
            foreach (int key in specials.Keys)
            {
                Specials punch = new Specials(specials[key], key);
                Dojos.AddSpecial(punch);
            }
        }

    }
}
