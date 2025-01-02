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
        }
        private void listRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwRoom.SelectedItems.Count > 0)
            {
                var selectedItem = lvwRoom.SelectedItems[0];
                RoomType.Text = selectedItem.SubItems[1].Text;
                txtNumberRoom.Text = selectedItem.SubItems[2].Text;
                txtPrice.Text = selectedItem.SubItems[3].Text;

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
            lvwRoom.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("id Kamar.", 65, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Nama Kamar ", 200, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Jenis Kamar", 200, HorizontalAlignment.Center);
            lvwRoom.Columns.Add("Harga", 200, HorizontalAlignment.Center);
        }
        private void btnAdd_Room_Click(object sender, EventArgs e)
        {
            try
            {
                //id room sudah di set auto increment

                string roomNumber = txtNumberRoom.Text;
                string roomType = cmbRoomType.SelectedItem?.ToString();
                int price = Convert.ToInt32(txtPrice.Text);
                string availability = rdbAvailabe.Checked ? "Yes" : "No"; // Memeriksa apakah radio button dipilih

                RoomEntity newRoom = new RoomEntity
                {
                    RoomNumber = int.Parse(roomNumber),
                    TypeRoom= roomType,
                    Price = price,
                    Availability = availability
                };
                int result = controller.Create(newRoom);
                if (result > 0)
                {
                    MessageBox.Show("Data Client berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataRoom(); // Refresh data setelah menambahkan barang baru
                    ClearForm();  // Mengosongkan form

                }
                else
                {
                    MessageBox.Show("Data Client gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show($"dari viewFe ---SQL Parameters: RoomNumber = {newRoom.RoomNumber}, Availability = {newRoom.Availability}, TypeRoom = {newRoom.TypeRoom}, Price = {newRoom.Price}");
                    //Debug.WriteLine($"dari viewFe ---SQL Parameters: RoomNumber = {newRoom.RoomNumber}, Availability = {newRoom.Availability}, TypeRoom = {newRoom.TypeRoom}, Price = {newRoom.Price}");
               


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

        private void grbClient_Enter(object sender, EventArgs e)
        {

        }
        private void ClearForm()
        {
            txtNumberRoom.Clear();
            cmbRoomType.SelectedIndex = -1;  // Reset ComboBox
            txtPrice.Clear();
            rdbAvailabe.Checked = true;
        }
        private void LoadDataRoom()
        {
            RoomRepository RoomRepository = new RoomRepository(new Model.Context.DbContext());
            List<RoomEntity> listRoom = RoomRepository.ReadAll();
            lvwRoom.Items.Clear();
            foreach (var room in listRoom)
            {
                ListViewItem item = new ListViewItem(room.IdRoom.ToString());
                item.SubItems.Add(room.RoomNumber.ToString());
                item.SubItems.Add(room.TypeRoom);
                item.SubItems.Add(room.Price.ToString());
                item.SubItems.Add(room.Availability);
                lvwRoom.Items.Add(item);
            }
        }

    }
}
