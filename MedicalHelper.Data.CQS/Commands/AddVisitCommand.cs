using MediatR;
using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Data.CQS.Commands
{
    public class AddVisitCommand : IRequest
    {
        public VisitDto? Visit;
    }
}
