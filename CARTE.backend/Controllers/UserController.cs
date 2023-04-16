using AutoMapper;
using CARTE.backend.Core.Infrastructure.Users.Commands.CreateUser;
using CARTE.backend.Core.Infrastructure.Users.Queries.GetUserDetail;
using CARTE.backend.Core.Infrastructure.Users.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace CARTE.backend.Controllers
{

    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserVm>> GetUserDetail(Guid userId)
        {
            var query = new GetUserDetailQuery { UserId = userId };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{email}./{password}")]
        public async Task<ActionResult<Guid>> Login(string email, string password)
        {
            var query = new LoginUserCommand
            {
                Email = email,
                Password = password
            };

            var id = await Mediator.Send(query);
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand createUser)
        {
            var command = createUser;
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
