﻿using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class BaseEntity : IEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
