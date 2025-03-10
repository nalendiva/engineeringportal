using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkStandar.Models
{
    [Table("workStandarMasterlist")]
    public class WorkStandarModel

    {
        [Key]
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "WS Number")]
        public string? wsNumber { get; set; }

        [Display(Name = "Description")]
        public string? description { get; set; }

        [Display(Name = "Owner")]
        public string? owner { get; set; }

        [Display(Name = "Date Effective")]
        public string? dateEffective { get; set; }

        [Display(Name = "Expire Date")]
        public string? expireDate { get; set; }

        [Display(Name = "File WS")]
        public string? fileWs { get; set; }

        [Display(Name = "Note")]
        public string? note { get; set; }


    }
}
