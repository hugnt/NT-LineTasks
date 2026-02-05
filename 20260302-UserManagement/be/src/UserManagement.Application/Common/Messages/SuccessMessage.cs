namespace UserManagement.Application.Common.Messages;

public class SuccessMessage
{
    public static string CreatedSuccessfully(string objName = "") => $"{objName} was created successfully.";
    public static string UpdatedSuccessfully(string objName = "") => $"{objName} was updated successfully.";
    public static string UpdatedSuccessfully(Guid id, string objName = "") => $"{objName} with id = {id} was updated successfully.";
    public static string DeletedSuccessfully(Guid id, string objName = "") => $"{objName} with id = {id} was deleted successfully.";
    public static string DeletedSuccessfully(string objName = "") => $"{objName} was deleted successfully.";
}