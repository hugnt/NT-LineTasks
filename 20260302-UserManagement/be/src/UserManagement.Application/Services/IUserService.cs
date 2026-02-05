using UserManagement.Application.Models;
using UserManagement.Application.Models.Requests;

namespace UserManagement.Application.Services;

public interface IUserService
{
    public Task<Result> GetAll(FilterRequest filter);
    public Task<Result> GetDetail(Guid id);
    public Task<Result> Add(AddUserRequest request);
    public Task<Result> Update(Guid id, UpdateUserRequest request);
    public Task<Result> UpdateActiveStatus(Guid id, UpdateActiveStatusRequest request);
    public Task<Result> Delete(Guid id);
}
