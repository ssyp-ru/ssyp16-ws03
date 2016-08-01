using IFK.Server.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IFK.Server.Managers
{
    /// <summary>
    /// Class created to manage users.
    /// </summary>
    public static class UsersManager
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users</returns>
        public static IEnumerable<User> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.ToArray();
            }
        }
        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public static User Get(long id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.SingleOrDefault(user => id == user.ID);
            }
        }
        /// <summary>
        /// Gets user by token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>User</returns>
        public static User GetByToken(string token)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.SingleOrDefault(user => token == user.AccessToken);
            }
        }
        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        public static User GetByEmail(string email)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.SingleOrDefault(user => email == user.Email);
            }
        }

        /// <summary>
        /// Checks user opportunity to get accees to server.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Boolean answer</returns>
        public static bool CheckAccess(string token)
        {
            using (var context = new DatabaseContext())
            {
                return default(User) != context.Users.SingleOrDefault(user => token == user.AccessToken);
            }
        }
        /// <summary>
        /// Sings up user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Access token.</returns>
        public static string SignUp(string email, string password)
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.SingleOrDefault(u => email == u.Email);

                if (default(User) == user)
                {
                    var accessToken = Guid.NewGuid().ToString();

                    user = new User()
                    {
                        Email = email,
                        Password = password,
                        AccessToken = accessToken
                    };
                    context.Users.Add(user);
                    context.SaveChanges();

                    return accessToken;
                }
                else
                    return string.Empty;
            }
        }
        /// <summary>
        /// Logs in user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Access token.</returns>
        public static string Login(string email, string password)
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.SingleOrDefault(u => email == u.Email && password == u.Password);

                if (default(User) == user)
                    return string.Empty;
                else
                {
                    return user.AccessToken;
                }
            }
        }

        /// <summary>
        /// Changes user's password.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns>Success of operation</returns>
        public static bool ChangePassword(long id, string password)
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.SingleOrDefault(u => id == u.ID);

                user.Password = password;
                context.SaveChanges();

                return true;
            }
        }
        /// <summary>
        /// Resets user's password
        /// </summary>
        /// <param name="id"></param>
        /// <returns>New password</returns>
        public static string ResetPassword(long id)
        {
            //var password = Convert.ToString(Guid.NewGuid());
            var password = "Valentin";
            ChangePassword(id, password);

            return password;
        }

        /// <summary>
        /// Finds user by id, squad by key and adds user to this squad.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns>Squad</returns>
        public static Squad JoinToSquad(long id, string key)
        {
            using (var context = new DatabaseContext())
            {
                var squad = context.Squads.Include("Composition").SingleOrDefault(s => key == s.Key);
                if (default(Squad) == squad)
                {
                    return squad;
                }

                squad.Composition.Add(context.Users.SingleOrDefault(u => id == u.ID));
                context.SaveChanges();

                return squad;
            }
        }

    }
}
