﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace wrap
{
    public class RowViewModel : INotifyPropertyChanged
    {
        private string m_ID;
        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
                NotifyPropertyChanged("ID");
            }
        }
        public string Category
        {
            get;
            set;
        }

        public int CharLimit
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }
        public RowViewModel()
        {
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }
    }
}

