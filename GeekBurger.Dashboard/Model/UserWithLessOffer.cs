using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Dashboard.Model
{
    public class UserWithLessOffer
    {
        [Key]
        public int UserId { get; set; }
        public string UserRestrictions { get; set; }
    }
}
