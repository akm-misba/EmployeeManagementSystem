using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class YearModel
    {
        public int Year { get; set;}
        public SelectList YEARList { get; set;}
    }
}
