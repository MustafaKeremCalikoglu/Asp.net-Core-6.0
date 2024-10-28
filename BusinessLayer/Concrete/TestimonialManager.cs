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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonial;
        public TestimonialManager(ITestimonialDal testimonial)
        {
            _testimonial = testimonial;
        }

        public List<Testimonial> GetAll()
        {
            return _testimonial.GetList();
        }

        public void TAdd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TUptade(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
