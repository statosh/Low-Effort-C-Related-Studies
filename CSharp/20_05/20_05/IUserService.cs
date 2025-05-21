public interface IUserService {
    string GetUserInfo(int id);
    string GetUserInfo(int id, string additionalInfo);
}