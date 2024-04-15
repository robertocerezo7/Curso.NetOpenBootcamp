namespace APIVersionControl.DTO
{
    

    public class User
    {

        public string? id { get; set; }
        public string? title { get; set; }
        public string? fistname { get; set; }
        public string? lastname { get; set; }
        public string? picture { get; set; }

    }

    public class UsersResponseData
    {

        public User[]? data { get; set; }
        public int  total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }

    }
}
