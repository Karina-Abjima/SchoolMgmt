using School_management.Models;

namespace School_management.Data
{
    public interface IUserRepository
    {
        public Task<bool> ValidateCredentials(LoginUser loginuser);
    }
}
