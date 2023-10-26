using Postgrest.Attributes;

namespace real_time_chat_backend.Responses
{
	public class GetUserResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string UserCode { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		
		public string ProfilePhotoUrl { get; set; }
	}
}
