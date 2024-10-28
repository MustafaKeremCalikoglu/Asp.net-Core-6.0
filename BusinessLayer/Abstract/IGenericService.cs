using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TRemove(T t);
        void TUptade(T t);
        List<T> GetAll();
        T TGetById(int id);
        //List<T> TGetByFilter(Expression<Func<T, bool>> filter);

    }
}
