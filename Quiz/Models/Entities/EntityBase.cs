using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.Models.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public bool Active { get; set; } = true;
    }
}