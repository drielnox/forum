namespace drielnox.Forum.Business.Entities
{
    public sealed class User
    {
        public int Identifier { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
