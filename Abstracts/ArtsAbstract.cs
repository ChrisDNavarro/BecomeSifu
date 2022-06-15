using BecomeSifu.Interfaces;
using BecomeSifu.MartialArts;
using System;
using System.Collections.Generic;
using System.Text;


namespace BecomeSifu.Abstracts
{
    public abstract class ArtsAbstract : Arts, IDojo
    {
        public abstract bool IsBoxing { get; }
        public abstract CommandAbstract PracticeClick { get; }
        public abstract CommandAbstract MeditateClick { get; }
        public abstract CommandAbstract AutoPracticeCheck { get; }
        public abstract CommandAbstract AutoMeditateCheck { get; }
        public abstract CommandAbstract StartStopMeditationCommand { get; }
    }
}
