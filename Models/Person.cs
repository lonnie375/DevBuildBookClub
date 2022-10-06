
using Dapper.Contrib.Extensions;


namespace DevBuildMVCBookClub.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
    }
}
