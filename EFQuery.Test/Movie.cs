namespace Seamas.EFQuery.Test;

public class Movie
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// URL地址
    /// </summary>
    public string Url { get; set; }
    
    /// <summary>
    /// 点赞数
    /// </summary>
    public int Likes { get; set; } 
    
    /// <summary>
    /// 是否下载
    /// </summary>
    public bool IsDownloaded { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateAt { get; set; } = DateTime.Now.ToUniversalTime();
    
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateAt { get; set; } = DateTime.Now.ToUniversalTime();
}