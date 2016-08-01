using IFK.Server.DataTypes;
using System.Collections.Generic;
using System.Linq;

namespace IFK.Server.Managers
{
    /// <summary>
    /// Class created to manage squads.
    /// </summary>
    public static class SquadsManager
    {
        /// <summary>
        /// Gets all squads.
        /// </summary>
        /// <returns>All squads</returns>
        public static IEnumerable<Squad> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.Squads.ToArray();
            }
        }

        /// <summary>
        /// Gets squad by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Squad</returns>
        public static Squad Get(long id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Squads.Include("Composition").Include("Issues").SingleOrDefault(squad => id == squad.ID);
            }
        }

        /// <summary>
        /// Adds squad.
        /// </summary>
        /// <param name="squad"></param>
        /// <returns>Added squad</returns>
        public static Squad Add(Squad squad)
        {
            using (var context = new DatabaseContext())
            {
                context.Squads.Add(squad);
                context.SaveChanges();

                return squad;
            }
        }

        /// <summary>
        /// Replaces the squad.
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Updated squad</returns>
        public static Squad Edit(Squad update)
        {
            using (var context = new DatabaseContext())
            {
                var squad = context.Squads.SingleOrDefault(s => update.ID == s.ID);

                squad.UpdateData(update);
                context.SaveChanges();

                return squad;
            }
        }

        /// <summary>
        /// Removes the squad found by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success of operation</returns>
        public static bool Remove(long id)
        {
            using (var context = new DatabaseContext())
            {
                var squad = context.Squads.SingleOrDefault(s => id == s.ID);

                context.Squads.Remove(squad);
                context.SaveChanges();

                return true;
            }
        }
    }
}
