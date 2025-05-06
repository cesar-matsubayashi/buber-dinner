using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.CreateHost
{
    public class CreateHostCommandHandler : IRequestHandler<CreateHostCommand, ErrorOr<Host>>
    {
        private readonly IHostRepository _hostRepository;

        public CreateHostCommandHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<ErrorOr<Host>> Handle(
            CreateHostCommand request, 
            CancellationToken cancellationToken)
        {
            var host = Host.Create(
                request.FirstName,
                request.LastName,
                request.ProfileImage,
                request.UserId);

            await _hostRepository.AddAsync(host);

            return host;
        }
    }
}
