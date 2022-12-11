using MediatR;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.CQS.Commands
{
    public class AddVisitCommand : IRequest<Visit>
    {
        public VisitDto? Visit;
    }
}
