namespace HoistFinance.Contract.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Requests")]
    public class RequestModel
    {
        [Key]
        public int Index { get; set; }
        public string Name { get; set; }
        public int? Visits { get; set; }
        public DateTime Date { get; set; }
    }
}