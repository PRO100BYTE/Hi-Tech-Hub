using System;
using System.Drawing;
using System.Windows.Forms;

namespace LauncherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Добавил этот вызов
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Установить свойства формы
            this.FormBorderStyle = FormBorderStyle.None; // Без рамки
            this.WindowState = FormWindowState.Maximized; // В полноэкранном режиме
            this.TopMost = true; // Поверх всех других окон
            this.BackColor = Color.Black; // Черный фон

            // Создать элементы управления для отрисовки сайта
            var logo = new PictureBox(); // Логотип
            logo.Image = Image.FromFile("logo2.png");
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Width = 300;
            logo.Height = 150;
            logo.Location = new Point((this.Width - logo.Width) / 2, 25);
            this.Controls.Add(logo);

            var title = new Label(); // Заголовок
            title.Text = "Hi-Tech Hub v1 Beta";
            title.Font = new Font("OutRun", 36, FontStyle.Regular);
            title.ForeColor = Color.White;
            title.AutoSize = true;
            title.Location = new Point((this.Width - title.Width) / 2, logo.Bottom + 15);
            this.Controls.Add(title);

            var subtitle = new Label(); // Подзаголовок
            subtitle.Text = "by #TheDayG0ne";
            subtitle.Font = new Font("Montserrat", 18, FontStyle.Regular);
            subtitle.ForeColor = Color.White;
            subtitle.AutoSize = true;
            subtitle.Location = new Point((this.Width - subtitle.Width) / 2, title.Bottom + 5);
            this.Controls.Add(subtitle);

            var triangle = new Panel(); // Треугольник
            triangle.BackColor = Color.FromArgb(108, 5, 5, 5);
            triangle.Width = 510;
            triangle.Height = 480;
            triangle.Location = new Point((this.Width - triangle.Width) / 2, subtitle.Bottom + 33);
            triangle.Paint += Triangle_Paint; // Отрисовать треугольник внутри панели
            this.Controls.Add(triangle);

            var menu1 = new Button(); // Первый пункт меню
            menu1.Text = "О нас";
            menu1.Font = new Font("OutRun", 48, FontStyle.Regular);
            menu1.ForeColor = Color.White;
            menu1.BackColor = Color.Transparent;
            menu1.FlatStyle = FlatStyle.Flat;
            menu1.FlatAppearance.BorderSize = 0;
            menu1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 255, 255, 255);
            menu1.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 255, 255);
            menu1.Width = 400;
            menu1.Height = 80;
            menu1.Location = new Point((this.Width - menu1.Width) / 2, triangle.Top + triangle.Height / 4);
            menu1.Click += (s, e1) => System.Diagnostics.Process.Start("https://hitech.pro100byte.ru"); // Открыть ссылку при клике
            this.Controls.Add(menu1);

            var menu2 = new Button(); // Второй пункт меню
            menu2.Text = "Портфолио";
            menu2.Font = new Font("OutRun", 48, FontStyle.Regular);
            menu2.ForeColor = Color.White;
            menu2.BackColor = Color.Transparent;
            menu2.FlatStyle = FlatStyle.Flat;
            menu2.FlatAppearance.BorderSize = 0;
            menu2.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 255, 255, 255);
            menu2.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 255, 255);
            menu2.Width = 400;
            menu2.Height = 80;
            menu2.Location = new Point((this.Width - menu2.Width) / 2, menu1.Bottom + 20);
            menu2.Click += (s, e2) => System.Diagnostics.Process.Start("https://portfolio.pro100byte.ru"); // Открыть ссылку при клике
            this.Controls.Add(menu2);

            var menu3 = new Button(); // Третий пункт меню
            menu3.Text = "Проекты TehnoLab";
            menu3.Font = new Font("OutRun", 36, FontStyle.Regular);
            menu3.ForeColor = Color.White;
            menu3.BackColor = Color.Transparent;
            menu3.FlatStyle = FlatStyle.Flat;
            menu3.FlatAppearance.BorderSize = 0;
            menu3.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 255, 255, 255);
            menu3.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 255, 255);
            menu3.Width = 400;
            menu3.Height = 80;
            menu3.Location = new Point((this.Width - menu3.Width) / 2, menu2.Bottom + 20);
            menu3.Click += (s, e3) => System.Diagnostics.Process.Start("https://tehnolab.pro100byte.ru"); // Открыть ссылку при клике
            this.Controls.Add(menu3);
        }

        private void Triangle_Paint(object sender, PaintEventArgs e)
        {
            // Отрисовать треугольник внутри панели
            var panel = sender as Panel;
            var g = e.Graphics;
            var p1 = new Point(0, panel.Height);
            var p2 = new Point(panel.Width / 4 * 3, panel.Height);
            var p3 = new Point(panel.Width / 4 * 1, 0);
            g.FillPolygon(Brushes.Black, new[] { p1, p2, p3 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"HiTechBrowser.exe", "--link=https://projects.thedayg0ne.ru/tehnolab"); // Открыть ссылку при клике
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"HiTechBrowser.exe", "--link=https://hitech.pro100byte.ru"); // Открыть ссылку при клике
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"HiTechBrowser.exe", "--link=https://portfolio.pro100byte.ru"); // Открыть ссылку при клике
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"HiTechBrowser.exe", "--link=https://pro100byte.ru"); // Открыть ссылку при клике
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"HiTechBrowser.exe", "--link=https://thedayg0ne.ru"); // Открыть ссылку при клике
        }
    }
}
