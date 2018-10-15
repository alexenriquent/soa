using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NBALeague.Models;

namespace NBALeague.Controllers {

    public class NBALeagueController : BaseController {

        private NBALeagueContext db = new NBALeagueContext();

        // GET: api/NBALeague
        public IQueryable<Player> GetPlayers() {
            return db.Players;
        }

        // GET: api/NBALeague/id
        [ResponseType(typeof(IEnumerable<Player>))]
        public IHttpActionResult GetPlayersByID(string id) {
            var players = from x in db.Players select x;
            players = players.Where(x => x.Registration_ID.Contains(id));

            if (players.Count() == 0) {
                return NotFound();
            }
            return Ok(players);
        }

        // GET: api/NBALeague?name=name
        [ResponseType(typeof(IEnumerable<Player>))]
        public IHttpActionResult GetPlayersByName(string name) {
            var players = from x in db.Players select x;
            players = players.Where(x => x.Player_name.Contains(name));

            if (players.Count() == 0) {
                return NotFound();
            }
            return Ok(players);
        }

        // PUT: api/NBALeague/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(string id, Player player)  {
            if (!ModelState.IsValid)  {
                return BadRequest(ModelState);
            }

            if (id != player.Registration_ID) {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try  {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PlayerExists(id)) {
                    return Content(HttpStatusCode.NotFound, "This player does not exist in the system!");
                }
                else {
                    throw;
                }
            }

            UpdatePlayers(db.Players.ToList());

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NBALeague
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);

            try  {
                db.SaveChanges();
            }
            catch (DbUpdateException) {
                if (PlayerExists(player.Registration_ID)) {
                    return Content(HttpStatusCode.Conflict, "This player has already existed in the system!");
                }
                else {
                    throw;
                }
            }

            UpdatePlayers(db.Players.ToList());

            return CreatedAtRoute("DefaultApi", new { id = player.Registration_ID }, player);
        }

        // DELETE: api/NBALeague/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(string id) {
            Player player = db.Players.Find(id);
            if (player == null) {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();
            UpdatePlayers(db.Players.ToList());

            return Ok(player);
        }

        // DELETE: api/NBALeague?name=name
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayerByName(string name) {
            Player player = db.Players.ToList().Find(x => x.Player_name.ToLower() == name.ToLower());

            if (player == null) {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();
            UpdatePlayers(db.Players.ToList());

            return Ok(player);
        }

        protected override void Dispose(bool disposing) {
            if (disposing)  {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(string id) {
            return db.Players.Count(e => e.Registration_ID == id) > 0;
        }
    }
}