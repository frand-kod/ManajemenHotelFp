using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using System.Data.SQLite;
using Sistem_Manajemen_Hotel.Model.Context;
using System.Runtime.Remoting.Contexts;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class LoginController
    {
        private LoginRepository _Loginrepository;

        public int SignUp(LoginEntity SignUp)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Loginrepository = new LoginRepository(context);

                //masukkan user yang Signup
                result = _Loginrepository.SignUp(SignUp);
            }

            return result;

        }
        public bool Login(LoginEntity Login)
        {
            bool isVerified = false;
            using (DbContext context = new DbContext())
            {
                _Loginrepository = new LoginRepository(context);
                if (Login != null)
                {
                    if (_Loginrepository.Login(Login))
                    {   // set IsVerified -> True
                        isVerified = true;
                    }

                }
                return isVerified;
            }
        }

    }
}
