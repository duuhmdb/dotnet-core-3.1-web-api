using System;

namespace TechSolution.Business.Interfaces
{
    public interface IUserService
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
    }
}
