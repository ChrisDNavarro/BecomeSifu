﻿using BecomeSifu.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace BecomeSifu.MartialArts
{
    public class Boxing : Arts, IDojo
    {
        private List<string> _PunchesList = new List<string>{
            "Jab",
            "Cross",
            "Lead Hook",
            "Rear Hook",
            "Lead Uppercut",
            "Rear Uppercut"
        };

        private List<string> _DefensesList = new List<string>{
            "FootWork",
            "Guard",
            "Slip",
            "Parry",
            "Counter"
        };

        /// <summary>
        /// To The Body for Boxing
        /// </summary>
        private List<string> _KicksList = new List<string>{
            "Body Blows",
        };

        private List<string> _SpecialsList = new List<string>{
            "1 2",
            "1 2 3",
            "3 4 3 4",
            "1 2 5 2",
            "1 6 3 2"
        };

        public Boxing()
        {
            for (int i = 0; i < _PunchesList.Count; i++)
            {
                Punches[i] = _PunchesList[i];
            }
            for (int i = 0; i < _KicksList.Count; i++)
            {
                Kicks[i] = _KicksList[i];
            }
            for (int i = 0; i < _SpecialsList.Count; i++)
            {
                Specials[i] = _SpecialsList[i];
            }
            for (int i = 0; i < _DefensesList.Count; i++)
            {
                Defenses[i] = _DefensesList[i];
            }
        }

        public bool IsBoxing { get; } = true;
    }
}
