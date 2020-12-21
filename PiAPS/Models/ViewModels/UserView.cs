using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class UserView
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Роль")]
        public Roles Role { get; set; }

        [DisplayName("Комментарий")]
        public string Comment { get; set; }
          
    }
}
