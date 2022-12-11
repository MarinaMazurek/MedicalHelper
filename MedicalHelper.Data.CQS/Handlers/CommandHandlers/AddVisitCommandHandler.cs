using AutoMapper;
using MediatR;
using MedicalHelper.Data.CQS.Commands;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.CQS.Handlers.CommandHandlers
{
    public class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, Visit>
    {
        private readonly MedicalHelperDbContext _context;
        private readonly IMapper _mapper;

        public AddVisitCommandHandler(MedicalHelperDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Visit> Handle(AddVisitCommand command, CancellationToken token)
        {
            var visitDto = command.Visit;
            var entity = _mapper.Map<Visit>(visitDto);

            var visitDb = await _context.Visits.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);

            return visitDb.Entity;
        }
    }
}
