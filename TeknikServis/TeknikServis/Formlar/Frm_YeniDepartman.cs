using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class Frm_YeniDepartman : Form
    {
        public Frm_YeniDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtad.Text.Length <= 50 && txtad.Text != "")
            {
                TBL_DEPARTMAN d = new TBL_DEPARTMAN();
                d.AD = txtad.Text;
                db.TBL_DEPARTMAN.Add(d);
                db.SaveChanges();
                MessageBox.Show("Yeni Departman Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Departman Kaydedilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
