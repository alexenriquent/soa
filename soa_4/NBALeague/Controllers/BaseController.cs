using NBALeague.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NBALeague.Controllers {

    public abstract class BaseController : ApiController {

        protected virtual void UpdatePlayers(List<Player> players) {
            string playerRecords = string.Empty;
            foreach (Player player in players) {
                playerRecords += player.Registration_ID + ',' + player.Player_name + ','
                                + player.Team_name + ',' + player.Date_of_birth.Year + '-'
                                + player.Date_of_birth.Month + '-' + player.Date_of_birth.Day + '\n';
            }
            try {
                File.WriteAllText(HttpRuntime.AppDomainAppPath + "players.txt", playerRecords.Substring(0, playerRecords.Length - 1));
            } catch (IOException) {}
        }
    }
}
