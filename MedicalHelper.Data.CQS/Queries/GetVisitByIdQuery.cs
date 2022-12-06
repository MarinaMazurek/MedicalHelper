using MediatR;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.CQS.Queries
{
    public class GetVisitByIdQuery : IRequest<Visit?>
    {
        public Guid Id { get; set; }
    }
}
