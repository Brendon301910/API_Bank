using API_bank.Interfaces;
using System;

namespace API_bank.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int id { get; set; }
        public int conta { get; set; }
        public DateTime? data_criacao { get; set; }

    }
}
