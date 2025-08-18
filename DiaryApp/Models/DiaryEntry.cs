using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime Created {  get; set; } = DateTime.Now;
    }
}
// FSE-3GFPHR3\SQLEXPRESS; initial catalog = master; trusted_connection = true