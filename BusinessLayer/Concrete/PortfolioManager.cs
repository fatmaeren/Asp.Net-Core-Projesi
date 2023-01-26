using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioDal
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void Delete(Portfolio t)
        {
            _portfolioDal.Delete(t);
        }

        public List<Portfolio> GetByFilter(Expression<Func<Portfolio, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Portfolio GetByID(int id)
        {
            return _portfolioDal.GetByID(id);
        }

        public List<Portfolio> GetList()
        {
            return _portfolioDal.GetList();
        }

        public void Insert(Portfolio t)
        {
            _portfolioDal.Insert(t);
        }

        public void Update(Portfolio t)
        {
            _portfolioDal.Update(t);
        }
    }
}
