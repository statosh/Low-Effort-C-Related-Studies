public class UserService : IUserService {
    public string GetUserInfo(int id) {
        return GetUserInfo(id, "default");
    }

    public string GetUserInfo(int id, string additionalInfo) {
        return $"User ID: {id}, Info: {additionalInfo}";
    }
}