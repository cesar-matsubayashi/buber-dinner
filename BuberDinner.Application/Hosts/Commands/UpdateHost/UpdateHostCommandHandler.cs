using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Host;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Commands.UpdateHost
{
    public class UpdateHostCommandHandler
        : IRequestHandler<UpdateHostCommand, ErrorOr<Host>>
    {
        private readonly IHostRepository _hostRepository;

        public UpdateHostCommandHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<ErrorOr<Host>> Handle(
            UpdateHostCommand request, 
            CancellationToken cancellationToken)
        {
            var host = await _hostRepository.GetAsync(request.Id);

            if (host is null)
            {
                return Errors.Host.NotFound;
            }

            host.Update(
                request.FirstName,
                request.LastName,
                request.ProfileImage);

            await _hostRepository.UpdateAsync(host);

            return host;
        }
    }
}
