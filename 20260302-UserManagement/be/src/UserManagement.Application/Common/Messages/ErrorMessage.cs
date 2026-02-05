using System;

namespace UserManagement.Application.Common.Messages;

public static class ErrorMessage
{
    public static string ObjectNotFound(object value, string objName = "") => $"{objName} '{value}' was not found.";
    public static string ObjectExisted(object value, string objName = "") => $"{objName} '{value}' already exists.";

    public static string ObjectCanNotBeModified(object value, string objName = "") => $"{objName} '{value}' cannot be modified.";
    public static string ObjectCanNotBeDeleted(object value, string objName = "") => $"{objName} '{value}' cannot be deleted.";
    public static string ObjectCanNotBeUpdated(object value, string objName = "") => $"{objName} '{value}' cannot be updated.";
    public static string ObjectIsInOtherProcess(object value, string objName = "") => $"{objName} '{value}' cannot be deleted because it is currently being processed.";

    public static string ObjectCanNotBeNullOrEmpty(string objName = "") => $"{objName} must not be empty.";
    public static string ServerError() => "An error occurred. Please try again.";
}
