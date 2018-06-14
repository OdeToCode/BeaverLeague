//using System.ComponentModel.DataAnnotations;
//using System.Threading;
//using System.Threading.Tasks;
//using BeaverLeague.Web.Security;
//using MediatR;

//namespace BeaverLeague.Web.Features.Account
//{
//    public class LoginUserCommand : IRequest<SignInResult>
//    {
//        [Required]
//        [Display(Name = "Email Address")]
//        public string EmailAddress { get; set; }

//        [Required, DataType(DataType.Password)]
//        public string Password { get; set; }

//        [Required]
//        [Display(Name = "Remember Me?")]
//        public bool RememberMe { get; set; }
//    }

//    public class LoginUserCommandHandler : 
//        IRequestHandler<LoginUserCommand, SignInResult>
//    {
//        private readonly SignInManager _signInManager;

//        public LoginUserCommandHandler(SignInManager signInManager)
//        {
//            _signInManager = signInManager;
//        }

//        public async Task<SignInResult> Handle(LoginUserCommand command, CancellationToken cancel = default(CancellationToken))
//        {
//            var result = await _signInManager.SignInGolferAsync(
//                command.EmailAddress,
//                command.Password,
//                command.RememberMe);
//            return result;
//        }      
//    }
//}
