using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PagingAndSortingInMvc.Entities
{
    public class EmployeeMaster
    {
        [Key]
        public string ID { get; set; }

        [Required(ErrorMessage="请输入员工名字")]
        public string Name { get; set; }

        [Required(ErrorMessage="请输入手机号码")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage="请输入Email")]
        public string Email { get; set; }

        [Required(ErrorMessage= "请输入薪水")]
        public decimal Salary { get; set; }


    }
}