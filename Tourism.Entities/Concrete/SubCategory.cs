﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class SubCategory : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }        
        public int MainCategoryId { get; set; }    
        public MainCategory MainCategory { get; set; }          
        public List<Operation> Operations { get; set; }                         

    }
}
