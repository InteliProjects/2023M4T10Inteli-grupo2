using System;
using System.Collections.Generic;

namespace BackendECOTVOS.Domain.ViewModels
{
    public class OperationViewModel
    {
        public int RequesterOperatorId { get; set; }
        public int ResponsibleOperatorId { get; set; }
        public List<int>? AssociatedMaterialsIds { get; set; }
        public char Type { get; set; }
        public TimeOnly EstimatedDuration { get; set; }
    }
}
