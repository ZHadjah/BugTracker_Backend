using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker_Backend.Models.Enums
{
    public enum BTTicketType
    {
        [Display(Name = "New Development")]
        NewDevelopment,

        [Display(Name = "Work Task")]
        WorkTask,

        Defect,

        [Display(Name = "Change Request")]
        ChangeRequest,

        Enhancement,

        [Display(Name = "General Task")]
        GeneralTask
    }
}