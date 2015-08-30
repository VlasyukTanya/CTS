using System;
using DBLibrary;

namespace DBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DBDriver db = new DBDriver(@"SQL5016.Smarterasp.net", @"DB_9D003D_cts1_admin", @"cts1CoolDbUser", @"db_9d003d_cts1");
            Console.WriteLine("Created Object DBDriver with Connection String: " + db.ConnString);

            User user = new User(db);
            try
            {
                Console.WriteLine("New Empty User instance: \n" + user);

                user.Name = "my_new_user_vasya";
                user.Password = "123456";
                user.RealName = "Василий Пупкин";
                user.RoleId = 1;
                user.GroupId = 1;
                user.Email = "my_new_user_vasya@email.com";
                Console.WriteLine("User Created: \n" + (user = user.Create()));

                Console.WriteLine("Check if User 'my_new_user_vasya' with password '123456' exists: " + user.CheckIfExists());
                Console.WriteLine("Login Under User 'my_new_user_vasya' with password '123456'" + user.SignIn());

                Console.WriteLine("Get user with this id from database: \n" + (user = user.Get(user.Id)));

                user.RealName = "Не Василий Не Пупкин";
                user.AddContact("skype", "vasya_pupkin");
                user.AddContact("twitter", "vasya_twitter");
                user.Update();
                Console.WriteLine("Update user with current id: \n" + (user = user.Update()));

                user.ChangePassword("123456789");
                Console.WriteLine("Changed Paddword for user with current id: \n" + (user = user.Get(user.Id)));

                user.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                user.Delete();
            }
        }
    }
}
