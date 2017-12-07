namespace TFP.Domain.Entities
{
    public class PermissionSetPermission
    {
        public int PermissionSetId { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
        public PermissionSet PermissionSet { get; set; }
    }
}
