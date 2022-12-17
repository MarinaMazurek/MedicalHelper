﻿using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.WebAPI.Models
{
    public class VisitModel
    {
        public string Name { get; set; }

        public Doctor Specialization { get; set; }

        public string FullNameOfDoctor { get; set; }

        public DateTime DateTime { get; set; }
    }
}
