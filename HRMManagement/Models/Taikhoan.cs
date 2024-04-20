using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMManagement.Models;

public partial class Taikhoan
{
    public int Id { get; set; }

	[StringLength(60, MinimumLength = 8, ErrorMessage = "Username must be between 8 and 60 characters in length.")]
	[Required(ErrorMessage = "Username is required.")]
	public string? TenDangNhap { get; set; }

	[Required(ErrorMessage = "Password is required.")]
	[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).*$", ErrorMessage = "Password must include lowercase letters, uppercase letters, and special characters.")]
	public string? MatKhau { get; set; }

    public int? Idloai { get; set; }

    public string? Idnv { get; set; }

    public virtual Loaitk? IdloaiNavigation { get; set; }

    public virtual Nhanvien? IdnvNavigation { get; set; }
}
