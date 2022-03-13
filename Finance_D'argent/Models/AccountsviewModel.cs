using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_D_argent.Models
{
    public class AccountsviewModel
    {
        [Required]
        [Display(Name ="Account Name")]
        public string AccountName { get; set; } 
        public string? NormalSide { get; set; }

        [Key]
        [Display(Name ="Account Number")]
        public int? AccountNumber { get; set; }

        public string Description { get; set; } 

        public DateTime DateCreatedOn { get; set; }
        
        public string UserName { get; set; }  

        [DataType(DataType.Currency)]
        public double? InitialBalance { get; set; }

        [Required]
        public string Category { get; set; }

        public string SubCategory { get; set; }

        [DataType(DataType.Currency)]
        public double Debit { get; set; }

        [DataType(DataType.Currency)]
        public double Credit { get; set; }

        public string Balance { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Accounts { get; set; }

        [Required]
        public int Order { get; set; }
        public string Statement { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public bool Contra { get; set; }

        public bool ChartsOfAccounts { get; set; }

    }
}
