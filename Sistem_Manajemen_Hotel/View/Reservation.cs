using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Controller;
using Sistem_Manajemen_Hotel.Model.Entity;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Reservation : UserControl
    {
        private List<ReservationEntity> listReservation = new List<ReservationEntity>();
        private ReservationController controller;
        public Reservation()
        {
            InitializeComponent();
            controller = new ReservationController();
            InisialisasiListView();
            LoadDataReservation();

            lvwReservation.SelectedIndexChanged += listReservation_SelectedIndexChanged;
        }
        private void InisialisasiListView()
        {
            lvwReservation.View = System.Windows.Forms.View.Details;
            lvwReservation.FullRowSelect = true;
            lvwReservation.GridLines = true;
            lvwReservation.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("ID.", 95, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("Room Type", 175, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("Masuk", 175, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("Keluar", 175, HorizontalAlignment.Center);
        }
        private void LoadDataReservation()
        {
            // kosongkan listview
            lvwReservation.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listReservation = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var reservation in listReservation)
            {
                var noUrut = lvwReservation.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(reservation.room_type);
                item.SubItems.Add(reservation.masuk);
                item.SubItems.Add(reservation.keluar);
                lvwReservation.Items.Add(item);
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
        private void listReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwReservation.SelectedItems.Count > 0)
            {
                var selectedItem = lvwReservation.SelectedItems[0];
                cmbRoomType.Text = selectedItem.SubItems[1].Text;
                txtIdClient.Text = selectedItem.SubItems[2].Text;
                dtp_In.Text = selectedItem.SubItems[3].Text;
                dtp_Out.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnAdd_Reservation_Click(object sender, EventArgs e)
        {
            try
            {
                string room_type = cmbRoomType.Text;
                int idclient = int.Parse(txtIdClient.Text);
                string masuk = dtp_In.Text;
                string keluar = dtp_Out.Text; 

                ReservationEntity barang = new ReservationEntity
                {
                    room_type = room_type,
                    masuk = masuk,
                    keluar = keluar
                };
                
                int result = controller.Create(barang);
                if (result > 0)
                {
                    MessageBox.Show("Data Reservation berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataReservation(); // Refresh data setelah menambahkan barang baru
                    cmbRoomType.Text = "";
                    txtIdClient.Text = "";
                    dtp_In.Text = "";
                    dtp_In.Text = "";
                }
                else
                {
                    MessageBox.Show("Data Reservation gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Pastikan input id client adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Reservation_Click(object sender, EventArgs e)
        {
            if (lvwReservation.SelectedItems.Count > 0)
            {
                try
                {
                    string room_type = cmbRoomType.Text;
                    int idclient = int.Parse(txtIdClient.Text);
                    string masuk = dtp_In.Text;
                    string keluar = dtp_Out.Text;

                    ReservationEntity reservation = new ReservationEntity
                    {
                        room_type = room_type,
                        masuk = masuk,
                        keluar = keluar
                    };

                    int result = controller.Update(reservation);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Resevation berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataReservation();
                        cmbRoomType.Text = "";
                        txtIdClient.Text = "";
                        dtp_In.Text = "";
                        dtp_Out.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Reservation gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Pastikan input id client adalah angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu barang untuk diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Reservation_Click(object sender, EventArgs e)
        {
            if (lvwReservation.SelectedItems.Count > 0)
            {
                try
                {
                    // Ambil indeks dari item yang dipilih di ListView
                    int selectedIndex = lvwReservation.SelectedItems[0].Index;

                    // Ambil Barang yang sesuai dari List<Barang>
                    ReservationEntity reservasiToDelete = listReservation[selectedIndex];

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = controller.Delete(reservasiToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data erservasi berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataReservation(); // Refresh data setelah menghapus data barang
                        cmbRoomType.Text = "";
                        txtIdClient.Text = "";
                        dtp_In.Text = "";
                        dtp_Out.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data reservasi gagal dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu barang untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Reservation_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch_Reservation.Text.Trim().ToLower(); // Get the search keyword

            // Filter the barangList based on the keyword
            var filterReservasi = listReservation.Where(reservasi =>
                reservasi.room_type.ToLower().Contains(keyword)
            ).ToList();

            // Clear the ListView
            lvwReservation.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var reservation in filterReservasi)
            {
                var noUrut = lvwReservation.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(reservation.id_reservation.ToString());
                item.SubItems.Add(reservation.room_type);
                item.SubItems.Add(reservation.masuk);
                item.SubItems.Add(reservation.keluar);
                lvwReservation.Items.Add(item);
            }
        }
    }
}
