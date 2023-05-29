using Api.Models;
using Api.Models.Enums;

namespace Tests.Api.Models;

public class UserTypeModelTest
{
    #region GetUserTypeByLogical

    [Theory(DisplayName = "Valor lógico de zero deve retornar o enum de Estudante")]
    [InlineData(0)]
    public void LogicalTypeZeroMustReturnStudentUserType(int logical)
    {
        var userType = UserTypeModel.GetUserTypeByLogical(logical);
        Assert.NotNull(userType);
        Assert.Equal(UserType.Student, userType);
    }
    
    [Theory(DisplayName = "Valor lógico de um deve retornar o enum de Professor")]
    [InlineData(1)]
    public void LogicalTypeOneMustReturnTeacherUserType(int logical)
    {
        var userType = UserTypeModel.GetUserTypeByLogical(logical);
        Assert.NotNull(userType);
        Assert.Equal(UserType.Teacher, userType);
    }
    
    [Theory(DisplayName = "Valor lógico de dois deve retornar o enum de Administrador")]
    [InlineData(2)]
    public void LogicalTypeTwoMustReturnAdminUserType(int logical)
    {
        var userType = UserTypeModel.GetUserTypeByLogical(logical);
        Assert.NotNull(userType);
        Assert.Equal(UserType.Admin, userType);
    }

    #endregion
    
    #region GetLogicalByUserType
    
    [Theory(DisplayName = "Enum `UserType` quando nulo deve soltar uma exceção")]
    [InlineData(null)]
    public void UserTypeWhenNullMustThrowAnArgumentException(UserType? userType)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            UserTypeModel.GetLogicalByUserType(userType);
        });
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal("User type cannot be null", exception.Message);
    }
    
    [Theory(DisplayName = "Enum `UserType` deve retornar o lógico `0` quando possuir o valor `Student`")]
    [InlineData(UserType.Student)]
    public void UserTypeStudentMustReturnTheLogicalValueZero(UserType? userType)
    {
        var logical = UserTypeModel.GetLogicalByUserType(userType);
       Assert.Equal(0, logical);
    }
    
    [Theory(DisplayName = "Enum `UserType` deve retornar o lógico `1` quando possuir o valor `Teacher`")]
    [InlineData(UserType.Teacher)]
    public void UserTypeTeacherMustReturnTheLogicalValueOne(UserType? userType)
    {
        var logical = UserTypeModel.GetLogicalByUserType(userType);
        Assert.Equal(1, logical);
    }
    
    [Theory(DisplayName = "Enum `UserType` deve retornar o lógico `2` quando possuir o valor `Admin`")]
    [InlineData(UserType.Admin)]
    public void UserTypeAdminMustReturnTheLogicalValueTwo(UserType? userType)
    {
        var logical = UserTypeModel.GetLogicalByUserType(userType);
        Assert.Equal(2, logical);
    }
    
    #endregion
    
}