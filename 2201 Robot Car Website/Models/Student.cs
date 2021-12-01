﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2201_Robot_Car_Website.Models

{
    public partial class Student
    {
        public int Sid { get; set; }

        [MaxLength(45)]
        public string StudentName { get; set; }

        [MaxLength(4)]
        public string Class { get; set; }

    }
}