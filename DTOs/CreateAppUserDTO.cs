namespace DTOs
{
    public class CreateAppUserDTO
    {
        public string AppUserName { get; set; }
        public string AppUserEmail { get; set; }
        public DateOnly AppUserBirthDay { get; set; }
        public string AppUserPasseword {  get; set; }
    }
}
