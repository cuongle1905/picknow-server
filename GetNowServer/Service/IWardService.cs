using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickNowWeb.Models;

namespace PickNowWeb.Service
{
    public interface IWardService
    {
        Ward AddWard(Ward ward);
        List<Ward> GetWards();
        List<Ward> GetWardsByDistrictId(int districtId);
        List<Ward> GetWardsByProvinceId(int provinceId);
        void UpdateWard(Ward ward);
        void DeleteWard(int Id);
        Ward GetWard(int Id);
        int GetNewId();
    }
}
