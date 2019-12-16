using System;
using Xunit;
using static Crypto.SignatureProvider;

namespace Crypto.Tests
{
    public class SignatureProviderTests
    {
        private readonly KeyPair _keyPair = KeyPair.NewKeyPair();


        [Fact]
        public void GeneratesKeys()
        {
            Assert.NotEmpty(_keyPair.PrivateKey);
            Assert.NotEmpty(_keyPair.PublicKey);
        }

        [Fact]
        public void GeneratesSignature()
        {
            var signature = GetSignature("Hello", _keyPair.PrivateKey);
            Assert.NotEmpty(signature);
        }
    }
}
