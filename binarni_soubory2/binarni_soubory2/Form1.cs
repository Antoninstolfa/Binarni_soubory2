using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binarni_soubory2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader cistcisla = new StreamReader("cisla.txt");
            FileStream datovytok = new FileStream("cisla.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter zapisovac = new BinaryWriter(datovytok, Encoding.GetEncoding("windows-1250"));
            while(!cistcisla.EndOfStream)
            {
                long cislo = long.Parse(cistcisla.ReadLine());
                zapisovac.Write(cislo);
            }
            //zapisovac.Close();
            BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            ctenar.BaseStream.Position = 0;
            while(ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                listBox1.Items.Add(ctenar.ReadInt64());
                listBox1.Items.Add(sizeof(long));
            }
            datovytok.Close();
            cistcisla.Close();
            //ctenar.Close();
        }
    }
}
