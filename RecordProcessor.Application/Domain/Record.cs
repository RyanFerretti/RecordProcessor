using System;

namespace RecordProcessor.Application.Domain
{
    public class Record
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
