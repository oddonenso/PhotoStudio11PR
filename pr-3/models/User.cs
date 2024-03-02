namespace pr_3.models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string otchestvo { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string userlogin { get; set; }
        public string user_password { get; set; }
        public int role_id { get; set; }
        public Nullable<int> GenderId { get; set; }
        public byte[] Image { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
    }
}