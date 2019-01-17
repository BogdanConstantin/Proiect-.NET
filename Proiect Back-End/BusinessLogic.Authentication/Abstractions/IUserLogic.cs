using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Authentication.Abstractions
{
    using Entities.Authentication;

    using Models.Authentication;

    public interface IUserLogic
    {
        User Authenticate(string username, string password);

        IEnumerable<UserInformationsDto> GetAll();

        UserInformationsDto GetById(Guid id);

        User Create(UserDto user, string password);
    }
}
