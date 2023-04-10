using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Models
{
    public class FinancialReleaseModel
    {
        [Key]
        public int Id { get; set; }
        public int OperationId { get; set; }
        public string? CNPJ { get; set; }
        [StringLength(150, MinimumLength = 8)]
        public string? Name { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
        [StringLength(10)]
        public string? ZipCode { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        [StringLength(2)]
        public string? State { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? District { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public string? Number { get; set; }



    }
}
