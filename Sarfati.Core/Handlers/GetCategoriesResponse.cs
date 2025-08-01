using System.Collections.Generic;

namespace Sarfati.Core.Handlers;


    public class GetCategoryResponse
    {
        public int PageNumber { get; set; }
        public List<CategoryDto> Data { get; set; } = new List<CategoryDto>();
    }

    public class CategoryDto
    {
        public string Id { get; set; }
        public string CategoryParentId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameAr { get; set; }
        public string AmazonImage { get; set; }
        public bool IsTopBrand { get; set; }
        public int GroupId { get; set; }
        public List<SubCategory> Children { get; set; }
    }

    public class SubCategory
    {
        public string Id { get; set; }
        public string CategoryParentId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameAr { get; set; }

        public string AmazonImage { get; set; }
        public List<SubCategory>? Children { get; set; }

    }

