﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JordanHall.ClassifierService.Models
{
    public class TrainingRequest
    {
        public byte[] FileBytes { get; set; }

        public string FileName { get; set; }
    }
}
