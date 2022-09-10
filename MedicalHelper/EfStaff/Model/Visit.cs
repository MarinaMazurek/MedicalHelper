﻿namespace MedicalHelper.EfStaff.Model
{
    public class Visit : BaseModel 
    {
        public string SpecializationOfDoctor { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }        
        public virtual List<Medicine> Medicines { get; set; }
    }
}
