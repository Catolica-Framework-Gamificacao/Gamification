using Api.Models.Enums;

namespace Api.Models;

public class UserTypeModel
{
    public UserTypeModel(long id, int type)
    {
        var userType = GetUserTypeByLogical(type);
        this.UserId = id;
        this.Type = userType;
    }

    private static UserType? GetUserTypeByLogical(int type)
    {
        UserType? userType = type switch
        {
            0 => UserType.Student,
            1 => UserType.Teacher,
            2 => UserType.Admin,
            _ => null
        };

        return userType;
    }

    public static int GetLogicalByUserType(UserType? type)
    {
        if (type == null)
        {
            throw new ArgumentException("User type cannot be null");
        }   
        var typeCode = type switch
        {
            UserType.Student => 0,
            UserType.Teacher => 1,
            UserType.Admin => 2,
            _ => throw new Exception("User type not found")
        };

        return typeCode;
    }

    public long UserId { get; set; }
    public UserType? Type { get; set; }
}