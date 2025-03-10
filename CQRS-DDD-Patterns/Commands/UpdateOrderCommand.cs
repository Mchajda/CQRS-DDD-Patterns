using MediatR;

namespace CQRS_DDD_Patterns.Commands
{
    public class UpdateOrderCommand : IRequest<string>
    {
    }
}
