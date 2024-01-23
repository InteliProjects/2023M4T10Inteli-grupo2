using System;
using System.Collections.Generic;

namespace BackendECOTVOS.Domain.DTOs
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string Status { get; set; }
        public required string RequesterOperatorName { get; set; }
        public required string RequesterOperatorFunction { get; set; }
        public required string RequesterVehicleDescription { get; set; }
        public required string ResponsibleOperatorName { get; set; }
        public required string ResponsibleOperatorFunction { get; set; }
        public required string ResponsibleVehicleDescription { get; set; }
        public List<string>? AssociatedMaterialsDescriptions { get; set; }
        public DateTime? BeginHour { get; set; }
        public TimeOnly EstimatedDuration { get; set; }
        public TimeOnly? Duration { get; set; }
    }
}
