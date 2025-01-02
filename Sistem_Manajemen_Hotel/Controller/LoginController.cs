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

namespace Sistem_Manajemen_Hotel.Controller
{
    public class LoginController
    {
        private LoginRepository _Loginrepository;
        public LoginController(LoginRepository loginRepository)
        {
            _Loginrepository = loginRepository;
        }
        public void CreateMasuk(string username, string password)
        {
            LoginEntity login = new LoginEntity
            {
                Username = username,
                Password = password
            };

            _Loginrepository.Create(login);
        }
        public List<LoginEntity> GetAllMasuk()
        {
            return _Loginrepository.ReadAll();
        }
        public void UpdateMasuk(string username, string newPassword)
        {
            LoginEntity login = new LoginEntity
            {
                Username = username,
                Password = newPassword
            };

            _Loginrepository.Update(login);
        }
        public void DeleteMasuk(string username)
        {
            _Loginrepository.Delete(username);
        }
    }
}
