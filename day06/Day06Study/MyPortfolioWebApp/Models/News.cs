using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class News
    {
        // 실제 DB의 News 테이블로 만들어짐
        [Key] // Id == Primary Key
        public int Id { get; set; }

        public string Writer { get; set; } 
        public string Title { get; set; }

        [Required] // Not Null
        public string Description { get; set; }

        public DateTime PostDate { get; set; }

        public int ReadCount { get; set; }
    }
}
