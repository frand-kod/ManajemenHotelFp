using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Controller;
using Sistem_Manajemen_Hotel.Model.Entity;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Reservation : UserControl
    {
        private List<ReservasiEntity> listReservation = new List<ReservasiEntity>();
        
        //import semua listview 
        private List<ClientEntity> listClient = new List<ClientEntity>();
        private List<RoomEntity> listRoom = new List<RoomEntity>();

        //inisialisasi controller   
        private ClientController clientController;
        private RoomController roomController;
        private ReservasiController reservasiController;
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            //LoadDataReservation();
        }

        public Reservation()
        {
            InitializeComponent();
            clientController = new ClientController();
            roomController = new RoomController();
            reservasiController = new ReservasiController();
            InisialisasiListView();
            LoadDataReservation();
            ConfigureComboBoxes();
            lvwReservation.SelectedIndexChanged += listReservation_SelectedIndexChanged;
        }
        private void InisialisasiListView()
        {
            lvwReservation.View = System.Windows.Forms.View.Details;
            lvwReservation.FullRowSelect = true;
            lvwReservation.GridLines = true;
            lvwReservation.Columns.Add("NO.", 65, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("ID.Reservasi", 150, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("id room", 175, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("ID Client", 175, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("Masuk", 175, HorizontalAlignment.Center);
            lvwReservation.Columns.Add("Keluar", 175, HorizontalAlignment.Center);
        }
        private void LoadDataReservation()
        {
            // kosongkan listview
            lvwReservation.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listReservation = reservasiController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var reservation in listReservation)
            {
                var noUrut = lvwReservation.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());

                item.SubItems.Add(reservation.id_reservasi.ToString());               
                item.SubItems.Add(reservation.id_room.ToString());
                item.SubItems.Add(reservation.id_client.ToString());
                item.SubItems.Add(reservation.masuk);
                item.SubItems.Add(reservation.keluar);
                lvwReservation.Items.Add(item);
            }
        }

        private void ConfigureComboBoxes()
        {
            cmbListClientId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbListRoomId.DropDownStyle = ComboBoxStyle.DropDownList;

            // Load data from lv
            loadNameClient();
            loadIdRoom();
        }

        private void loadNameClient()
        {
            try
            {
                listClient = clientController.ReadAll();
                foreach (var client in listClient)
                {
                    // Gabungkan Firstname dan Lastname menjadi satu string dan tambahkan ke ComboBox

                   // cmbClientList.Items.Add(client.Firstname + " " + client.Lastname);

                    cmbListClientId.Items.Add(client.Id);   

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data client!"+ ex, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void loadIdRoom()
        {
            try
            {
                listRoom = roomController.readAllRoom();
                foreach (var room in listRoom)
                {
                    cmbListRoomId.Items.Add(room.IdRoom);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data room!" + ex, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void listReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwReservation.SelectedItems.Count > 0)
            {
                var selectedItem = lvwReservation.SelectedItems[0];

                // Debug: Cek nilai SubItems dan teksnya
                Debug.WriteLine("Isi SubItems[1]: " + selectedItem.SubItems[1].Text);
                Debug.WriteLine("Isi SubItems[2]: " + selectedItem.SubItems[2].Text);
                Debug.WriteLine("Isi SubItems[3]: " + selectedItem.SubItems[3].Text);
                Debug.WriteLine("Isi SubItems[4]: " + selectedItem.SubItems[4].Text);
                Debug.WriteLine("Isi SubItems[5]: " + selectedItem.SubItems[5].Text);


                cmbListRoomId.Text = selectedItem.SubItems[1].Text;
                cmbListClientId.Text = selectedItem.SubItems[2].Text;



                // Format yang sesuai dengan format "03 January 2025"
                string format = "dd MMMM yyyy";

                // Konversi teks menjadi DateTime untuk tanggal masuk
                if (DateTime.TryParseExact(selectedItem.SubItems[4].Text, format,
                     System.Globalization.CultureInfo.InvariantCulture,
                     System.Globalization.DateTimeStyles.None, out DateTime masukDate))
                {
                    DateInsertFieldIn.Value = masukDate;  // Set ke DateTimePicker
                }
                else
                {
                    MessageBox.Show("Tanggal masuk tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Konversi teks menjadi DateTime untuk tanggal keluar
                if (DateTime.TryParseExact(selectedItem.SubItems[5].Text, format,
                     System.Globalization.CultureInfo.InvariantCulture,
                     System.Globalization.DateTimeStyles.None, out DateTime keluarDate))
                {
                    DateInsertFieldOut.Value = keluarDate;  // Set ke DateTimePicker
                }
                else
                {
                    MessageBox.Show("Tanggal keluar tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnAdd_Reservation_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil nilai ID room yang dipilih
                int id_room = Convert.ToInt32(cmbListRoomId.SelectedItem);

                // Ambil nilai ID client yang dipilih
                int idclient = Convert.ToInt32(cmbListClientId.SelectedItem);

                // Ambil nilai dari DateTimePicker
                string masukFormatted = DateInsertFieldIn.Text;  // Ambil teks dari DateTimePicker
                string keluarFormatted = DateInsertFieldOut.Text;  // Ambil teks dari DateTimePicker

                // Membuat objek reservasi baru
                ReservasiEntity newReservasi = new ReservasiEntity
                {
                    id_client = idclient,
                    id_room = id_room,
                    masuk = masukFormatted,
                    keluar = keluarFormatted
                };

                // Proses penyimpanan ke database
                int result = reservasiController.Create(newReservasi);

                if (result > 0)
                {
                    MessageBox.Show("Data Reservation berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh data setelah penyimpanan berhasil
                    LoadDataReservation();

                    // Reset input field
                    cmbListRoomId.SelectedIndex = -1;
                    cmbListClientId.SelectedIndex = -1;
                    DateInsertFieldIn.Value = DateTime.Now;
                    DateInsertFieldOut.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Data Reservation gagal disimpan!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (FormatException ex)
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
                    // Ambil id_reservasi dari SubItems di ListView (bukan menggunakan selectedIndex)
                    int id_reservasi = Convert.ToInt32(lvwReservation.SelectedItems[0].SubItems[1].Text);
                    Debug.WriteLine($"id_reservasi: {id_reservasi}");

                    // Ambil data lainnya dari ComboBox dan DateTimePicker
                    int id_room = Convert.ToInt32(cmbListRoomId.SelectedItem);
                    Debug.WriteLine($"id_room: {id_room}");

                    int id_client = Convert.ToInt32(cmbListClientId.SelectedItem);
                    Debug.WriteLine($"id_client: {id_client}");

                    string masuk = DateInsertFieldIn.Text;
                    Debug.WriteLine($"Tanggal Masuk: {masuk}");

                    string keluar = DateInsertFieldOut.Text;
                    Debug.WriteLine($"Tanggal Keluar: {keluar}");

                    // Buat objek ReservasiEntity dengan data yang diambil
                    ReservasiEntity reservation = new ReservasiEntity
                    {
                        id_reservasi = id_reservasi, // Gunakan id_reservasi yang diambil dari ListView
                        id_client = id_client, // Gunakan id_client yang dipilih
                        id_room = id_room, // Gunakan id_room yang dipilih
                        masuk = masuk,
                        keluar = keluar
                    };

                    // Debugging: Tampilkan detail objek ReservasiEntity yang akan diperbarui
                    Debug.WriteLine($"Mengedit -- ReservasiEntity: id_reservasi={reservation.id_reservasi}, id_client={reservation.id_client}, id_room={reservation.id_room}, masuk={reservation.masuk}, keluar={reservation.keluar}");

                    // Update data reservasi
                    int result = reservasiController.Update(reservation);
                    if (result > 0)
                    {
                        MessageBox.Show("Data Reservation berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataReservation();  // Refresh data
                        cmbListRoomId.Text = "";
                        cmbListClientId.Text = "";
                        DateInsertFieldIn.Text = "";
                        DateInsertFieldOut.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data Reservation gagal diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine($"FormatException: {ex.Message}");
                    MessageBox.Show("Format data salah. Pastikan input Anda benar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception: {ex.Message}");
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
                    ReservasiEntity reservasiToDelete = listReservation[selectedIndex];

                    // Panggil method Delete dengan Barang yang akan dihapus
                    int result = reservasiController.Delete(reservasiToDelete);
                    if (result > 0)
                    {
                        MessageBox.Show("Data erservasi berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataReservation(); // Refresh data setelah menghapus data barang
                        cmbListRoomId.Text = "";
                        cmbListClientId.Text = "";
                        DateInsertFieldIn.Text = "";
                        DateInsertFieldOut.Text = "";
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
                reservasi.id_room.ToString().ToLower().Contains(keyword.ToLower())
            ).ToList();

            // Clear the ListView
            lvwReservation.Items.Clear();

            // Display the filtered items in the ListView
            foreach (var reservation in filterReservasi)
            {
                var noUrut = lvwReservation.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(reservation.id_reservasi.ToString());
                item.SubItems.Add(reservation.id_room.ToString());
                item.SubItems.Add(reservation.masuk.ToString());
                item.SubItems.Add(reservation.keluar);
                lvwReservation.Items.Add(item);
            }
        }

        private void DateInsertFieldIn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
