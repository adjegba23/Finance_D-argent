using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_D_argent.Models
{
    public class Journalize
    {
        [Key]
        public int JournalId { get; set; }
        public bool IsApproved { get; set; }

        [NotMapped]
        public double AccountNumber { get; set;}

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AccountList { get; set; }

        public virtual List<Journal_Accounts> Journal_Accounts { get; set; } = new List<Journal_Accounts>();

        public string docUrl { get; set; }
        public string Reason { get; set; }

        [NotMapped]
        public IFormFile Document { get; set; }

        public bool IsRejected { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool IsCJE { get; set; }
        
    }
}
