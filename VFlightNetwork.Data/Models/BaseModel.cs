using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VFlightNetwork.Data.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseModel()
        {
            this.Id = Guid.NewGuid();
            this.CreationDate = DateTime.Now;
        }
    }
}
