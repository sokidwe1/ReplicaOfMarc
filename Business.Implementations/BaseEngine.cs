using AutoMapper;
using Data.Abstractions.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class BaseEngine
    {
        protected readonly IMapper _mapper;
        protected IUnitOfWork _uow { get; set; }
        public BaseEngine(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
    }
}
