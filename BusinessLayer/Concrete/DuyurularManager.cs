using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DuyurularManager : IDuyurularService
    {
        IDuyurularDal _duyurularDal;

        public DuyurularManager(IDuyurularDal duyurularDal)
        {
            _duyurularDal = duyurularDal;
        }

        public Duyurular GetByID(int id)
        {
            return _duyurularDal.GetByID(id);
        }

        public void TAdd(Duyurular t)
        {
            _duyurularDal.Insert(t);
        }

        public void TDelete(Duyurular t)
        {
            _duyurularDal.Delete(t);
        }

        public List<Duyurular> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public List<Duyurular> TGetList()
        {
            return _duyurularDal.GetList();
        }

        public void Update(Duyurular t)
        {
            _duyurularDal.Update(t);
        }
    }
}
