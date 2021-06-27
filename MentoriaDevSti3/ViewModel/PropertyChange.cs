using MentoriaDevSti3.View.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MentoriaDevSti3.ViewModel
{
    public class PropertyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
