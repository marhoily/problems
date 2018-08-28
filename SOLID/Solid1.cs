public abstract class MembershipProvider : ProviderBase
{
    public abstract bool EnablePasswordRetrieval { get; }
    public abstract bool EnablePasswordReset { get; }
    public abstract bool RequiresQuestionAndAnswer { get; }
    public abstract string ApplicationName { get; set; }
    public abstract int MaxInvalidPasswordAttempts { get; }
    public abstract int PasswordAttemptWindow { get; }
    public abstract bool RequiresUniqueEmail { get; }
    public abstract MembershipPasswordFormat PasswordFormat { get; }
    public abstract int MinRequiredPasswordLength { get; }
    public abstract int MinRequiredNonAlphanumericCharacters { get; }
    public abstract string PasswordStrengthRegularExpression { get; }

    public abstract MembershipUser CreateUser(
        string username,
        string password,
        string email,
        string passwordQuestion,
        string passwordAnswer,
        bool   isApproved,
        object providerUserKey,
        out MembershipCreateStatus status);

    public abstract bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);
    public abstract string GetPassword(string username, string answer);
    public abstract bool ChangePassword(string username, string oldPassword, string newPassword);
    public abstract string ResetPassword(string username, string answer);
    public abstract void UpdateUser(MembershipUser user);
    public abstract bool ValidateUser(string username, string password);
    public abstract bool UnlockUser( string userName );
    public abstract MembershipUser GetUser( object providerUserKey, bool userIsOnline );
    public abstract MembershipUser GetUser(string username, bool userIsOnline);
    public abstract string GetUserNameByEmail(string email);
    public abstract bool DeleteUser(string username, bool deleteAllRelatedData);
    public abstract MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);
    public abstract int GetNumberOfUsersOnline();
    public abstract MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
    public abstract MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);
}
