using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.Models
{
    public class UserViewModel
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay { get; set; }
        public Address address { get; set; }
        public List<Car> cars { get; set; } = new List<Car>();
        public List<Invoice> invoices { get; set; } = new List<Invoice>();
    }
}
