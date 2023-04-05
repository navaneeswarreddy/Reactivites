using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
                
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // throw new NotImplementedException();
                var activity =  await _context.Activites.FindAsync(request.Id);
                
                return Result<Activity>.Success(activity);
            }
        }
    }
}