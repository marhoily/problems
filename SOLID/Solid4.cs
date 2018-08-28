public class UserService
{
     public void Register(string email, string password)
     {
          if (!email.Contains("@"))
              throw new ValidationException("Email is not an email!");
 
         var user = new User(email, password);
         _database.Save(user);
 
         _smtpClient.Send(new MailMessage("mysite@nowhere.com", email){Subject="HEllo fool!"});
     }
} 
