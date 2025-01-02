using Sistem_Manajemen_Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using Sistem_Manajemen_Hotel.Model.Context;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class ClientController
    {
        private ClientRepository _Clientrepository;

        public int Create(ClientEntity client)
        {
            int result = 0;
            if (string.IsNullOrEmpty(client.Firstname))
            {
                MessageBox.Show("Firstname client harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(client.Lastname))
            {
                MessageBox.Show("Lastname client harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (client.Phone == 0)
            {
                MessageBox.Show("Phone client harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Clientrepository = new ClientRepository(context);
                result = _Clientrepository.Create(client);
            }
            return result;
        }

        public List<ClientEntity> ReadByNama(string firstname)
        {
            // membuat objek collection
            List<ClientEntity> list = new List<ClientEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Clientrepository = new ClientRepository(context);
                list = _Clientrepository.ReadByNama(firstname);
            }
            return list;
        }

        public List<ClientEntity> ReadAll()
        {
            // membuat objek collection
            List<ClientEntity> list = new List<ClientEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Clientrepository = new ClientRepository(context);
                list = _Clientrepository.ReadAll();
            }
            return list;
        }

        public int Update(ClientEntity client)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Clientrepository = new ClientRepository(context);
                result = _Clientrepository.Update(client);
            }
            return result;
        }
        public int Delete(ClientEntity client)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Clientrepository = new ClientRepository(context);
                result = _Clientrepository.Delete(client);
            }

            return result;
        }
    }
}
