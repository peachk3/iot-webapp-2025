using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolioWebApp.Models;

public partial class Board
{
    [Key]
    [DisplayName("번호")]
    public int Id { get; set; }

    [Required]
    [DisplayName("이메일")]
    public string Email { get; set; } = null!;

    [DisplayName("작성자")]
    public string? Writer { get; set; }

    [DisplayName("제목")]
    [Required]
    public string Title { get; set; } = null!;

    [DisplayName("내용")]
    [Required]
    public string Contents { get; set; } = null!;

    [DisplayName("작성일")]
    [DisplayFormat(DataFormatString = "{0:yyyy년 MM월 dd일}", ApplyFormatInEditMode = true)]
    [BindNever] // 폼에서 입력 무시. 서버에서 설정

    public DateTime? PostDate { get; set; }

    [DisplayName("조회수")]
    [BindNever] // 폼에서 입력 무시. 서버에서 설정
    public int? ReadCount { get; set; }
}
