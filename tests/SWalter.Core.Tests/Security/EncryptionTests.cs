using SWalter.Core.Security;

namespace SWalter.Core.Tests.Security;

public class EncryptionTests
{
    [Theory]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("Hello World", "SuperSecretKey")]
    [NSubstituteOmitAutoPropertiesTrueInlineAutoData("Some other string", "AnotherSuperSecretKey")]
    public void EncryptAndDecrypt_ShouldReturnOriginalString(string clearText, string encryptionKey)
    {
        // Arrange
        var sut = new Encryption();

        // Act
        var encrypted = sut.EncryptString(clearText, encryptionKey);
        var decrypted = sut.DecryptString(encrypted, encryptionKey);

        // Assert
        decrypted.Should().Be(clearText);
    }
}