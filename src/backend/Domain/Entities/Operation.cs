using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendECOTVOS.Domain.Entities
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequesterLogistic")]
        public int RequesterLogisticId { get; set; }

        [ForeignKey("ResponsibleLogistic")]
        public int ResponsibleLogisticId { get; set; }

        public char Type { get; set; }
        public DateTime BeginHour { get; set; }
        public TimeOnly EstimatedDuration { get; set; }
        public TimeOnly? Duration { get; set; }
        public char Status { get; set; }

        // Navigation properties
        public Logistic? RequesterLogistic { get; set; }
        public Logistic? ResponsibleLogistic { get; set; }
        public ICollection<OperationMaterials>? OperationMaterials { get; set;}
    }
}
