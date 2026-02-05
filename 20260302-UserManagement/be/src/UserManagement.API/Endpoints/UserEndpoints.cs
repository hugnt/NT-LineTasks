using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Endpoints.Base;
using UserManagement.Application.Models;
using UserManagement.Application.Models.Requests;
using UserManagement.Application.Services;
using UserManagement.Base.API;

namespace UserManagement.API.Endpoints;

public class UserEndpoints : EndpointGroupBase
{
    public override string? GroupName => "users";
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetAll);
        groupBuilder.MapGet(GetDetail, "{id:guid}");
        groupBuilder.MapPost(Add);
        groupBuilder.MapPut(Update, "{id:guid}");
        groupBuilder.MapPatch("{id:guid}/active-status", UpdateActiveStatus);
        groupBuilder.MapDelete(Delete, "{id:guid}");
    }

    public Task<Result> GetAll(IUserService service, [AsParameters] FilterRequest filter)
        => service.GetAll(filter);

    public Task<Result> GetDetail(IUserService service, Guid id)
        => service.GetDetail(id);

    public Task<Result> Add(IUserService service, [FromBody] AddUserRequest request)
        => service.Add(request);

    public Task<Result> Update(IUserService service, Guid id, [FromBody] UpdateUserRequest request)
        => service.Update(id, request);

    public Task<Result> UpdateActiveStatus(IUserService service, Guid id, [FromBody] UpdateActiveStatusRequest request)
        => service.UpdateActiveStatus(id, request);

    public Task<Result> Delete(IUserService service, Guid id)
        => service.Delete(id);

}
