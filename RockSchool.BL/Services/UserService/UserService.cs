﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RockSchool.BL.Dtos.Service.Requests.StudentService;
using RockSchool.BL.Dtos.Service.Requests.UserService;
using RockSchool.BL.Dtos.Service.Responses;
using RockSchool.Data.Entities;
using RockSchool.Data.Repositories;

namespace RockSchool.BL.Services.UserService;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public UserService(UserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> AddUserAsync(AddUserServiceRequestDto addUserServiceRequestDto)
    {
        var passwordValidationResult = ValidateAndGetFinalPassword(
            addUserServiceRequestDto.Password,
            addUserServiceRequestDto.ConfirmPassword
        );

        if (!passwordValidationResult.IsSuccess)
            throw new InvalidOperationException(">" + passwordValidationResult.ErrorMessage + "<");

        var newUser = CreateUserEntity(addUserServiceRequestDto);

        newUser.PasswordHash = _passwordHasher.HashPassword(newUser, passwordValidationResult.FinalPassword);

        await _userRepository.AddAsync(newUser);

        var savedUser = await _userRepository.GetByIdAsync(newUser.Id);
        if (savedUser == null)
            throw new InvalidOperationException("Failed to add UserService.");

        return savedUser.Id;
    }

    private (bool IsSuccess, string FinalPassword, string ErrorMessage) ValidateAndGetFinalPassword(
        string? password,
        string? confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(password))
            return (true, "123456", string.Empty);

        if (string.IsNullOrWhiteSpace(confirmPassword))
            return (false, string.Empty, "ConfirmPassword is required if Password is provided.");

        if (!password.Equals(confirmPassword))
            return (false, string.Empty, "Password and ConfirmPassword do not match.");

        return (true, password, string.Empty);
    }

    private UserEntity CreateUserEntity(AddUserServiceRequestDto addUserServiceRequestDto)
    {
        return new UserEntity
        {
            Login = addUserServiceRequestDto.Login,
            RoleId = addUserServiceRequestDto.RoleId
        };
    }

    public async Task<UserDto?> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            return null;

        var userDto = new UserDto
        {
            Id = user.Id,
            Login = user.Login,
            PasswordHash = user.PasswordHash,
            RoleId = user.RoleId,
            RoleEntity = user.RoleEntity
        };

        return userDto;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new InvalidOperationException("UserService not found.");

        await _userRepository.DeleteAsync(user);
    }
}