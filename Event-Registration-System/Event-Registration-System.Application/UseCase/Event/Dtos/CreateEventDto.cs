using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Event.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class CreateEventDto
    {
        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public required string Location { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "End date is required")]
        public required DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Seats available is required")]
        public required int SeatsAvailable { get; set; }
    }


}
