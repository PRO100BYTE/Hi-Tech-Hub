using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiTechLaunch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Создаем форму с экраном загрузки
            Form splashForm = new Form();
            splashForm.BackgroundImage = Properties.Resources.splash; // Загружаем изображение из ресурсов проекта
            splashForm.BackgroundImageLayout = ImageLayout.Stretch; // Растягиваем изображение на всю форму
            splashForm.FormBorderStyle = FormBorderStyle.None; // Убираем рамку и кнопки формы
            splashForm.StartPosition = FormStartPosition.CenterScreen; // Центрируем форму на экране
            splashForm.Show(); // Показываем форму
        }

    }
}
