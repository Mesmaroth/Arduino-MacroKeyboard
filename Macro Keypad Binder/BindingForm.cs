//  Custom Macro Keypad Binder
//  By Robert Sandoval 2021
//
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
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class BindingForm : Form
    {
        SerialPort Serial;
        int CurrentButtonCfg;
        String[] keys;
        // The main key to which other keys are grouped together with.
        String BindKey = "";
        int current_config;

        public BindingForm(int button_cfg, SerialPort serial, int config, String currentBind)
        {
            InitializeComponent();
            Serial = serial;
            CurrentButtonCfg = button_cfg;
            current_config = config;
            config_title_label.Text = $"Button {CurrentButtonCfg + 1}";
            keys = list_keys.Items.Cast<String>().ToArray();
            current_bind_label.Text = currentBind;
            new_bind_label.Text = "";            
        }

        private void Test_Button_Click(object sender, EventArgs e)
        {
            TestBindMessage();
            switch(CurrentButtonCfg)
            {
                case 0:
                    Serial.Write("#bton>\n");
                    break;
                case 1:
                    Serial.Write("#bttw>\n");
                    break;
                case 2:
                    Serial.Write("#bttr>\n");
                    break;
                case 3:
                    Serial.Write("#btfr>\n");
                    break;
                case 4:
                    Serial.Write("#btfv>\n");
                    break;
                case 5:
                    Serial.Write("#btsx>\n");
                    break;
            }
        }

        private void uncheck_media_keys()
        {
            if (check_mprev.Checked)
            {
                check_mprev.Checked = false;
            }

            if(check_mplay.Checked)
            {
                check_mplay.Checked = false;
            }
            
            if(check_mnext.Checked)
            {
                check_mnext.Checked = false;
            }
        }

        private void check_ctrl_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ctrl.Checked)
            {
                uncheck_media_keys();
                new_bind_label.Text += "CTRL ";
            } else
            {
                if(new_bind_label.Text.Contains("CTRL "))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("CTRL ", "");
                }
            }
        }

        private void check_alt_CheckedChanged(object sender, EventArgs e)
        {
            if (check_alt.Checked)
            {
                uncheck_media_keys();
                new_bind_label.Text += "ALT ";
            } else
            {
                if (new_bind_label.Text.Contains("ALT "))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("ALT ", "");
                }
            }
        }

        private void check_shift_CheckedChanged(object sender, EventArgs e)
        {
            if (check_shift.Checked)
            {
                uncheck_media_keys();
                new_bind_label.Text += "SHIFT ";
            }
            else
            {
                if (new_bind_label.Text.Contains("SHIFT "))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("SHIFT ", "");
                }
            }
        }

        private void Check_Func_CheckedChanged(object sender, EventArgs e)
        {
            if (check_func.Checked)
            {
                uncheck_media_keys();
                list_keys.Items.Clear();
                for(int i = 1; i < 13; i++)
                {
                    list_keys.Items.Add($"F{i}");
                }
            } else
            {
                list_keys.Items.Clear();
                for (int i = 0; i < keys.Length; i ++)
                {
                    list_keys.Items.Add(keys[i]);
                }
            }
        }

        private void check_mprev_CheckedChanged(object sender, EventArgs e)
        {
            if (check_mprev.Checked)
            {
                check_ctrl.Checked = false;
                check_alt.Checked = false;
                check_shift.Checked = false;
                check_func.Checked = false;
                check_mplay.Checked = false;
                check_mnext.Checked = false;

                if (list_keys.Enabled)
                {
                    list_keys.Enabled = false;
                }

                new_bind_label.Text = "Media Previous ";
            } else
            {
                if (list_keys.Enabled == false)
                {
                    list_keys.Enabled = true;
                }
                if (new_bind_label.Text.Contains("Media Previous"))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("Media Previous ", "");
                }
            }
        }

        private void check_mplay_CheckedChanged(object sender, EventArgs e)
        {
            if(check_mplay.Checked)
            {
                check_ctrl.Checked = false;
                check_alt.Checked = false;
                check_shift.Checked = false;
                check_func.Checked = false;
                check_mprev.Checked = false;
                check_mnext.Checked = false;

                if(list_keys.Enabled)
                {
                    list_keys.Enabled = false;
                }

                new_bind_label.Text = "Media Play/Pause ";
            } else
            {
                if (list_keys.Enabled == false)
                {
                    list_keys.Enabled = true;
                }
                if (new_bind_label.Text.Contains("Media Play/Pause"))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("Media Play/Pause ", "");
                }
            }
        }

        private void check_mnxt_CheckedChanged(object sender, EventArgs e)
        {
            if(check_mnext.Checked)
            {
                check_ctrl.Checked = false;
                check_alt.Checked = false;
                check_shift.Checked = false;
                check_func.Checked = false;
                check_mprev.Checked = false;
                check_mplay.Checked = false;

                if (list_keys.Enabled)
                {
                    list_keys.Enabled = false;
                }

                new_bind_label.Text = "Media Next ";
            } else
            {
                if (list_keys.Enabled == false)
                {
                    list_keys.Enabled = true;
                }
                if (new_bind_label.Text.Contains("Media Next"))
                {
                    new_bind_label.Text = new_bind_label.Text.Replace("Media Next ", "");
                }
            }
        }

        private void bind_btn_Click(object sender, EventArgs e)
        {
            if(!check_mprev.Checked && !check_mplay.Checked && !check_mnext.Checked && list_keys.SelectedItem == null)
            {
                MessageBox.Show("You have not selected a key to bind too.", "Error Key Bind",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WriteBind(new_bind_label.Text);          
        }

        private void BindSuccessMessage()
        {
            bind_status_label.Text = "Key Binded Successful!";
            bind_status_label.ForeColor = Color.Lime;
            bind_status_label.Show();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                if(bind_status_label.Visible)
                {
                    bind_status_label.Hide();
                }
                timer.Stop();
            };
            timer.Start();
        }

        private void TestBindMessage()
        {
            bind_status_label.Text = $"Testing Button {CurrentButtonCfg + 1}.";
            bind_status_label.ForeColor = Color.Orange;

            if (!bind_status_label.Visible)
            {
                bind_status_label.Show();
            }

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2500;
            timer.Tick += (s, e) =>
            {
                if(bind_status_label.Visible)
                {
                    bind_status_label.Hide();
                }
                timer.Stop();
            };
            timer.Start();        
        }

        private void WriteBind(String bind)
        {
            String[] buttons;
            String parsed_bind = "";
            Console.WriteLine($"Writing new bind: {bind} to Button {CurrentButtonCfg + 1}");
            buttons = bind.Split(' ');

            Serial.Write($"#rbd{CurrentButtonCfg + 1}>\n");

            if(bind.Contains("Media"))
            {
                if(bind.Contains("Media Previous"))
                {
                    parsed_bind = "mprev";
                } else if(bind.Contains("Media Play/Pause")) 
                {
                    parsed_bind = "mplaypause";
                } else if(bind.Contains("Media Next"))
                {
                    parsed_bind = "mnext";
                }
            } else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].Equals("CTRL"))
                    {
                        parsed_bind += "^";
                        continue;
                    }

                    if (buttons[i].Equals("ALT"))
                    {
                        parsed_bind += "!";
                        continue;
                    }

                    if (buttons[i].Equals("SHIFT"))
                    {
                        parsed_bind += "+";
                        continue;
                    }

                    parsed_bind += buttons[i];
                }
            }

            Console.WriteLine($"#{parsed_bind}");
            bind_status_label.Text = "BINDING KEYS...";
            bind_status_label.ForeColor = Color.Orange;
            bind_status_label.Show();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 600;
            timer.Tick += (s, e) =>
            {
                Serial.Write($"#{parsed_bind}\n");
                BindSuccessMessage();
                current_bind_label.Text = new_bind_label.Text;
                new_bind_label.Text = "";
                timer.Stop();
            };
            timer.Start();
            
        }

        private void list_keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(new_bind_label.Text.Length > 0)
            {
                if(BindKey.Length > 0)
                {
                    new_bind_label.Text = new_bind_label.Text.Replace($"{BindKey} ", $"{list_keys.SelectedItem} ");
                } else
                {
                    new_bind_label.Text += $"{list_keys.SelectedItem} ";
                }
                BindKey = list_keys.SelectedItem.ToString();
            } else
            {
                new_bind_label.Text += $"{list_keys.SelectedItem} ";
                BindKey = list_keys.SelectedItem.ToString();
            }
        }

        private void OnApplicationClose(object sender, FormClosedEventArgs e)
        {
            Serial.Write("#gcfg>\n");
        }

    }
}
