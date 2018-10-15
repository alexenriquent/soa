using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace NBALeague.Models {

    public class NBALeagueContext : DbContext {

        public NBALeagueContext() : base("name=NBALeagueContext") {
            Database.SetInitializer(new NBALeagueInitialiser());
        }

        public System.Data.Entity.DbSet<NBALeague.Models.Player> Players { get; set; }
    }

    public class NBALeagueInitialiser : DropCreateDatabaseAlways<NBALeagueContext> {

        protected override void Seed(NBALeagueContext context) {
            List<Player> players = new List<Player>();
            string[] playerRecords = new string[0];
            try {
                playerRecords = File.ReadAllLines(HttpRuntime.AppDomainAppPath + "players.txt");
            } catch (IOException) {}

            foreach (string playerRecord in playerRecords) {
                string[] attributes = playerRecord.Split(',');
                int[] date = attributes[3].Split('-').Select(int.Parse).ToArray();
                Player player = new Player() {
                    Registration_ID = attributes[0],
                    Player_name = attributes[1],
                    Team_name = attributes[2],
                    Date_of_birth = new DateTime(date[0], date[1], date[2])
                };
                players.Add(player);
            }

            foreach (Player player in players) {
                context.Players.Add(player);
            }

            base.Seed(context);
        }
    }
}
