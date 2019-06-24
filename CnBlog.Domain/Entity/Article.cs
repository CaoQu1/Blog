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


    }
}
