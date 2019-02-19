using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Business.Tests.AccountTests
{
    public class AccountTestDouble : Account
    {
        public AccountTestDouble(IRepository<UserCredentials> repository) : base(repository) { }

        protected override string GenerateAccessKey(UserCredentials userCredentials)
        {
            return "GrantedAccessKey";
        }
    }
}
