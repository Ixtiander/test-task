using System.Collections.Generic;

namespace TestApplication.ViewModel
{
    public class PagedResponse<T>
    {
        public List<T>? Items { get; set; }
        public bool HasMore { get; set; }
    }
}