using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;
using static System.Windows.Forms.LinkLabel;
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace vixulycuoiky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] pause = { "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200" };
        string[] tg = { "0.5s", "1s", "1.5s", "2s", "2.5s", "3s", "3.5s", "4s", "4.5s", "5s" };
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] listnamecom = SerialPort.GetPortNames();
            liscom.Items.AddRange(listnamecom);
            lisbaud.Items.AddRange(pause);
            listime.Items.AddRange(tg);
            GraphPane mypane = zedGraphControl1.GraphPane;
            mypane.Title.Text = "BIỂU ĐỒ NHIỆT ĐỘ";
            mypane.XAxis.Title.Text = "THỜI GIAN";
            mypane.YAxis.Title.Text = "NHIỆT ĐỘ";

            RollingPointPairList list1 = new RollingPointPairList(60000);
            LineItem duongline = mypane.AddCurve("Nhiệt độ", list1, Color.Red, SymbolType.Diamond);

            mypane.XAxis.Scale.Min = 0;
            mypane.XAxis.Scale.Max = 100;
            mypane.XAxis.Scale.MinorStep = 1;
            mypane.XAxis.Scale.MajorStep = 2;

            mypane.YAxis.Scale.Min = 0;
            mypane.YAxis.Scale.Max = 100;
            mypane.YAxis.Scale.MinorStep = 1;
            mypane.YAxis.Scale.MajorStep = 2;
            zedGraphControl1.AxisChange();
        }
        int tong = 0;
        public void draw(double line1)
        {
            LineItem duongline = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (duongline == null)
                return;
            IPointListEdit list1 = duongline.Points as IPointListEdit;
            if (list1 == null)
                return;
            list1.Add(tong, line1);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            tong += 2;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (liscom.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn cổng COM", "Thông Báo");
                }
                if (lisbaud.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn tốc độ BAUDRATE", "Thông Báo");
                }
                if (serialPort1.IsOpen == true)
                {
                    serialPort1.Close();
                    button1.Text = "CONNECT";
                }
                else if (serialPort1.IsOpen == false)
                {
                    serialPort1.PortName = liscom.Text;
                    serialPort1.BaudRate = int.Parse(lisbaud.Text);
                    serialPort1.Open();
                    button1.Text = "DISCONNECT";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        bool tb1 = true;
        private void den1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb1 == true)
                {
                    serialPort1.Write("1");
                    den1.Text = "ON";
                    tb1 = false;
                }
                else
                {
                    serialPort1.Write("a");
                    den1.Text = "OFF";
                    tb1 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb2 = true;
        private void den2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb2 == true)
                {
                    serialPort1.Write("2");
                    den2.Text = "ON";
                    tb2 = false;
                }
                else
                {
                    serialPort1.Write("b");
                    den2.Text = "OFF";
                    tb2 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb3 = true;
        private void den3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb3 == true)
                {
                    serialPort1.Write("3");
                    den3.Text = "ON";
                    tb3 = false;
                }
                else
                {
                    serialPort1.Write("c");
                    den3.Text = "OFF";
                    tb3 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb4 = true;
        private void den4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb4 == true)
                {
                    serialPort1.Write("4");
                    den4.Text = "ON";
                    tb4 = false;
                }
                else
                {
                    serialPort1.Write("d");
                    den4.Text = "OFF";
                    tb4 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb5 = true;
        private void den5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb5 == true)
                {
                    serialPort1.Write("5");
                    den5.Text = "ON";
                    tb5 = false;
                }
                else
                {
                    serialPort1.Write("e");
                    den5.Text = "OFF";
                    tb5 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb6 = true;
        private void den6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb6 == true)
                {
                    serialPort1.Write("6");
                    den6.Text = "ON";
                    tb6 = false;
                }
                else
                {
                    serialPort1.Write("f");
                    den6.Text = "OFF";
                    tb6 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb7 = true;
        private void den7_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb7 == true)
                {
                    serialPort1.Write("7");
                    den7.Text = "ON";
                    tb7 = false;
                }
                else
                {
                    serialPort1.Write("g");
                    den7.Text = "OFF";
                    tb7 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        bool tb8 = true;
        private void den8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tb8 == true)
                {
                    serialPort1.Write("8");
                    den8.Text = "ON";
                    tb8 = false;
                }
                else
                {
                    serialPort1.Write("h");
                    den8.Text = "OFF";
                    tb8 = true;
                }
            }
            catch
            {
                MessageBox.Show("LỖI");
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = "";
            data = serialPort1.ReadLine();
            data = data.Trim();
            if (data.Length > 0)
            {

                if (int.TryParse(data, out int result))
                {
                    Invoke(new MethodInvoker(() => draw(Convert.ToDouble(data))));
                    Invoke(new MethodInvoker(() => listBox1.Items.Add(data)));
                }
                else
                {
                    string kitu = data.Substring(0,2);
                    Invoke(new MethodInvoker(() => listBox2.Items.Add(kitu)));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("v");
            if (listime.Text == "0.5s")
            {
                serialPort1.Write("q");
            }
            if (listime.Text == "1s")
            {
                serialPort1.Write("w");
            }
            if (listime.Text == "1.5s")
            {
                serialPort1.Write("r");
            }
            if (listime.Text == "2s")
            {
                serialPort1.Write("t");
            }
            if (listime.Text == "2.5s")
            {
                serialPort1.Write("y");
            }
            if (listime.Text == "3s")
            {
                serialPort1.Write("u");
            }
            if (listime.Text == "3.5s")
            {
                serialPort1.Write("i");
            }
            if (listime.Text == "4s")
            {
                serialPort1.Write("o");
            }
            if (listime.Text == "4.5s")
            {
                serialPort1.Write("p");
            }
            if (listime.Text == "5s")
            {
                serialPort1.Write("z");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("x");
        }
    }
}

          
