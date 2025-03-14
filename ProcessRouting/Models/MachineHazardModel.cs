using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineHazard.Models
{
    [Table("machineHazard")]

    public class MachineHazardModel
    {

        [Key]
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "Machine")]
        public string? machine { get; set; }

        [Display(Name = "FileMachine")]
        public string? filemachine { get; set; }

        [Display(Name = "rev")]
        public string? rev { get; set; }

        [Display(Name = "Status")]
        public string? status { get; set; }
    }
}
