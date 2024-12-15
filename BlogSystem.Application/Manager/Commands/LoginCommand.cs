using BlogSystem.Application.Dtos;
using MediatR;

namespace BlogSystem.Application.Manager.Commands
{
    public class LoginCommand : IRequest<ResponseDto>
    {
        public LoginDto LoginDto;

        public LoginCommand(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
