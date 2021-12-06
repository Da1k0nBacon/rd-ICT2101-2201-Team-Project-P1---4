﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace _2201_Robot_Car_Website.Models

{
    public class Student : DbContext
    {
        public int Sid { get; set; }

        public string StudentName { get; set; }

        public string Class { get; set; }

        public string sClass { get; set; }

        public int ConStatus { get; set; }

        public DbSet<Student> Students { get; set; }

        

    }
}