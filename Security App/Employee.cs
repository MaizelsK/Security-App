using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_App
{
    [Serializable]
    public class Employee : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        private bool isArrived;
        public bool IsArrived
        {
            get { return isArrived; }
            set
            {
                isArrived = value;
                OnPropertyChanged("IsArrived");
            }
        }

        public List<DateTime> Visits { get; set; }

        public Employee()
        {
            Visits = new List<DateTime>();
        }

        public bool CheckVisit(DateTime date)
        {
            foreach (var visit in Visits)
            {
                if (visit.ToShortDateString().Equals(date.ToShortDateString()))
                {
                    return true;
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
