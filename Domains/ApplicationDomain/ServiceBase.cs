using AspNetCore.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain
{
    public abstract class ServiceBase 
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _uow;
        public ServiceBase(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        
    }
}
