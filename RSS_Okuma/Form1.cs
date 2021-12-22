using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSS_Okuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {

            List<Haber> kayitlar = xmlCevir();
            lstBaslik.DataSource = kayitlar;

        }


        private List<Haber> xmlCevir()
        {
            List<Haber> haberKayitlari = new List<Haber>();
            XDocument xmlKaynak = XDocument.Load(txtRss.Text);

            List<XElement> rows = xmlKaynak.Descendants("item").ToList();
            foreach (XElement item in rows)
            {

                Haber temp = new Haber();
                temp.baslik = item.Element("title").Value;
                temp.link = item.Element("link").Value;
                temp.aciklama = item.Element("description").Value;
                haberKayitlari.Add(temp);
                
            }
            return haberKayitlari;
        }

        private void lstBaslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox secilenDeger = (ListBox)sender;
            Haber secilenHaber = (Haber)secilenDeger.SelectedItem;
            webBrowser1.DocumentText = secilenHaber.aciklama;
        }
    }
}
