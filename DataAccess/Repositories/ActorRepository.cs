﻿using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(NoratorContext noratorContext) : base(noratorContext)
        {
            
        }
    }
}
