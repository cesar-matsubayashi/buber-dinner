using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Host;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Hosts.Queries.GetHost
{
    public class GetHostQueryHandler
        : IRequestHandler<GetHostQuery, ErrorOr<Host>>
    {
        private readonly IHostRepository _hostRepository;

        public GetHostQueryHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<ErrorOr<Host>> Handle(
            GetHostQuery request, 
            CancellationToken cancellationToken)
        {
            var host = await _hostRepository.GetAsync(request.Id);

            if (host is null)
            {
                return Errors.Host.NotFound;
            }

            return host;
        }
    }
}
