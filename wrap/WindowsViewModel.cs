﻿using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace wrap
{
    public class WindowsViewModel
    {
        private ObservableCollection<RowViewModel> m_Rows;

        public ObservableCollection<RowViewModel> Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }

        public Command<RowViewModel> SelectBookableTypeCommand
        {
            get { return Rows; }
        }


        public WindowsViewModel()
        {
            Rows = new ObservableCollection<RowViewModel>();
            Rows.Add(new RowViewModel
            {
                ID = "42",
                Category = "cat",
                CharLimit = 32,
                Text = "Bonjour"
            });
        }
    }
}
