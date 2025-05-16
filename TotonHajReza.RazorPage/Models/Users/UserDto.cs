﻿using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace TotonHajReza.RazorPage.Models.Users
{
    public class UserDto:BaseDto
    {
        public string Name {  get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarName {  get; set; }
        public bool IsPhoneNumberVerified {  get; set; }
        public Gender Gender { get; set; }
        public List<UserRoleDto> Roles { get; set; }

    }
    
    public enum Gender
    {
        None,
        Male,
        Famele
    }
}
