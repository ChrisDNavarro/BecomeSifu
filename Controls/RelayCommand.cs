using BecomeSifu.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
namespace BecomeSifu.Controls
{
    class RelayCommand : CommandAbstract
    {
        private Action<object> execute;

        public override event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public override void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
