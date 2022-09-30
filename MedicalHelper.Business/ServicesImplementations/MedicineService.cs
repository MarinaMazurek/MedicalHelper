using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Business.ServicesImplementations
{
   
    public class MedicineService 
    {
        private readonly IMapper _mapper;
        private readonly MedicineRepository _medicineRepository;

        public MedicineService(IMapper mapper, MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;   
        }

        public MedicineDto GetMedicine(Guid id)
        {            
            var entity = _medicineRepository.GetMedicine(id);

            var dto = _mapper.Map<MedicineDto>(entity);

            return dto;
        }

        public List<MedicineDto> GetAllMedicine()
        {
            var allMedicines = _medicineRepository.GetAllMedicine();
                       
            List<MedicineDto> list = _mapper.Map<List<MedicineDto>>(allMedicines);

            return list;
        }
    }
}
