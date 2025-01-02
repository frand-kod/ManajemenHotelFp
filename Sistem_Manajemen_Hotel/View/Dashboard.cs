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
    
    public partial class Dashboard : UserControl
    {
        private RoomController roomController = new RoomController();
        public Dashboard()
        {
            InitializeComponent();
            UpdateRoomCountsLabel();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
        }

        private void UpdateRoomCountsLabel()
        {
            var controller = new RoomController();
            var roomCounts = controller.GetRoomCountsByType();

            lblValueSingle.Text = roomCounts.ContainsKey("Standard")
                ? $"Standard: {roomCounts["Standard"]}"
                : "Standard: 0";
            Debug.WriteLine($"Standard: {roomCounts["Standard"]}");
            // Tambahkan label lain sesuai jenis kamar
            lblDoubleValue.Text = roomCounts.ContainsKey("Deluxe")
                ? $"Deluxe: {roomCounts["Deluxe"]}"
                : "Deluxe: 0";
            Debug.WriteLine($"Deluxe: {roomCounts["Deluxe"]}");
            // Tambahkan label lain sesuai jenis kamar
            lblFamilyValue.Text = roomCounts.ContainsKey("Family")
                ? $"Family: {roomCounts["Family"]}"
                : "Family: 0";
           // Debug.WriteLine($"Family: {roomCounts["Family"]}");
            lblSuiteValue.Text = roomCounts.ContainsKey("Suite")
                ? $"Suite: {roomCounts["Suite"]}"
                : "Suite: 0";
            //Debug.WriteLine($"Suite: {roomCounts["Suite"]}");

        }

    }
}

