using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataModel.Model
{
    public class UserModel
    {
        [BsonId]
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Mobile { get; set; }
    }
}
