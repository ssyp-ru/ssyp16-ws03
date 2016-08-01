using IFK.Server.DataTypes.Issues;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IFK.Server.Managers
{
    /// <summary>
    /// Class created to manage issues.
    /// </summary>
    public static class IssuesManager
    {
        /// <summary>
        /// Gets all issues.
        /// </summary>
        /// <returns>All issues</returns>
        public static IEnumerable<Issue> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Issues.ToArray();
            }
        }

        /// <summary>
        /// Gets issue by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Issue</returns>
        public static Issue Get(long id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Issues.SingleOrDefault(issue => id == issue.ID);
            }
        }

        /// <summary>
        /// Adds issue.
        /// </summary>
        /// <param name="issue"></param>
        /// <returns>Added issue</returns>
        public static Issue Add(Issue issue)
        {
            if (0 == issue.UserID)
                return default(Issue);
            else
                using (var context = new DatabaseContext())
                {
                    context.Issues.Add(issue);
                    context.SaveChanges();

                    issue.Key += "-" + issue.ID.ToString();
                    context.SaveChanges();

                    return issue;
                }
        }

        /// <summary>
        /// Replaces the issue.
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Updated issue</returns>
        public static Issue Edit(Issue update)
        {
            using (var context = new DatabaseContext())
            {
                var issue = Get(update.ID);

                issue.UpdateData(update);
                context.Entry(issue).State = EntityState.Modified;
                context.SaveChanges();

                return issue;
            }
        }

        /// <summary>
        /// Removes the issue found by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success of operation</returns>
        public static bool Remove(long id)
        {
            using (var context = new DatabaseContext())
            {
                var issue = context.Issues.SingleOrDefault(i => id == i.ID);

                context.Issues.Remove(issue);
                context.SaveChanges();

                return true;
            }
        }
    }
}
