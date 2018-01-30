using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_App
{
    [Serializable]
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public List<DateTime> Visits { get; set; }
    }
}
