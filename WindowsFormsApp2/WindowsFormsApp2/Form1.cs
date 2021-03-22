using System.Management;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }
        private void Form1_Load()
        {
            TreeNode node;
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectSearcher s =
                new ManagementObjectSearcher(
                    "SELECT * FROM FROM Win32_Keyboard");

            foreach (var o in s.Get())
            {
                var service = (ManagementObject) o;
                // show the instance
                treeView1.Nodes.Add(service.ToString());
            }

            foreach (var o in searcher.Get())
            {
                var info = (ManagementObject) o;
                node = treeView1.Nodes.Add(info["DeviceID"].ToString());
                node.Nodes.Add("Model: " + info["Model"].ToString());
                node.Nodes.Add("Interface: " + info["InterfaceType"].ToString());
                node.Nodes.Add("Serial: " + info["SerialNumber"].ToString());
            }
            treeView1.ExpandAll();
        }

    }
    
    
}