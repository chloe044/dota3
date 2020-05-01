using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Cinema> cinemasList = new List<Cinema>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo(); 
        }
        private void BtnRefill_Click(object sender, EventArgs e)
        {
            this.cinemasList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: 
                        this.cinemasList.Add(Film.Generate());
                        break;
                    case 1: 
                        this.cinemasList.Add(Series.Generate());
                        break;
                    case 2: 
                        this.cinemasList.Add(Telecast.Generate());
                        break;
                }
            }
            ShowInfo(); 
        }
        private void ShowInfo()
        {
            int filmCount = 0;
            int SeriesCount = 0;
            int TelecastCount = 0;
            foreach (var movies in this.cinemasList)
            {
                if (movies is Film) 
                {
                    filmCount += 1;
                }
                else if (movies is Series)
                {
                    SeriesCount += 1;
                }
                else if (movies is Telecast)
                {
                    TelecastCount += 1;
                }
            }
            txtInfo.Text = "Фильмы\t\tСериалы\t\tТелепередачи"; 
            txtInfo.Text += "\n\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", filmCount, SeriesCount, TelecastCount);
        }
        private void BtnGet_Click(object sender, EventArgs e)
        {
            if (this.cinemasList.Count == 0)
            {
                txtOut.Text = "Пусто gg";
                return;
            }
            var movie = this.cinemasList[0];
            this.cinemasList.RemoveAt(0);
            txtOut.Text = movie.GetInfo();
            ShowInfo();
        }
    }
}
