﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public Experience GetByID(int id)
        {
            return _experienceDal.GetByID(id);
        }

        public void TAdd(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public List<Experience> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public List<Experience> TGetList()
        {
            return _experienceDal.GetList();
        }

        public void Update(Experience t)
        {
            _experienceDal.Update(t);
        }
    }
}
