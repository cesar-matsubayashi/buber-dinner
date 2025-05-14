using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Host;

namespace BuberDinner.Application.UnitTests.Hosts.TestUtils
{
    public class CreateHostUtils
    {
        public static Host CreateHost() =>
            Host.Create(
                Constants.Host.FirstName,
                Constants.Host.LastName,
                Constants.Host.ProfileImage,
                Constants.User.Id1);
    }
}
