using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Test5exe
{
    public partial class Main : Form
    {
        [DllImport(@"RndSqr21.dll", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall,
            EntryPoint = "_irndsqr21@92")]
        private static extern void RndSqr21(double a, double b, double h1,
            double h2, double s, double s01, double d1, double d2,
            double e, ref double dC, ref double dL, ref double um,
            ref double em, ref double z0);

        private void Button1_Click(object sender, EventArgs ea)
        {
            LLabel.Text = null;
            CLabel.Text = null;
            EmLabel.Text = null;
            Z0Label.Text = null;
            UmLabel.Text = null;
            var a = Convert.ToDouble(aTextBox.Text);
            var b = Convert.ToDouble(bTextBox.Text);
            var h1 = Convert.ToDouble(h1TextBox.Text);
            var h2 = Convert.ToDouble(h2TextBox.Text);
            var s = Convert.ToDouble(sTextBox.Text);
            var s0 = Convert.ToDouble(s0TextBox.Text);
            var d1 = Convert.ToDouble(d1TextBox.Text);
            var d2 = Convert.ToDouble(d2TextBox.Text);
            var er = Convert.ToDouble(eTextBox.Text);
            var dL = new double[2, 2];
            var dC = new double[2, 2];
            var um = new double[2, 2];
            var dZ0 = new double[2, 2];
            var em = new double[2];
            RndSqr21(a, b, h1, h2, s, s0, d1, d2, er,
                ref dC[0, 0], ref dL[0, 0], ref um[0, 0], ref em[0],
                ref dZ0[0, 0]);
            Print(dL, LLabel);
            Print(dC, CLabel);
            Print(dZ0, Z0Label);
            Print(um, UmLabel);
            for (var i = 0; i < 2; i++)
            {
                EmLabel.Text += Math.Round(em[i], 4).ToString("0.0000");
                EmLabel.Text += "\n";
            }
        }

        private static void Print(double[,] array, Control label)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    label.Text += Math.Round(array[i, j], 4).ToString("0.0000");
                    label.Text += "  ";
                }
                label.Text += "\n";
            }
        }

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
