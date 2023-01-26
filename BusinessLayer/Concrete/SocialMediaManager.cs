using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediDal;

        public SocialMediaManager(ISocialMediaDal socialMediDal)
        {
            _socialMediDal = socialMediDal;
        }

        public SocialMedia GetByID(int id)
        {
           return _socialMediDal.GetByID(id);
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediDal.Delete(t);
        }

        public List<SocialMedia> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediDal.GetList();
        }

        public void Update(SocialMedia t)
        {
            _socialMediDal.Update(t);
        }
    }
}
