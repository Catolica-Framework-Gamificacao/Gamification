using Api.Models.Register;

namespace Tests.Api.Models.Register;

public class FormularyTest
{
    [Theory(DisplayName = "E-mails válidos devem passar na validação do formulário")]
    [InlineData("teste@teste.com")]
    [InlineData("gusthawo@teste.com")]
    [InlineData("teste@gmail.com")]
    [InlineData("user@outlook.com")]
    public void MailsMustBeValidatedCorrectlyInTheMethod(string mailAddress)
    {
        var formulary = new Formulary
        {
            Email = mailAddress
        };
        Assert.True(formulary.EmailIsValid());
    }
    
    [Theory(DisplayName = "E-mails inválidos não devem passar na validação do formulário")]
    [InlineData("teste@testecom")]
    [InlineData("gusthawo.com")]
    [InlineData("testegmail.com")]
    [InlineData("user@outlook")]
    public void InvalidMailsMustBeInvalidInTheMethod(string mailAddress)
    {
        var formulary = new Formulary
        {
            Email = mailAddress
        };
        Assert.False(formulary.EmailIsValid());
    }
    
}