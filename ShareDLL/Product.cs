﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareDLL
{
     [Serializable]
    public class Product
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public double  Price { get; set; }
    }
}
