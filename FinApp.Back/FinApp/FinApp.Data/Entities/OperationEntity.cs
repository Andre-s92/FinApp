using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Data.Entities
{
    public class OperationEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string? Description { get; set; }
        [StringLength(20)]
        public string? Status { get; set; }
        public IEnumerable<FinancialReleaseEntity>? FinancialRelease { get; set; }
    }
}
