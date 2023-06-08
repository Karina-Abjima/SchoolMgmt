using Microsoft.AspNetCore.Mvc;
using School_management.Models;

namespace School_management.Data
{
    public interface ISignupRepository
    {

        public Task <Boolean> PostUserData(User user);
    }
}
