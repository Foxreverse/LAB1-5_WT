﻿using Microsoft.AspNetCore.Identity;

namespace Test.UI.Data
{
	public class ApplicationUser: IdentityUser
	{
		public byte[]? Avatar { get; set; }
		public string MimeType { get; set; } = string.Empty;
	}
}
