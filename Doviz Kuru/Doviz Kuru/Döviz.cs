using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Kuru
{
    public partial class Döviz : Form
    {
        public Döviz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();

            xmldoc.Load(bugun);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            label2.Text = tarih.ToString();

            string usd = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='USD'] / BanknoteSelling").InnerXml;
            string usd1 = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='USD'] / BanknoteBuying").InnerXml;
            label10.Text = usd;
            label9.Text = usd1;

            string euro = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='EUR'] / BanknoteSelling").InnerXml;
            string euro1 = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='EUR'] / BanknoteBuying").InnerXml;
            label11.Text = euro;
            label12.Text = euro1;

            string pound = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='GBP'] / BanknoteSelling").InnerXml;
            string pound1 = xmldoc.SelectSingleNode("Tarih_Date/ Currency [@Kod='GBP'] / BanknoteBuying").InnerXml;
            label13.Text = pound;
            label14.Text = pound1;
        }
    }
}
