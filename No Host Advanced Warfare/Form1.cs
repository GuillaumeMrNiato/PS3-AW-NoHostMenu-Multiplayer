using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using System.IO;
using System.Net;

namespace No_Host_Advanced_Warfare
{
    public partial class Form1 : Form
    {
        public static PS3API PS3 = new PS3API(SelectAPI.TargetManager);
        #region Key
        class Key_IsDown
        {
            public enum Key : uint
            {
                Cross = 0,
                Circle = 1,
                Square = 2,
                Triangle = 3,
                L1 = 4,
                R1 = 5,
                Start = 13,
                Select = 14,
                L3 = 15,
                R3 = 16,
                DPAD_UP = 19,
                DPAD_DOWN = 20,
                DPAD_LEFT = 21,
                DPAD_RIGHT = 22,
            }
            public static Boolean DetectKey(Key k)
            {
                //0xD912B4
               // System.Net.WebClient request = new System.Net.WebClient();
               // uint Update = Convert.ToUInt32(request.DownloadString("http://pastebin.com/raw.php?i=VZiyZp7p"));
                return PS3.Extension.ReadBool((0xD912B4 + 0x0F) + ((UInt32)k * 0xC));
            }
        }
        #endregion
        //0x4CABE4
        //System.Net.WebClient request = new System.Net.WebClient();
        //uint Update = Convert.ToUInt32(request.DownloadString("http://pastebin.com/raw.php?i=VZiyZp7p"));
        public static uint FPSEnable = 0x4CABE4;
        public static uint FPSSize = 0x4CAB3C;
        public static uint FPSX = 0x4CAB40;
        public static uint FPSY = 0x4CAB44;
        public static uint FPSText = 0x7CC8DC;
        public static uint Stats_Entry = 0x2AE7568;

        public static bool Steady = false;
        public static bool UAV = false;
        public static bool RedBoxes = false;
        public static bool WallHack = false;
        public static bool DakrScreen = false;
        public static bool InvisibleGun = false;
        public static bool Laser = false;
        public static bool SilentGun = false;
        public static bool NoRecoil = false;
        static void WriteText(string Text)
        {
            PS3.Extension.WriteString(FPSText, Text);
        }
        public Form1()
        {
            InitializeComponent();
            string Version = "1.0.0.0";
            string NewVersion = "1.1.0.0";
            System.Net.WebClient request = new System.Net.WebClient();
            string Update = request.DownloadString("http://pastebin.com/raw.php?i=G9bb5aJU");
            if (Update.Contains(Version))
            {
                //MessageBox.Show("The Software is updated !", "Great !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An Update is available !", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("http://pastebin.com/P1FtZ968");
                Application.Exit();
            }
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCmkwQ4IQhOG4XbsbJTL8wrQ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void skyDarkRadio1_Click(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void skyDarkRadio2_Click(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }
        private void skyDarkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget() && PS3.AttachProcess())
                {
                    if (skyDarkCheck1.Checked)
                    {
                        PS3.SetMemory(0x5bc86c, new byte[1]);
                        PS3.Extension.ReadUInt32(0x5bedc4);
                        PS3.Extension.ReadUInt32(0x5bcdbc);
                        PS3.Extension.ReadUInt32(0x668960);
                        PS3.Extension.ReadUInt32(0x668fa0);
                        PS3.Extension.ReadUInt32(0x7ec434);
                        PS3.Extension.ReadUInt32(0x678f68);
                        PS3.Extension.ReadUInt32(0x5bcd24);
                        PS3.Extension.ReadUInt32(0x79542c);
                        PS3.Extension.ReadUInt32(0x795444);

                        toolStripStatusLabel5.Text = "Enable !";
                        toolStripStatusLabel5.ForeColor = Color.Lime;
                    }
                    toolStripStatusLabel2.Text = "Linked !";
                    toolStripStatusLabel2.ForeColor = Color.Lime;
                    byte[] FPSOn = new byte[] { 0x2C, 0x03, 0x01 };
                    PS3.SetMemory(FPSEnable, FPSOn);
                    byte[] FPSXs = new byte[] { 0x43, 0x62 };
                    PS3.SetMemory(FPSX, FPSXs);
                    byte[] FPSYs = new byte[] { 0x41, 0xD8 };
                    PS3.SetMemory(FPSY, FPSYs);
                    WriteText("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n^1-- ^5P^7ress ^2Start Menu ^5T^7o ^5I^7nitialise ^5M^7enu ^1--");
                }
                else
                {
                    toolStripStatusLabel2.Text = "Failed to link PS3 !";
                    toolStripStatusLabel2.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                toolStripStatusLabel2.Text = "Failed to link PS3 !";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            PS3.Extension.WriteFloat(0x4CAB44, trackBar2.Value * -1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PS3.Extension.WriteFloat(0x4CAB40, trackBar1.Value * -1);
        }

        private void HostMainMenu_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^2-->^5Simple Mods\nPrestige Menu\nStats Menu\nName Changer\n\n\n\n^2www.ihax.fr\n^3Facebook : ^2Guillaume ^1MrNiato");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                HostMainMenu.Stop();
                H1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                HostMainMenu.Stop();
                PrestigeMenu.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                HostMainMenu.Stop();
                NameChanger.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                HostMainMenu.Stop();
                Sleep.Start();
            }
        }

        private void MainMenu_Tick(object sender, EventArgs e)
        {
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                MainMenu.Stop();
                HostMainMenu.Start();
            }
        }

        private void skyDarkButton2_Click(object sender, EventArgs e)
        {
            MainMenu.Start();
            WriteText("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n^1-- ^5P^7ress ^2R3 ^5T^7o ^5O^7pen ^5M^7enu ^1--");
        }

        private void Sleep_Tick(object sender, EventArgs e)
        {
            WriteText("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n^1-- ^5P^7ress ^2R3 ^5T^7o ^5O^7pen ^5M^7enu ^1--");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                Sleep.Stop();
                HostMainMenu.Start();
            }
        }

        private void H1_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^2-->^5Steady Aim\nUAV\nRed Boxes\nInvisible Gun\nLaser\nSilent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (Steady == false)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x18787F, godmodebyte);
                    Steady = true;
                }
                else if (Steady == true)
                {
                    byte[] godmodebyte = new byte[] { 0x02 };
                    PS3.SetMemory(0x18787F, godmodebyte);
                    Steady = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H1.Stop();
                H2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H1.Stop();
                H9.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H1.Stop();
                HostMainMenu.Start();
            }
        }

        private void H2_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Steady Aim\n^2-->^5UAV\nRed Boxes\nInvisible Gun\nLaser\nSilent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (UAV == false)
                {
                    byte[] godmodebyte = new byte[] { 0x01 };
                    PS3.SetMemory(0x1A707A, godmodebyte);
                    UAV = true;
                }
                else if (UAV == true)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x1A707A, godmodebyte);
                    UAV = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H2.Stop();
                H3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H2.Stop();
                H1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H2.Stop();
                HostMainMenu.Start();
            }
        }

        private void H3_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Steady Aim\nUAV\n^2-->^5Red Boxes\nInvisible Gun\nLaser\nSilent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (RedBoxes == false)
                {
                    byte[] godmodebyte = new byte[] { 0x01 };
                    PS3.SetMemory(0x1AF6FB, godmodebyte);
                    RedBoxes = true;
                }
                else if (RedBoxes == true)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x1AF6FB, godmodebyte);
                    RedBoxes = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H3.Stop();
                H6.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H3.Stop();
                H2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H3.Stop();
                HostMainMenu.Start();
            }
        }

        private void H4_Tick(object sender, EventArgs e)
        {
        }

        private void H5_Tick(object sender, EventArgs e)
        {
        }

        private void H6_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato ^1--\n\n^5Steady Aim\nUAV\nRed Boxes\n^2-->^5Invisible Gun\nLaser\nSilent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (InvisibleGun == false)
                {
                    byte[] godmodebyte = new byte[] { 0x01 };
                    PS3.SetMemory(0x21B8C7, godmodebyte);
                    InvisibleGun = true;
                }
                else if (InvisibleGun == true)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x21B8C7, godmodebyte);
                    InvisibleGun = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H6.Stop();
                H7.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H6.Stop();
                H3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H6.Stop();
                HostMainMenu.Start();
            }
        }

        private void H7_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Steady Aim\nUAV\nRed Boxes\nInvisible Gun\n^2-->^5Laser\nSilent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (Laser == false)
                {
                    byte[] godmodebyte = new byte[] { 0x01 };
                    PS3.SetMemory(0x21BE37, godmodebyte);
                    Laser = true;
                }
                else if (Laser == true)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x21BE37, godmodebyte);
                    Laser = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H7.Stop();
                H8.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H7.Stop();
                H6.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H7.Stop();
                HostMainMenu.Start();
            }
        }

        private void H8_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Steady Aim\nUAV\nRed Boxes\nInvisible Gun\nLaser\n^2-->^5Silent Gun\nNo Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (SilentGun == false)
                {
                    byte[] godmodebyte = new byte[] { 0x01 };
                    PS3.SetMemory(0x228EDF, godmodebyte);
                    SilentGun = true;
                }
                else if (SilentGun == true)
                {
                    byte[] godmodebyte = new byte[] { 0x00 };
                    PS3.SetMemory(0x228EDF, godmodebyte);
                    SilentGun = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H8.Stop();
                H9.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H8.Stop();
                H7.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H8.Stop();
                HostMainMenu.Start();
            }
        }

        private void H9_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Steady Aim\nUAV\nRed Boxes\nInvisible Gun\nLaser\nSilent Gun\n^2-->^5No Recoil");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                if (NoRecoil == false)
                {
                    byte[] godmodebyte = new byte[] { 0x60, 0x00, 0x00, 0x00 };
                    PS3.SetMemory(0x2290B0, godmodebyte);
                    NoRecoil = true;
                }
                else if (NoRecoil == true)
                {
                    byte[] godmodebyte = new byte[] { 0x4B, 0xF6, 0x03, 0xD5 };
                    PS3.SetMemory(0x2290B0, godmodebyte);
                    NoRecoil = false;
                }
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                H9.Stop();
                H1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                H9.Stop();
                H8.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                H9.Stop();
                HostMainMenu.Start();
            }
        }

        private void H10_Tick(object sender, EventArgs e)
        {
           
        }

        private void skyDarkButton3_Click(object sender, EventArgs e)
        {

        }

        private void PrestigeMenu_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Simple Mods\n^2-->^5Prestige Menu\nStats Menu\nName Changer\n\n\n\n^2www.ihax.fr\n^3Facebook : ^1Guillaume ^2MrNiato");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                PrestigeMenu.Stop();
                P1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                PrestigeMenu.Stop();
                StatsMenu.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                PrestigeMenu.Stop();
                HostMainMenu.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                PrestigeMenu.Stop();
                Sleep.Start();
            }
        }
        byte[] buffer311;
        private void P1_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^2-->^5Prestige 5\nPrestige 10\nPrestige 15\nPrestige 20\nPrestige 25\nPrestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 5;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P1.Stop();
                P2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P1.Stop();
                P7.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P1.Stop();
                HostMainMenu.Start();
            }
        }

        private void P2_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\n^2-->^5Prestige 10\nPrestige 15\nPrestige 20\nPrestige 25\nPrestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 10;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P2.Stop();
                P3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P2.Stop();
                P1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P2.Stop();
                HostMainMenu.Start();
            }
        }

        private void P3_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\nPrestige 10\n^2-->^5Prestige 15\nPrestige 20\nPrestige 25\nPrestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 15;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P3.Stop();
                P4.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P3.Stop();
                P2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P3.Stop();
                HostMainMenu.Start();
            }
        }

        private void P4_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\nPrestige 10\nPrestige 15\n^2-->^5Prestige 20\nPrestige 25\nPrestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 20;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P4.Stop();
                P5.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P4.Stop();
                P3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P4.Stop();
                HostMainMenu.Start();
            }
        }

        private void P5_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\nPrestige 10\nPrestige 15\nPrestige 20\n^2-->^5Prestige 25\nPrestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 25;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P5.Stop();
                P6.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P5.Stop();
                P4.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P5.Stop();
                HostMainMenu.Start();
            }
        }

        private void P6_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\nPrestige 10\nPrestige 15\nPrestige 20\nPrestige 25\n^2-->^5Prestige 30\nPrestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 30;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P6.Stop();
                P7.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P6.Stop();
                P5.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P6.Stop();
                HostMainMenu.Start();
            }
        }

        private void P7_Tick(object sender, EventArgs e)
        {
            byte[] buffer311;
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Prestige 5\nPrestige 10\nPrestige 15\nPrestige 20\nPrestige 25\nPrestige 30\n^2-->^5Prestige 31");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 31;
                buffer311 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0x0D, buffer311);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                P7.Stop();
                P1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                P7.Stop();
                P6.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                P7.Stop();
                HostMainMenu.Start();
            }
        }

        private void StatsMenu_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Simple Mods\nPrestige Menu\n^2-->^5Stats Menu\nName Changer\n\n\n\n^2www.ihax.fr\n^3Facebook : ^2Guillaume ^1MrNiato");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                StatsMenu.Stop();
                S1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                StatsMenu.Stop();
                NameChanger.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                StatsMenu.Stop();
                PrestigeMenu.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                HostMainMenu.Stop();
                Sleep.Start();
            }
        }

        private void S1_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^2-->^5Level 50\nLow Stats\nlegit Stats\nHigh Stats");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 1002100M;
                PS3.SetMemory(Stats_Entry + 0xa9, BitConverter.GetBytes((int)numericUpDown2.Value));
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                S1.Stop();
                S2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                S1.Stop();
                S4.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                S1.Stop();
                HostMainMenu.Start();
            }
        }

        private void S2_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Level 50\n^2-->^5Low Stats\nlegit Stats\nHigh Stats");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 30M;
                numericUpDown2.Value = 1002100M;
                numericUpDown3.Value = 6232M;
                numericUpDown4.Value = 2256M;
                numericUpDown5.Value = 600M;
                numericUpDown6.Value = 300M;
                numericUpDown7.Value = 900M;
                numericUpDown8.Value = 1654443M;
                numericUpDown9.Value = 5000000M;
                PS3.SetMemory(Stats_Entry + 0x9, BitConverter.GetBytes((int)numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0xa9, BitConverter.GetBytes((int)numericUpDown2.Value));
                PS3.SetMemory(Stats_Entry + 0xbd, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x95, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x112, BitConverter.GetBytes((int)numericUpDown4.Value));
                PS3.SetMemory(Stats_Entry + 0xc5, BitConverter.GetBytes((int)numericUpDown5.Value));
                PS3.SetMemory(Stats_Entry + 0xad, BitConverter.GetBytes((int)numericUpDown6.Value));
                PS3.SetMemory(Stats_Entry + 230, BitConverter.GetBytes((int)numericUpDown7.Value));
                PS3.SetMemory(Stats_Entry + 0x102, BitConverter.GetBytes((int)numericUpDown8.Value));
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                S2.Stop();
                S3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                S2.Stop();
                S1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                S2.Stop();
                HostMainMenu.Start();
            }
        }

        private void S3_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Level 50\nLow Stats\n^2-->^5legit Stats\nHigh Stats");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 30M;
                numericUpDown2.Value = 1002100M;
                numericUpDown3.Value = 15433M;
                numericUpDown4.Value = 5000M;
                numericUpDown5.Value = 1100M;
                numericUpDown6.Value = 500M;
                numericUpDown7.Value = 1600M;
                numericUpDown8.Value = 3654443M;
                numericUpDown9.Value = 8000000M;
                PS3.SetMemory(Stats_Entry + 0x9, BitConverter.GetBytes((int)numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0xa9, BitConverter.GetBytes((int)numericUpDown2.Value));
                PS3.SetMemory(Stats_Entry + 0xbd, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x95, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x112, BitConverter.GetBytes((int)numericUpDown4.Value));
                PS3.SetMemory(Stats_Entry + 0xc5, BitConverter.GetBytes((int)numericUpDown5.Value));
                PS3.SetMemory(Stats_Entry + 0xad, BitConverter.GetBytes((int)numericUpDown6.Value));
                PS3.SetMemory(Stats_Entry + 230, BitConverter.GetBytes((int)numericUpDown7.Value));
                PS3.SetMemory(Stats_Entry + 0x102, BitConverter.GetBytes((int)numericUpDown8.Value));
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                S3.Stop();
                S4.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                S3.Stop();
                S2.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                S3.Stop();
                HostMainMenu.Start();
            }
        }

        private void S4_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Level 50\nLow Stats\nlegit Stats\n^2-->^5High Stats");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                numericUpDown1.Value = 30M;
                numericUpDown2.Value = 1002100M;
                numericUpDown3.Value = 25433M;
                numericUpDown4.Value = 15433M;
                numericUpDown5.Value = 1654M;
                numericUpDown6.Value = 650M;
                numericUpDown7.Value = 2304M;
                numericUpDown8.Value = 5654443M;
                numericUpDown9.Value = 16000000M;
                PS3.SetMemory(Stats_Entry + 0x9, BitConverter.GetBytes((int)numericUpDown1.Value));
                PS3.SetMemory(Stats_Entry + 0xa9, BitConverter.GetBytes((int)numericUpDown2.Value));
                PS3.SetMemory(Stats_Entry + 0xbd, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x95, BitConverter.GetBytes((int)numericUpDown3.Value));
                PS3.SetMemory(Stats_Entry + 0x112, BitConverter.GetBytes((int)numericUpDown4.Value));
                PS3.SetMemory(Stats_Entry + 0xc5, BitConverter.GetBytes((int)numericUpDown5.Value));
                PS3.SetMemory(Stats_Entry + 0xad, BitConverter.GetBytes((int)numericUpDown6.Value));
                PS3.SetMemory(Stats_Entry + 230, BitConverter.GetBytes((int)numericUpDown7.Value));
                PS3.SetMemory(Stats_Entry + 0x102, BitConverter.GetBytes((int)numericUpDown8.Value));
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                S4.Stop();
                S1.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                S4.Stop();
                S3.Start();
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                S4.Stop();
                HostMainMenu.Start();
            }
        }

        private void NameChanger_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^5Simple Mods\nPrestige Menu\nStats Menu\n^2-->^5Name Changer\n\n\n\n^2www.ihax.fr\n^3Facebook : ^1Guillaume ^2MrNiato");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                NameChanger.Stop();
                N1.Start();
                groupBox4.Enabled = true;
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_DOWN))
            {
                NameChanger.Stop();
                HostMainMenu.Start();
                groupBox4.Enabled = false;
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.DPAD_UP))
            {
                NameChanger.Stop();
                StatsMenu.Start();
                groupBox4.Enabled = false;
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                NameChanger.Stop();
                Sleep.Start();
                groupBox4.Enabled = false;
            }
        }

        private void N1_Tick(object sender, EventArgs e)
        {
            WriteText("^1-- ^5N^7o ^5H^7ost ^5M^7od ^5M^7enu ^5B^7y ^5M^7rNiato  ^1--\n\n^2-->^5 Click X to Set The Name in the textBox in the software");
            if (Key_IsDown.DetectKey(Key_IsDown.Key.Cross))
            {
                PS3.Extension.WriteString(0x2A80BE8, textBox1.Text);
            }
            if (Key_IsDown.DetectKey(Key_IsDown.Key.R3))
            {
                N1.Stop();
                HostMainMenu.Start();
                groupBox4.Enabled = false;
            }
        }

        private void skyDarkCheck1_Click(object sender, EventArgs e)
        {
           
        }

        private void skyDarkButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anti ban in real time editing tool are bad, I recommand to use an anti ban EBOOT.BIN to be safe !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void skyDarkForm1_Click(object sender, EventArgs e)
        {

        }
    }
}
