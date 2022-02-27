using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_D_argent.Models

{
    public class Journal_Acounts
    {
        [Key]
        public int JAId { get; set; }

        [ForeignKey("AccountsviewModel")]
        public int JournalId { get; set; }  
        public virtual Journalize Journalize { get; private set; }

        [DataType(DataType.Currency)]
        public double Debit { get; set; }

        [DataType(DataType.Currency)]
        public double Credit { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public string AccountName1 { get; set; }

        public string AccountName2 { get; set; }

        [NotMapped]
        public double AccountNumber1 { get; set; }

        [NotMapped]
        public double AccountNumber2 { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AccountList { get; set; }

        [NotMapped]
        public bool IsApproved { get; set; }

        public string Reason { get; set; }

        public bool IsRejected { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public string Type { get; set; }

        [NotMapped]
        public string SelectedType { get; set; }



    }
}
