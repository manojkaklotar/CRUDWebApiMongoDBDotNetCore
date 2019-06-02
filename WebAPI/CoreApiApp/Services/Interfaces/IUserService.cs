using DataModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserModel Create(UserModel userModel);
        UserModel Get(string i);
        List<UserModel> Get();
        void Remove(string id);
        void Remove(UserModel userModel);
        void Update(string id, UserModel userModel);
    }
}
