namespace SubRefactor.Domain
{
    public class User
    {
        protected User() { }

        public User(AuthenticationType authenticationType)
        {
            AuthenticationType = authenticationType;
            AuthenticationTypeId = (int)authenticationType;
        }
        
        public int Id { get; set; }
        public string Username { get; set; }        
        public int AuthenticationTypeId { get; private set; }
        public AuthenticationType AuthenticationType { get; set; }
        public string Password { get; set; }
        public CreateStatus CreateStatus { get; private set; }
        public int CreateStatusId { get; set; }
    }
}
