using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.View;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using Sistem_Manajemen_Hotel.Controller;
using System.Diagnostics;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Client : UserControl
    {
        private List<ClientEntity> listClient = new List<ClientEntity>();
        private ClientController controller;
        public Client()
        {
            InitializeComponent();
            controller = new ClientController();
            InisialisasiListView();
            LoadDataClient();
            lvwClient.SelectedIndexChanged += listClient_SelectedIndexChanged;
        }
        private void InisialisasiListView()
        {
            lvwClient.View = System.Windows.Forms.View.Details;
            lvwClient.FullRowSelect = true;
            lvwClient.GridLines = true;
            lvwClient.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            lvwClient.Columns.Add("ID.", 65, HorizontalAlignment.Center);
            lvwClient.Columns.Add("Firstname", 200, HorizontalAlignment.Center);
            lvwClient.Columns.Add("Lastname", 200, HorizontalAlignment.Center);
            lvwClient.Columns.Add("Phone", 200, HorizontalAlignment.Center);
        }
        private void LoadDataClient()
        {
            // kosongkan listview
            lvwClient.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listClient = controller.ReadAll();
            // ekstrak objek mhs dari collection
            
            foreach (var client in listClient)
            {
                var noUrut = lvwClient.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
             //   item.SubItems.Add(noUrut.ToString());
                item.SubItems.Add(client.Id);
                item.SubItems.Add(client.Firstname);
                item.SubItems.Add(client.Lastname);
                item.SubItems.Add(client.Phone.ToString());
                lvwClient.Items.Add(item);
            }
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
        }

        private void btnAdd_Client_Click(object sender, EventArgs e)
        {
            try
            {
                string firstname = txtFirstname.Text;
                string lastname = txtLastname.Text;
                int phone = int.Parse(txtPhoneNo.Text);

                ClientEntity client = new ClientEntity
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Phone = phone
                };
                
                int result = controller.Create(client);
                if (result > 0)
                {
                    MessageBox.Show("Data Client berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataClient(); // Refresh data setelah menambahkan barang baru
                    txtFirstname.Text = "";
                    txtLastname.Text = "";
                    txtPhoneNo.Text = "";
                }
                else
                {
                    MessageBox.Show("Data Client gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Debug.WriteLine($"Firstname: {firstname}, Lastname: {lastname}, Phone: {phone}");


                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan input phone adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Client_Click(object sender, EventArgs e)
        {
            if (lvwClient.SelectedItems.Count > 0)
            {
                try
                {   string id = lvwClient.SelectedItems[0].SubItems[1].Text;
                    string firstname = txtFirstname.Text;
                    string lastname = txtLastname.Text;
                    int phone = int.Parse(txtPhoneNo.Text);

                    ClientEntity client = new ClientEntity
                    {
                        Id = id,
                        Firstname = firstname,
                        Lastname = lastname,
                        Phone = phone
                    };
                    
                    int result = controller.Update(client);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Client berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataClient();
                        txtFirstname.Text = "";
                        txtLastname.Text = "";
                        txtPhoneNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Client gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Debug.WriteLine($"data dari update =>Id:{id} Firstname: {firstname}, Lastname: {lastname}, Phone: {phone}");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Pastikan input phone adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu data untuk diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Client_Click(object sender, EventArgs e)
        {
            if (lvwClient.SelectedItems.Count > 0)
            {
                try
                {
                    // Ambil indeks dari item yang dipilih di ListView
                    int selectedIndex = lvwClient.SelectedItems[0].Index;

                    // Ambil Barang yang sesuai dari List<Barang>
                    ClientEntity clientToDelete = listClient[selectedIndex];

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = controller.Delete(clientToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Client berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataClient(); // Refresh data setelah menghapus data barang
                        txtFirstname.Text = "";
                        txtLastname.Text = "";
                        txtPhoneNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Client gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu data untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void listClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwClient.SelectedItems.Count > 0)
            {
                var selectedItem = lvwClient.SelectedItems[0];
                txtFirstname.Text = selectedItem.SubItems[2].Text;
                txtLastname.Text = selectedItem.SubItems[3].Text;
                txtPhoneNo.Text = selectedItem.SubItems[4].Text;

            }
        }

        private void btnSearch_Client_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Client.Text.Trim().ToLower(); // Get the search keyword

            // Filter the barangList based on the keyword
            var filterClient = listClient.Where(Client =>
                Client.Firstname.ToLower().Contains(keyword) ||
                Client.Lastname.ToLower().Contains(keyword)).ToList();

            // Clear the ListView
            lvwClient.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var client in filterClient)
            {
                var noUrut = lvwClient.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(client.Id);
                item.SubItems.Add(client.Firstname);
                item.SubItems.Add(client.Lastname);
                item.SubItems.Add(client.Phone.ToString());
                lvwClient.Items.Add(item);
            }
        }
    }
}