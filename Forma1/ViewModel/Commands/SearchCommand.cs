﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Forma1.ViewModel.Commands
{
    public class SearchCommand:ICommand
    {
        public MainVM VM { get; set; }
        public SearchCommand(MainVM vm)
        {
            VM = vm;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.GetVersenyzők();
        }
    }
}
