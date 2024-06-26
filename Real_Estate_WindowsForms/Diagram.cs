using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Real_Estate_WindowsForms
{
    public partial class Diagram : Form
    {
        private SQLiteHelper dbHelper;

        public Diagram(bool _)
        {
            InitializeComponent();
            dbHelper = new SQLiteHelper();
            LoadChartData();
        }

        private void LoadChartData()
        {
            string query = @"
            SELECT 
                trt.NameOfTheRealEstateType AS RealEstateType, 
                COUNT(re.Code) AS RealEstateCount
            FROM 
                RealEstate re
            JOIN 
                TypeOfRealEstate trt ON re.TypeOfRealEstateCode = trt.Code
            GROUP BY 
                trt.NameOfTheRealEstateType;
        ";
            DataTable dt = dbHelper.DTExecuteQueryDT(query);
            PopulateChart(dt);
        }

        private void PopulateChart(DataTable dt)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Количество недвижимости по типам");

            Series series = new Series("RealEstateCount")
            {
                XValueMember = "RealEstateType",
                YValueMembers = "RealEstateCount",
                ChartType = SeriesChartType.Pie,
                LabelForeColor = Color.White, // Цвет текста на диаграмме
                LegendText = "#VALX (#VALY)" // Текст в легенде
            };

            series.Label = "#VALX: #VALY"; // Добавить метки, показывающие категорию и значение
            series.LabelForeColor = Color.White; // Установка белого цвета текста на диаграмме
            series.Font = new Font("TMS", 10, FontStyle.Bold); // Установка шрифта TMS размером 20
            

            chart1.Series.Add(series);
            chart1.DataSource = dt;
            chart1.DataBind();

            // Установка белого цвета и увеличенного размера текста для легенды
            chart1.Legends[0].ForeColor = Color.White;
            chart1.Legends[0].BackColor = Color.Black; // Черный фон для легенды
            chart1.Legends[0].Font = new Font("TMS", 10, FontStyle.Bold); // Увеличение размера текста легенды

            // Установка увеличенного размера текста для заголовка
            chart1.Titles[0].Font = new Font("TMS", 10, FontStyle.Bold);
            chart1.Titles[0].ForeColor = Color.White;
            chart1.Titles[0].BackColor = Color.Black; // Черный фон для заголовка
        }



        private void Update_Click(object sender, EventArgs e)
        {
            LoadChartData();
        }
    }
}
