using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuctionWeb.Pages;

public class IndexModel : PageModel
{
    
    public List<string>? DataList { get; set; } // create list to test data in database
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // Lấy dữ liệu người dùng từ cơ sở dữ liệu để hiển thị trên trang
    }

    public void OnPost(User user)
    {
        // Lưu dữ liệu người dùng vào cơ sở dữ liệu khi người dùng nhấn nút "Submit"
    }
}
