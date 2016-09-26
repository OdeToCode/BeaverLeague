using BeaverLeague.Core.Models;
using BeaverLeague.Web.Security;
using BeaverLeague.Web.Services;
using Xunit;

namespace BeaverLeague.Tests.Web.Services
{
    public class PasswordHasherTests
    {
        [Fact]
        public void CanSetAndVerifyPassword()
        {
            var hasher = new PasswordManager();
            var golfer = new Golfer();

            hasher.SetPassword(golfer, "123abc!@#");
            Assert.True(!string.IsNullOrEmpty(golfer.PasswordHash));
            Assert.Equal(true, hasher.VerifyPassword(golfer, "123abc!@#"));
        }

        [Fact]
        public void CanFailPassword()
        {
            var hasher = new PasswordManager();
            var golfer = new Golfer();

            hasher.SetPassword(golfer, "123abc!@#");
            Assert.Equal(false, hasher.VerifyPassword(golfer, "1"));
        }
    }
}
