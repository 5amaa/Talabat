using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specifications
{
    public class ProductSpecParams
    {
        private const int maxSize = 10;
        private int pageSize;

        public int PageSize {
            get { return pageSize; }
            set { pageSize = value> maxSize ? maxSize : value ; }
        }
        //search in critearia 
        private string search;
        public string? Search
        {
            set { search = value.ToLower(); }
            get { return search; }
        }
        public int PageIndex { get; set;} = 1;

        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
