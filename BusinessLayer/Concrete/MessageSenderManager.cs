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
    public class MessageSenderManager : IMessageSenderService
    {
        IMessageSenderDal _messageSenderDal;

        public MessageSenderManager(IMessageSenderDal messageSenderDal)
        {
            _messageSenderDal = messageSenderDal;
        }

        public WriterUser GetByID(int id)
        {
            return _messageSenderDal.GetByID(id);
        }

        public void TAdd(WriterUser t)
        {
            _messageSenderDal.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _messageSenderDal.Delete(t);
        }

        public List<WriterUser> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetList()
        {
            return _messageSenderDal.GetList();
        }

        public void Update(WriterUser t)
        {
           _messageSenderDal.Update(t);
        }
    }
}
