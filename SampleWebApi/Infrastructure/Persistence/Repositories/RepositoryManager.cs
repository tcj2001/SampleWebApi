﻿using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ISampleRepository> _lazySampleRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        public RepositoryManager(ApplicationDbContext context)
        {
            _lazySampleRepository = new Lazy<ISampleRepository>(() => new SampleRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }
        public ISampleRepository SampleRepository => _lazySampleRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
