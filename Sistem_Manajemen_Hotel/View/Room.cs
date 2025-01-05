using Sistem_Manajemen_Hotel.Controller;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Room : UserControl
    {
        private List<RoomEntity> listRoom = new List<RoomEntity>();
        private RoomController controller;
        public Room()
        {
            InitializeComponent();
            //set avaiabele to true
            rdbAvailabe.Checked = true;

            controller = new RoomController();
            InisialisasiListView();
            LoadDataRoom();
            lvwRoom.SelectedIndexChanged += listRoom_SelectedIndexChanged;
            TBSearch.TextChanged += TbSearch_TextChanged_1;

        }
        private void listRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwRoom.SelectedItems.Count > 0)
            {
                var selectedItem = lvwRoom.SelectedItems[0];
                txtNumberRoom.Text = selectedItem.SubItems[1].Text;

                cmbRoomType.Text = selectedItem.SubItems[2].Text;
                txtPrice.Text = selectedItem.SubItems[3].Text;

                string status = selectedItem.SubItems[4].Text;  // Get the status ("Yes" or "No")

                // Update the RadioButtons based on the status
                rdbAvailabe.Checked = (status == "Yes");
                rdbNotAvail.Checked = (status == "No");

                Debug.WriteLine($"View - Adding Room:id Room ={selectedItem.SubItems[0]}  RoomNumber = {selectedItem.SubItems[1]}, TypeRoom = {selectedItem.SubItems[2]}, Price = {selectedItem.SubItems[3]}, Availability = {selectedItem.SubItems[4]}");

                //View - Adding Room:id Room =ListViewSubItem: {2}  RoomNumber = ListViewSubItem: {44332}, TypeRoom = ListViewSubItem: {suite}, Price = ListViewSubItem: {3322}, Availability = ListViewSubItem: {Yes}

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
        private void InisialisasiListView()
        {
            lvwRoom.View = System.Windows.Forms.View.Details;
            lvwRoom.FullRowSelect = true;
            lvwRoom.GridLines = true;
            lvwRoom.Columns.Add("No.", 65, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Nomor Kamar ", 200, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Jenis Kamar", 200, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Harga", 200, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Status", 200, HorizontalAlignment.Center);
            
        }
        private void btnAdd_Room_Click(object sender, EventArgs e)
        {
            try
            {
                string roomNumber = txtNumberRoom.Text;
                string roomType = cmbRoomType.SelectedItem?.ToString();
                int price = Convert.ToInt32(txtPrice.Text);
                string availability = rdbAvailabe.Checked ? "Yes" : "No";

                RoomEntity newRoom = new RoomEntity
                {
                    RoomNumber = int.Parse(roomNumber),
                    TypeRoom = roomType,
                    Price = price,
                    Availability = availability
                };

                Debug.WriteLine($"View - Adding Room: RoomNumber = {newRoom.RoomNumber}, TypeRoom = {newRoom.TypeRoom}, Price = {newRoom.Price}, Availability = {newRoom.Availability}");

                int result = controller.Create(newRoom);

                if (result > 0)
                {
                    MessageBox.Show("Data Room berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataRoom();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Data Room gagal disimpan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan input Room Number dan Harga adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grbClient_Enter(object sender, EventArgs e)
        {

        }
        private void ClearForm()
        {
            txtNumberRoom.Clear();
            cmbRoomType.SelectedIndex = -1;  // Reset ComboBox
            //txtPrice.Clear();
            rdbAvailabe.Checked = true;
        }
        private void LoadDataRoom()
        {
            RoomRepository RoomRepository = new RoomRepository(new Model.Context.DbContext());
            List<RoomEntity> listRoom = RoomRepository.ReadAll();
            lvwRoom.Items.Clear();
            int count = 1;
            foreach (var room in listRoom)
            {
                ListViewItem item = new ListViewItem(room.IdRoom.ToString());
               // item.SubItems.Add(room.IdRoom.ToString());

                //ListViewItem item = new ListViewItem(room.IdRoom.ToString());

                item.SubItems.Add(room.RoomNumber.ToString());
                item.SubItems.Add(room.TypeRoom);
                item.SubItems.Add(room.Price.ToString());
                item.SubItems.Add(room.Availability);
                lvwRoom.Items.Add(item);

                count++;
            }
        }

        private void btnUpdate_Room_Click(object sender, EventArgs e)
        {
            try
            {
                string idRoom = lvwRoom.SelectedItems[0].SubItems[0].Text;
                string roomNumber = txtNumberRoom.Text;
                string roomType = cmbRoomType.SelectedItem?.ToString();
                int price = Convert.ToInt32(txtPrice.Text);
                string availability = rdbAvailabe.Checked ? "Yes" : "No"; // Memeriksa apakah radio button dipilih


                RoomEntity UpdateRoom = new RoomEntity
                {
                    IdRoom = int.Parse(idRoom),
                    RoomNumber = int.Parse(roomNumber),
                    Availability = availability,
                    TypeRoom = roomType,
                    Price = price
                };

                int result = controller.Update(UpdateRoom);
                if (result > 0)
                {
                    MessageBox.Show("Data Client berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataRoom();
                    cmbRoomType.SelectedIndex = -1;  // Reset ComboBox
                
                }
                else
                {
                    MessageBox.Show("Data Client gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Debug.WriteLine($"data dari update =>Id:{idRoom} Firstname: {roomNumber}, Lastname: {price}, Phone: {availability}");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan Input Sudah Benar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Room_Click(object sender, EventArgs e)
        {
            if (lvwRoom.SelectedItems.Count > 0)
            {
                try
                {
                    /*
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
                     
                     */
                    // Ambil indeks dari item yang dipilih di ListView
                    string idRoom = lvwRoom.SelectedItems[0].SubItems[0].Text;

                    // Ambil Barang yang sesuai dari List<Barang>
                    RoomEntity RoomDelete = new RoomEntity
                    {
                        IdRoom = int.Parse(idRoom) // Ambil ID dari item yang dipilih
                    };

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = controller.Delete(RoomDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Room berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataRoom(); // Refresh data setelah menghapus data barang
                        cmbRoomType.SelectedIndex = -1;  // Reset ComboBox
                    }
                    else
                    {
                        MessageBox.Show("Data Room gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TbSearch_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = TBSearch.Text.Trim().ToLower(); // Ambil kata kunci pencarian

            // Filter data berdasarkan kata kunci
            var filteredRooms = listRoom.Where(room =>
                room.IdRoom.ToString().ToLower().Contains(keyword) ||
                room.RoomNumber.ToString().ToLower().Contains(keyword) ||
                room.TypeRoom.ToLower().Contains(keyword) ||
                room.Price.ToString().ToLower().Contains(keyword) ||
                room.Availability.ToLower().Contains(keyword)
            ).ToList();

            // Bersihkan ListView sebelum memperbarui data
            lvwRoom.Items.Clear();

            if (filteredRooms.Any())
            {
                // Tampilkan hasil pencarian di ListView
                foreach (var filtered in filteredRooms)
                {
                    var noUrut = lvwRoom.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(filtered.IdRoom.ToString());
                    item.SubItems.Add(filtered.RoomNumber.ToString());
                    item.SubItems.Add(filtered.TypeRoom.ToString());
                    item.SubItems.Add(filtered.Price.ToString());

                    lvwRoom.Items.Add(item);
                   Debug.WriteLine($"Menambahkan item: {filtered.IdRoom}, {filtered.RoomNumber}, {filtered.TypeRoom}, {filtered.Price}");

                }

                // Atur lebar kolom secara otomatis
                foreach (ColumnHeader column in lvwRoom.Columns)
                {
                    column.Width = -2; // -2 artinya lebar kolom disesuaikan dengan konten
                }
            }
            else
            {
                // Jika tidak ada data yang cocok
                lvwRoom.Items.Clear();
            }
        }
    }
}



