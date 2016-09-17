using System;
using MediatR;

namespace BeaverLeague.Web.Features.Admin.ManageGolfers
{
    public class AllGolfersQuery : IRequest<string>
    {
    }

    public class AllGolfersQueryHandler : IRequestHandler<AllGolfersQuery, string>
    {
        public string Handle(AllGolfersQuery message)
        {
            return "hello!";
        }
    }
}