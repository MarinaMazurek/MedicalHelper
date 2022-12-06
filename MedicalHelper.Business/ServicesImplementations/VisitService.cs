using AutoMapper;
using MediatR;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.Data.CQS.Commands;
using MedicalHelper.Data.CQS.Queries;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public VisitService(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddAsync(VisitDto visitDto)
        {
            await _mediator.Send(new AddVisitCommand() { Visit = visitDto });
        }

        public async Task DeleteVisitByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Visits.GetEntityByIdAsync(id);
            _unitOfWork.Visits.Remove(entity);
        }

        public async Task<VisitDto> GetVisitByIdAsync(Guid id)
        {
            // implementation by _unitOfWork
            //var entity = await _unitOfWork.Visits.GetEntityByIdAsync(id);

            // implementation by _mediator
            var entity = await _mediator.Send(new GetVisitByIdQuery() { Id = id });

            var visitDto = _mapper.Map<VisitDto>(entity);
            return visitDto;
        }

        public async Task<List<VisitDto>> GetAllVisitsAsync(Guid userId)
        {
            var entities = await _unitOfWork.Visits.GetAllVisitsByUserIdAsync(userId);
            var visitsDto = _mapper.Map<List<VisitDto>>(entities);
            return visitsDto;
        }
    }
}
