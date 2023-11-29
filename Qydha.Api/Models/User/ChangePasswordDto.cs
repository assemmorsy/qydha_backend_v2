﻿namespace Qydha.API.Models;

public class ChangePasswordDto
{

    public string OldPassword { get; set; } = null!;

    public string NewPassword { get; set; } = null!;

}

public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(r => r.OldPassword)
                .Password("كلمة المرور القديمة");

        RuleFor(r => r.NewPassword)
                .Password("كلمة المرور الجديدة");

    }
}