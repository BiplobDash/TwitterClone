namespace TwitterClone.Domain.Entities
{
    public class User
    {
        private Guid _id;
        private string _username;
        private string _email;

        public Guid Id {  get { return _id; } }
        public string UserName { get { return _username; } set { _username = value; } }
        public string Email { get { return _email; } set { _email = value; } }

    }
}
