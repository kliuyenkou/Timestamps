using Microsoft.AspNet.Identity;

namespace Timestamps.BLL.DataContracts
{
    public class User : IUser<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}