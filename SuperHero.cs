using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI
{
    public class SuperHero
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string FirstName { get; set; } = string.Empty;
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string Place { get; set; } = string.Empty;   
    }
}
