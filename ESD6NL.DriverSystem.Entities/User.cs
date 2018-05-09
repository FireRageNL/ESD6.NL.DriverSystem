using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    class User
    {
        private string userName { get; set; }
        private string password { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private DateTime birthDay { get; set; }
        private Address address { get; set; }
        private List<Car> cars { get; set; }
        private List<Invoice> invoices { get; set; }
}
