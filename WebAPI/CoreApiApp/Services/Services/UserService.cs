using DataModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using MongoDB.Driver;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.Services
{
    public class UserService: IUserService
    {
        private readonly IMongoCollection<UserModel> _userModels;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("UserDB"));
            var database = client.GetDatabase("UserDB");
            _userModels = database.GetCollection<UserModel>("Users");
        }

        public List<UserModel> Get()
        {
            return _userModels.Find(userModel => true).ToList();
        }

        public UserModel Get(string id)
        {
            return _userModels.Find<UserModel>(userModel => userModel.UserID == id).FirstOrDefault();
        }

        public UserModel Create(UserModel userModel)
        {
            userModel.UserID = Guid.NewGuid().ToString().Replace('-','0');
            _userModels.InsertOne(userModel);
            return userModel;
        }

        public void Update(string id, UserModel userModelIn)
        {
            userModelIn.UserID = id;
            _userModels.ReplaceOne(userModel => userModel.UserID == id, userModelIn);
        }

        public void Remove(UserModel userModelIn)
        {
            _userModels.DeleteOne(userModel => userModel.UserID == userModelIn.UserID);
        }

        public void Remove(string id)
        {
            _userModels.DeleteOne(userModel => userModel.UserID == id);
        }
        
    }
}
