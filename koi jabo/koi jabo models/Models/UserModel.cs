using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace koi_jabo.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string FacebookProfileLink { get; set; }
        public string FacebookProfilePhotoLink { get; set; }
        public string GoogleProfileLink { get; set; }
        public string GoogleProfilePhotoLink { get; set; }

    }
}