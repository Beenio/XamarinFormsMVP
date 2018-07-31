using Realms;
using System;

namespace XamarinFormsMVP.Model.Entity
{
    public class UserEntity : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Age { get; set; }
    }
}
