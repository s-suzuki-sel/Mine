﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUD_makeS.ViewModels
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CreateViewModel = new CreateViewModel();
            DataGridViewModel = new DataGridViewModel();
        }

        public CreateViewModel CreateViewModel { get; }
        public DataGridViewModel DataGridViewModel { get; }
     
    }
}
