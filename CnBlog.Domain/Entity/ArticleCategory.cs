using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CnBlog.Domain
{
    [Table("ArticleCategories")]
    public class ArticleCategory : BaseFullEntity
    {
        public string CategoryName { get; set; }

        public string CategoryNo { get; set; }

        public string Remark { get; set; }
    }
}
