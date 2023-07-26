using System.ComponentModel.DataAnnotations.Schema;

namespace API_bank.Models
{
    [Table("conta", Schema = "contacorrente")]
    public partial class Conta : BaseEntity
    {
        public double saldo { get; set; }
    }
}
