//  Macro Key Binder
//  for the Arduino Macro Keyboard
//  By Robert Sandoval 2021
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;

namespace MacroKeyBoardBinder
{
    public partial class MainMacroKeyboard : Form
    {
        static SerialPort _serialPort;
        static List<String> rawCFG = new List<string>();
        static List<String> key_binds;
        static int config = 1;
        bool isConnected = false;
        bool debug_mode = false;

        public MainMacroKeyboard()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();            

            if(ports.Length == 0)
            {
                DisplayError("No COM ports available.", -1);
                port_refresh_btn.Visible = true;
            }

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);

            }

            if (ports.Length != 0)
            {
                if(ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }

            if(debug_btn.Enabled == false)
            {
                debug_btn.ForeColor = Color.White;
            }
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ColorTable());

            connect_MenuItem.Text += $" ({comboBox1.SelectedItem})";
            notifyIcon.Text += $" {Application.ProductVersion}";

            // DEBUG ONLY
            //debugToolStripMenuItem.Visible = true;
        }

        // Tool Bar Color Scheme
        public class ColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuBorder
            {
                get
                {
                    return Color.White;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return Color.White;
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuStripGradientBegin
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuStripGradientEnd
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.FromArgb(45, 45, 48);
                }
            }
        }

        private void UpdateConfig()
        {
            switch (config)
            {
                case 1:
                    cmb_box_config.SelectedIndex = 0;
                    break;
                case 2:
                    cmb_box_config.SelectedIndex = 1;
                    break;
                case 3:
                    cmb_box_config.SelectedIndex = 2;
                    break;
            }
        }

        private void DataReceivedHandler(Object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            
            // Look for binding data to parse
            String[] data = indata.Split('\n');
            if(data.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    //Console.WriteLine($"{i}: {data[i].Trim()}");
                    if (data[i].StartsWith("<"))
                    {
                        rawCFG.Add(data[i]);
                    } else if(data[i].Contains("#"))
                    {
                        rawCFG.Add(data[i]);
                    } else if(data[i].EndsWith(">"))
                    {
                        rawCFG.Add(data[i]);
                    }
                }
                parseBinds();
            }

            // Look for Config number
            if(indata.Contains("C:"))
            {
                if(!(indata.StartsWith("C:")))
                {
                    indata = indata.Substring(indata.IndexOf("C:"));
                    
                }
                if (indata.Contains(" ") || indata.Contains("\n"))
                {
                    indata = indata.Split()[0];
                }

                if(indata[2].Equals('0'))
                {
                    config = 1;
                } else if (indata[2].Equals('1'))
                {
                    config = 2;
                } else if (indata[2].Equals('2'))
                {
                    config = 3;
                } else
                {
                    Console.WriteLine("Unable to determine config");
                }
            }

            Console.WriteLine($"Serial Data: {indata}");
        }

        // Parses the current bindings into a list
        private static void parseBinds()
        {
            if (rawCFG.Count > 0)
            {
                String cmd = "";
                String rawCMD = "";
                //Console.WriteLine($"RAW: {String.Join("", rawCFG)}");
                //Console.WriteLine("RAW:");
                /*rawCFG.ForEach(i =>
                {
                    Console.WriteLine(i);
                });*/

                //Console.WriteLine($"RAW: {String.Join("", rawCFG)}");
                rawCMD = String.Join("", rawCFG);

                if (rawCMD.Contains("<") && rawCMD.Contains(">"))
                {
                    // Remove previous bind and add new bind
                    rawCMD = rawCMD.Substring(rawCMD.IndexOf("<"), rawCMD.IndexOf(">") - rawCMD.IndexOf("<"));                    
                    // Remove beginning and end command 
                    rawCMD = rawCMD.Replace("<", String.Empty);
                    rawCMD = rawCMD.Replace(">", String.Empty);

                    key_binds = rawCMD.Split(',').ToList<String>();
                    rawCFG.Clear();
                }                
            }
        }

        private void SerialConnect()
        {
            try
            {
                string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);                
                if(selectedPort == "")
                {
                    throw new Exception("No port selected.");
                }
                isConnected = true;
                _serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                _serialPort.Handshake = Handshake.None;
                _serialPort.RtsEnable = true;
                _serialPort.DtrEnable = true;
                _serialPort.ReadTimeout = 5000;
                _serialPort.WriteTimeout = 500;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                _serialPort.Open();
                _serialPort.WriteLine("#bcfg>");
                enableButtons();
                connect_MenuItem.Visible = false;
                config_ToolMenuItem.Visible = true;
                disconnect_MenuItem.Visible = true;

                // Update Serial Connect Button
                btn_connect.Text = "Disconnect";
                btn_connect.BackColor = Color.FromArgb(250, 100, 100);
                debug_btn.Enabled = true;
                comboBox1.Enabled = false;

                UpdateConfig();
            } catch(Exception e)
            {
                MessageBox.Show("Unable to connect to the COM port. Please check your connection.", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
                comboBox1.Items.Clear();            
                port_refresh_btn.Visible = true;
                refresh_com_ports();
            }
        }

        private void SerialDisconnect()
        {
            int close_delay = 1;
            isConnected = false;
            _serialPort.Close();
            _serialPort.Dispose();
            disableButtons();
            connect_MenuItem.Visible = true;
            config_ToolMenuItem.Visible = false;
            disconnect_MenuItem.Visible = false;
            btn_connect.Enabled = false;
            DisplayError("Closing Connection...", close_delay);
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = close_delay * 1000;
            timer.Tick += (s, e) =>
            {
                // Update Serial Connect Button
                btn_connect.Enabled = true;
                btn_connect.Text = "Connect";
                btn_connect.BackColor = Color.FromArgb(80, 180, 120);
                debug_btn.Enabled = false;
                comboBox1.Enabled = true;
                timer.Stop();
            };
            timer.Start();


        }

        private void CheckBindAvailability()
        {
            if(key_binds == null)
            {
                DisplayError("No binds available, please try again.", 4);
                SerialDisconnect();
            }
        }

        private void DisplayError(String message, int time)
        {
            error_label.Text = message;
            error_label.Show();
            if(time != -1)
            {
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = time * 1000;
                timer.Tick += (s, e) =>
                {
                    if (error_label.Visible)
                    {
                        error_label.Hide();
                    }
                    timer.Stop();
                };
                timer.Start();
            }
        }

        private String ReadBind(string bind)
        {
            String command = key_binds != null ? bind.Substring(1) : "";
            String read_bind = "";

            if(command.Equals("mprev"))
            {
                read_bind = "Media Previous";
                return read_bind;
            } else if(command.Equals("mplaypause"))
            {
                read_bind = "Media Play/Pause";
                return read_bind;
            } else if(command.Equals("mnext"))
            {
                read_bind = "Media Next";
                return read_bind;
            }

            for(int i = 0; i < command.Length; i++)
            {
                if(command[i].ToString().Equals("^"))
                {
                    read_bind += "CTRL ";
                    continue;
                }

                if(command[i].ToString().Equals("!"))
                {
                    read_bind += "ALT ";
                    continue;
                }

                if(command[i].ToString().Equals("+"))
                {
                    read_bind += "SHIFT ";
                    continue;
                }

                read_bind += command[i];
            }
            return read_bind;
        }

        private void enableButtons()
        {
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            cmb_box_config.Enabled = true;
        }

        private void disableButtons()
        {
            btn_1.Enabled = false;
            btn_2.Enabled = false;
            btn_3.Enabled = false;
            btn_4.Enabled = false;
            btn_5.Enabled = false;
            btn_6.Enabled = false;
            cmb_box_config.Enabled = false;
        }

        // ------- BUTTONS ------------
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                SerialDisconnect();
            }
            else if (!(isConnected))
            {
                SerialConnect();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_about f2 = new form_about();
            f2.ShowDialog();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(0, _serialPort, config, ReadBind(key_binds[0]));
                form.Text = "Button 1";                
                form.ShowDialog();
            }
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(1, _serialPort, config, ReadBind(key_binds[1]));
                form.Text = "Button 2";
                form.ShowDialog();
            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(2, _serialPort, config, ReadBind(key_binds[2]));
                form.Text = "Button 3";
                form.ShowDialog();
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(3, _serialPort, config, ReadBind(key_binds[3]));
                form.Text = "Button 4";
                form.ShowDialog();
            }
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(4, _serialPort, config, ReadBind(key_binds[4]));
                form.Text = "Button 5";
                form.ShowDialog();
            }
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                CheckBindAvailability();
                BindingForm form = new BindingForm(5, _serialPort, config, ReadBind(key_binds[5]));
                form.Text = "Button 6";
                form.ShowDialog();
            }
        }

        // Change Config
        private void cmb_box_config_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isConnected)
            {
                String cmb_config = cmb_box_config.SelectedItem.ToString();
                if(cmb_config.Equals("1"))
                {
                    _serialPort.Write("#cfg1>");
                    config = 1;
                    _serialPort.Write("#gcfg>");
                    config1_MenuItem.Checked = true;
                    config2_MenuItem.Checked = false;
                    config3_MenuItem.Checked = false;
                } else if(cmb_config.Equals("2"))
                {
                    _serialPort.Write("#cfg2>");
                    config = 2;
                    _serialPort.Write("#gcfg>");
                    config1_MenuItem.Checked = false;
                    config2_MenuItem.Checked = true;
                    config3_MenuItem.Checked = false;
                } else if(cmb_config.Equals("3"))
                {
                    _serialPort.Write("#cfg3>");
                    config = 3;
                    _serialPort.Write("#gcfg>");
                    config1_MenuItem.Checked = false;
                    config2_MenuItem.Checked = false;
                    config3_MenuItem.Checked = true;
                } else
                {
                    _serialPort.Write("#cfg1>");
                    config = 1;
                    _serialPort.Write("#gcfg>");
                    config1_MenuItem.Checked = true;
                    config2_MenuItem.Checked = false;
                    config3_MenuItem.Checked = false;
                }
            }
        }

        private void debug_btn_click(object sender, EventArgs e)
        {
            Console.WriteLine("---- BINDS ----");
            if(key_binds != null)
            {
                key_binds.ForEach(Console.WriteLine);
            }            
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(debug_mode)
            {
                debug_mode = false;
                debug_btn.Visible = false;
            } else
            {
                debug_mode = true;
                debug_btn.Visible = true;
            }
        }

        private void port_refresh_btn_Click(object sender, EventArgs e)
        {
            refresh_com_ports();
        }

        private void refresh_com_ports()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);

            }

            if (ports.Length > 0)
            {
                port_refresh_btn.Visible = false;
                error_label.Text = "";
                error_label.Visible = false;
                comboBox1.SelectedIndex = 0;
            } else
            {
                comboBox1.SelectedIndex = -1;
            }
        }

        // Notify Icon
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form_about f2 = new form_about();
            f2.ShowDialog();
        }

        private void config1_MenuItem_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                cmb_box_config.Text = "1";
            }
        }

        private void config2_MenuItem_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                cmb_box_config.Text = "2";
            }
        }

        private void config3_MenuItem_Click(object sender, EventArgs e)
        {
            cmb_box_config.Text = "3";
        }

        private void connect_MenuItem_Click(object sender, EventArgs e)
        {
            if (!(isConnected))
            {
                SerialConnect();
            }
        }

        private void disconnect_MenuItem_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                SerialDisconnect();
            }
        }

        private void notifyIcon_DoubleClick(object Sender,EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Activate();
            }          
        }

    }
}
