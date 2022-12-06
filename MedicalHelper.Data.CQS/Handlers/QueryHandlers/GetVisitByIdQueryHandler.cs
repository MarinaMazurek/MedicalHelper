using MediatR;
using MedicalHelper.Data.CQS.Queries;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Data.CQS.Handlers.QueryHandlers
{
    public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, Visit?>
    {
        private readonly MedicalHelperDbContext _context;

        public GetVisitByIdQueryHandler(MedicalHelperDbContext context)
        {
            _context = context;
        }

        public async Task<Visit?> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var visit = await _context.Visits
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return visit;
        }
    }
}
