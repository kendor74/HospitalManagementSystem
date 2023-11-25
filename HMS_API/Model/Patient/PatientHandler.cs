using HMS_API.Model.DTOs;
using HMS_API.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HMS_API.Model.PatientHandler
{
    public class PatientHandler : IRepo<Patient, PatientDto>
    {
        private readonly HospitalContext _context;
        public PatientHandler(HospitalContext context)
        {
            _context = context;
        }

        public async Task<Patient> Add(PatientDto entity)
        {
            Patient pt = new Patient
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Gender = entity.Gender,
                Weight = entity.Weight,
                Height = entity.Height,
                MaterialState = entity.MaterialState
            };

            
            await _context.Patients.AddAsync(pt);
            await _context.SaveChangesAsync();
            return pt;
        }

        public async Task<int> Count()
        {
            return await _context.Patients.CountAsync();
        }

        public async Task<bool> Delete(int entityId)
        {
            Patient pt = await FindById(entityId);

            if (pt != null)
            {
                _context.Patients.Remove(pt);
                await _context.SaveChangesAsync();
            }
            else
                return false;

            return true;

        }

        public async Task<Patient> FindById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            List<Patient> list = await _context.Patients.ToListAsync();

            return list;
        }

        public async Task<bool> IsExist(int id)
        {
            return (await FindById(id) != null) ? true : false;
        }

        public async Task<Patient> Update(PatientDto entity, int id)
        {
            Patient pt = await FindById(id);
            pt.FirstName = entity.FirstName;
            pt.LastName = entity.LastName;
            pt.Address = entity.Address;
            pt.Gender = entity.Gender;
            pt.Weight = entity.Weight;
            pt.Height = entity.Height;
            pt.MaterialState = entity.MaterialState;

            _context.Patients.Update(pt);
            await _context.SaveChangesAsync();
            
            return pt;
        }
    }
}
