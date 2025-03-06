using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessRouting.Models
{
    [Table("engineeringPortal_processRouting")]
    public class ProcessRoutingModel

    {
        [Key]
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "Process Type")]
        public string? processType { get; set; }

        [Display(Name = "Op Number")]
        public string? opNumber { get; set; }

        [Display(Name = "workcenter")]
        public string? workcenter { get; set; }

        [Display(Name = "Process Description (Short)")]
        public string? processDescriptionShort { get; set; }

        [Display(Name = "Process Description (Long)")]
        public string? processDescriptionLong { get; set; }

        [Display(Name = "Process Spec")]
        public string? processSpec { get; set; }

        [Display(Name = "Process Instruction")]
        public string? processInstruction { get; set; }

        [Display(Name = "Checking Chart")]
        public string? checkingChart { get; set; }

        [Display(Name = "KC")]
        public string? kc { get; set; }

        [Display(Name = "Fixture")]
        public string? fixture { get; set; }

        [Display(Name = "Notes")]
        public string? notes { get; set; }
    }
}
