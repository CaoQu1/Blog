using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CnBlog.Domain
{
    [Table("Articles")]
    public class Article : BaseFullEntity
    {
        public int CategoryId { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string Link { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ArticleCategory ArticleCategory { get; set; }
    }
}
