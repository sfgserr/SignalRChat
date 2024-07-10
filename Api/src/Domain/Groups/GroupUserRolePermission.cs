
namespace Domain.Groups
{
    public class GroupUserRolePermission
    {
        public GroupUserRolePermission(int groupUserRoleId, string groupUserPermissionCode)
        {
            GroupUserRoleId = groupUserRoleId;
            Code = groupUserPermissionCode;
        }

        private GroupUserRolePermission()
        {

        }

        public int GroupUserRoleId { get; }

        public string Code { get; } 
    }
}
