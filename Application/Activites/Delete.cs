using Application.Core;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // throw new NotImplementedException();
                var activity = await _context.Activites.FindAsync(request.Id);
                
                if(activity==null) return null;

                _context.Remove(activity);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure("Failed to delete the activity");
                
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}