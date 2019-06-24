using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CnBlog.Domain
{
    [Table("SystemUsers")]
    public class SystemUser : BaseEntity<Guid>
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string RealName { get; set; }

        [Required(ErrorMessage = "请输入{0}"), DisplayName("电话号码")]
        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Actvar { get; set; }

        public string Signature { get; set; }
    }
}
