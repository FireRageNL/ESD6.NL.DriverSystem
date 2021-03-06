﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class User
    {
        public User()
        {
            //Amazing empty constructor 
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Language { get; set; }
        public long citizenServiceNumber { get; set; }
        public DateTime birthDay { get; set; }
        public Address address { get; set; }
        public List<Car> cars { get; set; }
        public List<Invoice> invoices { get; set; }
        public DateTime lastSyncTime { get; set; }
    }
}
