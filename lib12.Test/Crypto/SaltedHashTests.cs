using FluentAssertions;
using lib12.Crypto;
using Xunit;

namespace lib12.Test.Crypto
{
    public class SaltedHashTests
    {
        [Fact]
        public void hash_matches_salted_password()
        {
            const string password = "SecretPassword";
            var salt = SaltedHash.GenerateSalt();
            var hash = SaltedHash.ComputeHash(salt, password);

            SaltedHash.Verify(salt, hash, password).Should().BeTrue();
        }
    }
}