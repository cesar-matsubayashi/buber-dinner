using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.DeleteHost
{
    public class DeleteHostCommandHandler
        : IRequestHandler<DeleteHostCommand, ErrorOr<Deleted>>
    {
        private readonly IHostRepository _hostRepository;

        public DeleteHostCommandHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteHostCommand request, 
            CancellationToken cancellationToken)
        {
            var host = await _hostRepository.GetAsync(request.Id);

            if (host is null)
            {
                return Errors.Host.NotFound;
            }

            await _hostRepository.DeleteAsync(request.Id);

            return new Deleted();
        }
    }
}
