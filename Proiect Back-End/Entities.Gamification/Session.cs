using System;

namespace Entities.Gamification
{
    public class Session : BaseEntity
    {
        public string Question { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
