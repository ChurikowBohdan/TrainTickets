using System.Threading.Tasks;
using Abp.Application.Services;
using TrainTickets.Roles.Dto;

namespace TrainTickets.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
