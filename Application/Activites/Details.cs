using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Details
    {
        public class Query : IRequest<Activity>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
                
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                // throw new NotImplementedException();
                return await _context.Activites.FindAsync(request.Id);
            }
        }
    }
}