using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Data.Entities
{
    public class Users
    {
        [Key]
        public int USER_CODE { get; set; }

        [StringLength(100)]
        public string USER_NAME { get; set; }
    }
}
