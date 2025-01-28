using PROJECT.IRepository.Interfaces.Security;
using PROJECT.IService.Interfaces.Security;
using PROJECT.Model.Security;
using PROJECT.Service.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Service.Services.Security
{
    public class UserService: GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
