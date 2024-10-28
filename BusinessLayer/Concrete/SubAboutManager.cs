using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public List<SubAbout> GetAll()
        {
            return _subAboutDal.GetList();
        }

        public void TAdd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public SubAbout TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TRemove(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TUptade(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
