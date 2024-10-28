using Microsoft.AspNetCore.Identity;

namespace TravelCore.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = "Parola Minimum"+length+" Karakter olmalıdır"
            };
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Parola en az 1 büyük karakter içermelidir"
            };
		}
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",

                Description = "Parola en az 1 küçük karakter içermelidir"
            };
        }
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
                Code = "PasswordRequiresNonAlphanumeric",

                Description = "Parola en az 1 sembol karakter içermelidir"

            };
		}
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",

                Description = "Parola en az 1 rakam (0,9) karakter içermelidir"

            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"'{userName}' kullanıcı adı zaten alınmış."
            };
        }

    }
}
