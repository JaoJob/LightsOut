using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int[] arrayOnOff = new int[25] ;
        public int score = 0;

       
        private void ClickLabel(object sender, EventArgs e)
        {                                                                                //обработка нажатия на любое поле
            Label tempLabel = (Label)sender;
            int a = tempLabel.TabIndex;
            score += 1;
            arrayOnOff[a - 1] *= -1;
            if (a > 5) arrayOnOff[a - 6] *= -1;                                             //меняем состояние соседних полей, если нужно
            if (a <= 20) arrayOnOff[a + 4] *= -1;
            if (a != 5 && a != 10 && a != 15 && a != 20 && a != 25) arrayOnOff[a] *= -1;
            if (a != 1 && a != 6 && a != 11 && a != 16 && a != 21) arrayOnOff[a - 2] *= -1;
            RefreshLabels();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();                                                      //устанавливаем все поля в случайные состояния
            for (int i = 0; i <= 24; i++)
            {   
                arrayOnOff[i] = rnd.Next(2) == 0 ? -1 : 1; 
            }
            RefreshLabels();
            score = 0;

        }
        public void RefreshLabels()
        {
            int res = 0;
            for (int i = 1; i <= 25; i++)                                                   //обновляем состояние всех полей
            {
                string vr = "label" + i.ToString();

                if (arrayOnOff[i - 1] == -1) this.Controls[vr].BackColor = Color.Black;
                if (arrayOnOff[i - 1] == 1) this.Controls[vr].BackColor = Color.Yellow;
                res += arrayOnOff[i - 1];
                if (res == 25) { MessageBox.Show(score + " ходов"); break; }
            }
        }

    }
}
