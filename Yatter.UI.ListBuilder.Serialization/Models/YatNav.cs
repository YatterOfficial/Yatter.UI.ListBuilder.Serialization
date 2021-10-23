using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Yatter.UI.ListBuilder.ListItems;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public class YatNav : IDataType
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<YatterPath> MenuItems { get; set; }

        private bool _isHidden;
        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                _isHidden = value;
                OnPropertyChanged();
            }
        }

        public string DataType { get; set; } = null;

        public YatNav()
        {
            this.DataType = GetType().ToString();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

