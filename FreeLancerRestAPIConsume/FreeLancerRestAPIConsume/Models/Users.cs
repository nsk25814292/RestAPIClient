using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FreeLancerRestAPIConsume.Models
{
    public class Users
    {

        public int UserId { get; set; }
        [Required (ErrorMessage ="UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ContactNo is required")]
        public int ContactNo { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "SkillSet is required")]
        public string SkillSet { get; set; }
        public string Hobbies { get; set; }
        public int Freelancer_User_Id { get; set; }
    }
}