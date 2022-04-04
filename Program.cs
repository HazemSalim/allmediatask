using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllMediaDesk
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Task1();

             // Task2();

             //Task3();

        }

        private static void Task3()
        {
            string input = string.Empty;
            var inputs = new List<string>();
            var outputs = new List<string>();
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("X", typeof(string));
            dt.Columns.Add("Y", typeof(int));

            while (true)
            {
                Console.WriteLine("Enter expression , quit (q)");
                input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    dataSet.Tables.Add(dt);
                    drawGraph(dataSet);
                }
                else
                {
                    DataRow r1 = dt.NewRow();
                    r1[0] = input;
                    r1[1] = 8;
                    dt.Rows.Add(r1);


                    inputs.Add(input);
                    input = RemoveBrackets(input);

                    r1[1] = new Calculator(input).expression().ToString();
                }
            }

        }

        private static void Task2()
        {
            string input = string.Empty;
            Console.WriteLine("Enter Number");
            input = Console.ReadLine();
            int num = PeterNumbers.GetPeterNumber(int.Parse(input), 0, 0, 0);
            Console.WriteLine("Peter Number is" + num);
           
        }

        private static void Task1()
        {
            string input;
            Console.WriteLine("Enter expression");
            input = Console.ReadLine();

            input = RemoveBrackets(input);

            Console.WriteLine(new Calculator(input).expression());
             
        }

        private static void drawGraph(DataSet dataSet)
        {
            //populate dataset with some demo data..



            //prepare chart control...
            Chart chart = new Chart();
            chart.DataSource = dataSet.Tables[0];
            chart.Width = 600;
            chart.Height = 350;
            //create serie...
            Series serie1 = new Series();
            serie1.Name = "Serie";
            serie1.Color = Color.FromArgb(112, 255, 200);
            serie1.BorderColor = Color.FromArgb(164, 164, 164);
            serie1.ChartType = SeriesChartType.Column;
            serie1.BorderDashStyle = ChartDashStyle.Solid;
            serie1.BorderWidth = 1;
            serie1.ShadowColor = Color.FromArgb(128, 128, 128);
            serie1.ShadowOffset = 1;
            serie1.IsValueShownAsLabel = true;
            serie1.XValueMember = "X";
            serie1.YValueMembers = "Y";
            serie1.Font = new Font("Tahoma", 8.0f);
            serie1.BackSecondaryColor = Color.FromArgb(0, 102, 153);
            serie1.LabelForeColor = Color.FromArgb(100, 100, 100);
            chart.Series.Add(serie1);
            //create chartareas...
            ChartArea ca = new ChartArea();
            ca.Name = "ChartArea1";
            ca.BackColor = Color.White;
            ca.BorderColor = Color.FromArgb(26, 59, 105);
            ca.BorderWidth = 0;
            ca.BorderDashStyle = ChartDashStyle.Solid;
            ca.AxisX = new Axis();
            ca.AxisY = new Axis();
            chart.ChartAreas.Add(ca);
            //databind...
            chart.DataBind();
            //save result...
            chart.SaveImage(@"d:\myChart.png", ChartImageFormat.Png);

            Console.WriteLine(@"Chart Saved to d:\myChart.png");
        }

        private static string RemoveBrackets(string input)
        {
            while (input.Contains("("))
            {
                string tempValue = Regex.Match(input, @"\(([^)]*)\)").Groups[1].Value;
                string delTerm = "(" + tempValue + ")";
                double tmpValue = new Calculator(tempValue).expression();
                input = input.Replace(delTerm, tmpValue.ToString());

            }

            return input;
        }
    }
}