using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace skillMeDBL
{

    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;

        String comboChoice = "North 🠙";
        String comboChoiceRes = "1900x1080";
        Boolean isFoodEnabled = false;
        Boolean isReapirEnabled = false;

        public static Process[] processes = Process.GetProcessesByName("DBLClient");
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            
        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("START"))
            {
                SetTimer();
                button1.Text = "STOP";
                timer1.Start();
            }
            else
            {
                if (aTimer != null) aTimer.Stop();
                button1.Text = "START";
                timer1.Stop();
                progressBar1.Value = 0;
            }
                

        }

        [STAThread]
        public void antyKick()
        {
            
            
                foreach (Process proc in processes)
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    Thread.Sleep(100);

                    if (comboChoice.Equals("North 🠙")) antyKickDBL("^{DOWN}", "^{UP}");
                    else if (comboChoice.Equals("West 🠘")) antyKickDBL(" ^{RIGHT}", "^{LEFT}");
                    else if (comboChoice.Equals("East 🠚")) antyKickDBL(" ^{LEFT}", "^{RIGHT}");
                    else if (comboChoice.Equals("South 🠛")) antyKickDBL(" ^{UP}", "^{DOWN}");

                }
            
        }

        private void SetTimer()
        {
            antyKick();
            Thread.Sleep(100);
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(800000-300);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void antyKickDBL(String s1, String s2)
        {
            SendKeys.SendWait(s1);
            Thread.Sleep(100);
            SendKeys.SendWait(s2);
            Thread.Sleep(100);
            if (isFoodEnabled) eatFood();
            if (isReapirEnabled) repairEQ();

        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            antyKick();
        }

        private void eatFood()
        {
            for(int i=0;i<20;i++) SendKeys.SendWait("{F8}");
        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aTimer != null) aTimer.Stop();
            button1.Text = "START";
            timer1.Stop();
            progressBar1.Value = 0;
            comboChoice = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) isFoodEnabled = true;
            else isFoodEnabled = false;

            if (aTimer != null) aTimer.Stop();
            button1.Text = "START";
            timer1.Stop();
            progressBar1.Value = 0;
        }

        public void Clicker(int x, int y)
        {
            SetCursorPos(x, y);
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X,Y, 0, 0);

        }
        public void repairEQ()
        {
            if (comboChoiceRes.Equals("1900x1080"))
            {
                Clicker(1750, 146); // left hand
                Clicker(1830, 147); // right hand
                Clicker(1750, 183); // belt
                Clicker(1790, 140); // armor
                Clicker(1790, 177); // legs
                Clicker(1790, 215); // boots
            }else if (comboChoiceRes.Equals("1600x900")){
                Clicker(1432,148); // left hand
                Clicker(1506,153); // right hand
                Clicker(1431,186); // belt
                Clicker(1466,140); // armor
                Clicker(1470,172); // legs
                Clicker(1463,212); // boots
            }
            else if (comboChoiceRes.Equals("1440x900")){
                Clicker(1270,148); // left hand
                Clicker(1347,150); // right hand
                Clicker(1272,183); // belt
                Clicker(1309,140); // armor
                Clicker(1308,179); // legs
                Clicker(1309,211); // boots
            }
            else if (comboChoiceRes.Equals("1366x768")){
                Clicker(1200,150); // left hand
                Clicker(1273,150); // right hand
                Clicker(1200,183); // belt
                Clicker(1234,141); // armor
                Clicker(1234,176); // legs
                Clicker(1234,215); // boots
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) isReapirEnabled = true;
            else isReapirEnabled = false;

            if (aTimer != null) aTimer.Stop();
            button1.Text = "START";
            timer1.Stop();
            progressBar1.Value = 0;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aTimer != null) aTimer.Stop();
            button1.Text = "START";
            timer1.Stop();
            progressBar1.Value = 0;
            comboChoiceRes = comboBox2.GetItemText(comboBox2.SelectedItem);
        }

        public void testResolution()
        {

            if (comboChoiceRes.Equals("1900x1080"))
            {
                Thread.Sleep(1000);
                Clicker(1750, 146); // left hand
                Thread.Sleep(1000);
                Clicker(1830, 147); // right hand
                Thread.Sleep(1000);
                Clicker(1750, 183); // belt
                Thread.Sleep(1000);
                Clicker(1790, 140); // armor
                Thread.Sleep(1000);
                Clicker(1790, 177); // legs
                Thread.Sleep(1000);
                Clicker(1790, 215); // boots
                Thread.Sleep(1000);
            }
            else if (comboChoiceRes.Equals("1600x900"))
            {
                Thread.Sleep(1000);
                Clicker(1432, 148); // left hand
                Thread.Sleep(1000);
                Clicker(1506, 153); // right hand
                Thread.Sleep(1000);
                Clicker(1431, 186); // belt
                Thread.Sleep(1000);
                Clicker(1466, 140); // armor
                Thread.Sleep(1000);
                Clicker(1470, 172); // legs
                Thread.Sleep(1000);
                Clicker(1463, 212); // boots
                Thread.Sleep(1000);
            }
            else if (comboChoiceRes.Equals("1440x900"))
            {
                Thread.Sleep(1000);
                Clicker(1270, 148); // left hand
                Thread.Sleep(1000);
                Clicker(1347, 150); // right hand
                Thread.Sleep(1000);
                Clicker(1272, 183); // belt
                Thread.Sleep(1000);
                Clicker(1309, 140); // armor
                Thread.Sleep(1000);
                Clicker(1308, 179); // legs
                Thread.Sleep(1000);
                Clicker(1309, 211); // boots
                Thread.Sleep(1000);
            }
            else if (comboChoiceRes.Equals("1366x768"))
            {
                Thread.Sleep(1000);
                Clicker(1200, 150); // left hand
                Thread.Sleep(1000);
                Clicker(1273, 150); // right hand
                Thread.Sleep(1000);
                Clicker(1200, 183); // belt
                Thread.Sleep(1000);
                Clicker(1234, 141); // armor
                Thread.Sleep(1000);
                Clicker(1234, 176); // legs
                Thread.Sleep(1000);
                Clicker(1234, 215); // boots
                Thread.Sleep(1000);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            testResolution();
        }
    }
}
