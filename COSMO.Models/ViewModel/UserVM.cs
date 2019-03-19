using COSMO.Models.Models;
using COSMO.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Models.ViewModel
{
    public class UserVM
    {
        public User User { get; set; }

        public UserRole UserRole { get; set; }

        public Branch Branch { get; set; }
    }
}
