using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Host;

namespace BuberDinner.Application.UnitTests.Hosts.TestUtils
{
    public class CreateHostUtils
    {
        public static Host CreateHost() =>
            Host.Create(
                Constants.Host.FirstName1,
                Constants.Host.LastName1,
                Constants.Host.ProfileImage1,
                Constants.User.Id1);
    }
}
