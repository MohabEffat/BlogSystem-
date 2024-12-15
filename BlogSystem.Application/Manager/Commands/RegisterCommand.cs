using BlogSystem.Application.Dtos;
using MediatR;

namespace BlogSystem.Application.Manager.Commands
{
    public class RegisterCommand : IRequest<ResponseDto>
    {
        public RegisterDto Register { get; }

        public RegisterCommand(RegisterDto register)
        {
            Register = register;
        }
    }
}
