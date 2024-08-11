using FluentValidation.TestHelper;
using RegistrationWizard.Application.Commands.RegisterUser;
using RegistrationWizard.Application.Validators;
using Xunit;

namespace RegistrationWizard.Tests.Validators;

public class RegisterUserCommandValidatorTests
{
    private readonly RegisterUserCommandValidator _validator;

    public RegisterUserCommandValidatorTests()
    {
        _validator = new RegisterUserCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Login_Is_Empty()
    {
        var model = new RegisterUserCommand { Login = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Login);
    }

    [Fact]
    public void Should_Have_Error_When_Login_Exceeds_MaxLength()
    {
        var model = new RegisterUserCommand { Login = new string('a', 51) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Login);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Is_Empty()
    {
        var model = new RegisterUserCommand { Password = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Is_Too_Short()
    {
        var model = new RegisterUserCommand { Password = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Does_Not_Contain_Digit_And_Letter()
    {
        var model = new RegisterUserCommand { Password = "abcdef" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Should_Have_Error_When_AgreeToTerms_Is_False()
    {
        var model = new RegisterUserCommand { AgreeToTerms = false };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.AgreeToTerms);
    }

    [Fact]
    public void Should_Have_Error_When_CountryId_Is_Less_Than_Or_Equal_To_Zero()
    {
        var model = new RegisterUserCommand { CountryId = 0 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.CountryId);
    }

    [Fact]
    public void Should_Have_Error_When_ProvinceId_Is_Less_Than_Or_Equal_To_Zero()
    {
        var model = new RegisterUserCommand { ProvinceId = 0 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ProvinceId);
    }
}