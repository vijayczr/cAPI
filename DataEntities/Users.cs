
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication1.DataEntities
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 0)]
        public int Id { get; set; }
        public string? code { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Number { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }

    }
}
