﻿using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class TypeModel
    {
        //public 
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
