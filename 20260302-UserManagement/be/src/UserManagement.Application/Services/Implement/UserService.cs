using System;
using System.Linq.Expressions;
using System.Net;
using UserManagement.Application.Common.Messages;
using UserManagement.Application.Common.Validation;
using UserManagement.Application.Helpers;
using UserManagement.Application.Models;
using UserManagement.Application.Models.Mappings;
using UserManagement.Application.Models.Requests;
using UserManagement.Application.Models.Responses;
using UserManagement.Domain.Abstractions;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services.Implement;

public class UserService : IUserService
{

    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> GetAll(FilterRequest filter)
    {
        Expression<Func<User, bool>> queryFilter = x =>
                                    (filter.SearchValue.IsEmpty() || x.Fullname.Contains(filter.SearchValue!) || x.Email.Contains(filter.SearchValue!));
        var res = await _userRepository.GetAllAsync(
                            filter.PageSize, filter.PageNumber,
                            predicate: queryFilter,
                            selectQuery: UserMapping.SelectResponseExpression);
        return FilterResult<List<UserResponse>>.Success(res.Data.ToList(), res.TotalCount);
    }

    public async Task<Result> GetDetail(Guid id)
    {
        var selectedUser = await _userRepository.FirstOrDefaultAsync(x => x.Id == id, selectQuery: UserMapping.SelectDetailResponseExpression);
        if (selectedUser == null)
        {
            return Result.Error(HttpStatusCode.NotFound, ErrorMessage.ObjectNotFound(id, "User"));
        }
        return Result<UserDetailResponse>.SuccessWithBody(selectedUser);
    }

    public async Task<Result> Add(AddUserRequest request)
    {
        var validationResult = request.Validate();
        if (!validationResult.IsSuccess)
        {
            return validationResult;
        }
        var userEntity = request.ToEntity();
        _userRepository.Add(userEntity);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(HttpStatusCode.Created, SuccessMessage.CreatedSuccessfully("User"));
    }

    public async Task<Result> Update(Guid id, UpdateUserRequest request)
    {
        var validationResult = request.Validate();
        if (!validationResult.IsSuccess)
        {
            return validationResult;
        }

        var selectedEntity = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (selectedEntity == null) 
        {
            return Result.Error(HttpStatusCode.NotFound, ErrorMessage.ObjectNotFound(id, "User"));
        }
        selectedEntity.MappingFieldFrom(request);

        _userRepository.Update(selectedEntity);
        await _unitOfWork.SaveChangesAsync();

        return Result.SuccessNoContent();
    }

    public async Task<Result> UpdateActiveStatus(Guid id, UpdateActiveStatusRequest request)
    {
        var selectedEntity = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (selectedEntity == null)
        {
            return Result.Error(HttpStatusCode.NotFound, ErrorMessage.ObjectNotFound(id, "User"));
        }
        selectedEntity.IsActive = request.IsActive;

        _userRepository.Update(selectedEntity);
        await _unitOfWork.SaveChangesAsync();

        return Result.SuccessNoContent();
    }

    public async Task<Result> Delete(Guid id)
    {
         var selectedEntity = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (selectedEntity == null)
        {
            return Result.Error(HttpStatusCode.NotFound, ErrorMessage.ObjectNotFound(id, "User"));
        }
        _userRepository.Delete(selectedEntity);
        await _unitOfWork.SaveChangesAsync();
        return Result.SuccessNoContent();
    }

}
