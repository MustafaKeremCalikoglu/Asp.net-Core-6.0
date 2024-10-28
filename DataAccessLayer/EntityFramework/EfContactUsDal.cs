using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {   

        public void ContactUsStatusChangeToFalse(int id)
        {
            using (Context context = new Context())
            {
                var values = context.ContactUses.Find(id);
                if (values !=null)
                {
                    if (values.MessageStatus == true)
                    {
                        values.MessageStatus = false;
                        context.Update(values);
                        context.SaveChanges();
                    }
                    else
                    {
                        values.MessageStatus = true;
                        context.Update(values);
                        context.SaveChanges();
                    }
                }
               
            };
          
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (Context c = new Context())
            {
                return c.ContactUses.Where(x => x.MessageStatus == false).ToList();
            };
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (Context c = new Context())
            {
                return c.ContactUses.Where(x => x.MessageStatus == false).ToList();
            };

        }
    }
}
