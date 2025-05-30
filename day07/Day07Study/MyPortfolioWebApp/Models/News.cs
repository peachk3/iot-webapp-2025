using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models
{
    public class News
    {
        // 실제 DB의 News 테이블로 만들어짐
        [Key] // Id == Primary Key
        [DisplayName("번호")]
        public int Id { get; set; }

        [DisplayName("작성자")]
        public string Writer { get; set; }

        [DisplayName("뉴스제목")]
        public string Title { get; set; }

        [DisplayName("뉴스내용")]
        [Required] // Not Null
        public string Description { get; set; }

        [DisplayName("작성일")]
        [DisplayFormat(DataFormatString = "{0:yyyy년 MM월 dd일}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [DisplayName("조회수")]
        public int ReadCount { get; set; }
    }
}