using System;
namespace WcfService2
{
    public class UserForm
    {
        int id;
        string character;
        string actor;
        string house;
        string doa;

        public int Id { get => id; set => id = value; }
        public string Character { get => character; set => character = value; }
        public string Actor { get => actor; set => actor = value; }
        public string House { get => house; set => house = value; }
        public string DOA { get => doa; set => doa = value; }

    }
}

