using koi_jabo.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace koi_jabo.Entity
{
    public class UserEntity : UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(UserModel model)
        {
            this.Name = model.Name;
            this.Email = model.Email;
            this.Gender = model.Gender;
            this.PhoneNumber = model.PhoneNumber;
            this.Address = model.Address;
            this.Age = model.Age;
            this.FacebookProfileLink = model.FacebookProfileLink;
            this.FacebookProfilePhotoLink = model.FacebookProfilePhotoLink;
            this.GoogleProfileLink = model.GoogleProfileLink;
            this.GoogleProfilePhotoLink = model.GoogleProfilePhotoLink;
        }
    }
}