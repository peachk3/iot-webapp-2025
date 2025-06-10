using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // DB 스키마 정의 클래스

namespace WebApiApp01.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required] // NotNull 일 경우는 string에 ?(Nuallable) 삭제할 것
        [Column(TypeName ="VARCHAR(100)")] // 이거 사용 안 하면 테이블 컬럼이 LONGTEXT로 생성됨
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "CHAR(8)")] // 20250610
        public string TodoDate { get; set; }

        // boolean
        public bool IsComplete { get; set; }
    }
}

