namespace SpeakerMeet.DTO
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string EmailAddress { get; set; }
    }
}
