using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi06_02.frm
{
    public partial class frmTroGiup : Form
    {
        public frmTroGiup()
        {
            InitializeComponent();
        }
        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là thông tin trợ giúp chi tiết về cách sử dụng ứng dụng.", "Trợ Giúp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mở tài liệu trợ giúp (file .chm)
        private void btnOpenHelpFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở file .chm chứa tài liệu trợ giúp
                Help.ShowHelp(this, "helpfile.chm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở tài liệu trợ giúp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mở trợ giúp trực tuyến
        private void btnOpenOnlineHelp_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở trang web trợ giúp trực tuyến
                System.Diagnostics.Process.Start("http://www.example.com/support");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở trợ giúp trực tuyến: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmTroGiup_Load(object sender, EventArgs e)
        {

        }
    }
}
