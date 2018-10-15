using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBALeague.Models {

    public class Player {

        [Key]
        [Required]
        public string Registration_ID { get; set; }
        [Required]
        public string Player_name { get; set; }
        [Required]
        public string Team_name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date_of_birth { get; set; }
    }
}