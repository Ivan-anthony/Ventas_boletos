using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class TravelRoutesForm : Form
{
    private List<TravelRoute> travelRoutes;

    public TravelRoutesForm()
    {
        InitializeComponent();

        // Load travel route data (replace with your actual data loading logic)
        travelRoutes = new List<TravelRoute>()
        {
            new TravelRoute() { RouteId = 1, Origin = "Lima", Destination = "Cusco", TravelTime = 6 },
            new TravelRoute() { RouteId = 2, Origin = "Arequipa", Destination = "Puno", TravelTime = 4 },
            new TravelRoute() { RouteId = 3, Origin = "Trujillo", Destination "Chiclayo", TravelTime = 3 },
        };

        // Bind travel routes to list view
        listViewRoutes.Items.Clear();
        foreach (TravelRoute route in travelRoutes)
        {
            ListViewItem item = new ListViewItem(route.RouteId.ToString());
            item.SubItems.Add(route.Origin);
            item.SubItems.Add(route.Destination);
            item.SubItems.Add(route.TravelTime.ToString() + " horas");
            listViewRoutes.Items.Add(item);
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

public class TravelRoute
{
    public int RouteId { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int TravelTime { get; set; } // In hours
}
