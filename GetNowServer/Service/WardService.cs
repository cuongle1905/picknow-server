using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickNowWeb.Models;

namespace PickNowWeb.Service
{
    public class WardService : IWardService
    {
        public MyDbContext _dbContext;
        public WardService(MyDbContext wardDbContext)
        {
            _dbContext = wardDbContext;
        }

        public List<Ward> GetWards()
        {
            return _dbContext.Wards.ToList();
        }

        public List<Ward> GetWardsByDistrictId(int districtId)
        {
            return (_dbContext.Wards.Where(e => e.District == districtId).ToList());
        }

        public List<Ward> GetWardsByProvinceId(int provinceId)
        {
            var districtIds = _dbContext.Districts.Where(x => x.Province == provinceId).Select(e => e.Id);
            return (_dbContext.Wards.Where(e => districtIds.Contains(e.District)).ToList());
        }

        public Ward AddWard(Ward ward)
        {
            ward.Id = GetNewId();
            _dbContext.Wards.Add(ward);
            _dbContext.SaveChanges();
            return ward;
        }

        public void UpdateWard(Ward ward)
        {
            _dbContext.Wards.Update(ward);
            _dbContext.SaveChanges();
        }

        public void DeleteWard(int Id)
        {
            var ward = _dbContext.Wards.FirstOrDefault(x => x.Id == Id);
            if (ward != null)
            {
                _dbContext.Remove(ward);
                _dbContext.SaveChanges();
            }
        }

        public Ward GetWard(int Id)
        {
            return _dbContext.Wards.FirstOrDefault(x => x.Id == Id);
        }

        public int GetNewId()
        {
            return _dbContext.Wards.Max(w => w.Id) + 1;
        }
    }
}
