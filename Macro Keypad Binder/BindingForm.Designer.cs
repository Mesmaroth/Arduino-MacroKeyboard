
namespace MacroKeypadBinder
{
    partial class BindingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.test_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_mnext = new System.Windows.Forms.CheckBox();
            this.check_mplay = new System.Windows.Forms.CheckBox();
            this.check_mprev = new System.Windows.Forms.CheckBox();
            this.check_func = new System.Windows.Forms.CheckBox();
            this.check_shift = new System.Windows.Forms.CheckBox();
            this.check_alt = new System.Windows.Forms.CheckBox();
            this.check_ctrl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.list_keys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.current_bind_label = new System.Windows.Forms.Label();
            this.new_bind_label = new System.Windows.Forms.Label();
            this.bind_btn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bind_status_label = new System.Windows.Forms.Label();
            this.config_title_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // test_btn
            // 
            this.test_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.test_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_btn.Location = new System.Drawing.Point(154, 273);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(110, 46);
            this.test_btn.TabIndex = 0;
            this.test_btn.Text = "TEST";
            this.test_btn.UseVisualStyleBackColor = false;
            this.test_btn.Click += new System.EventHandler(this.Test_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.Controls.Add(this.check_mnext);
            this.groupBox1.Controls.Add(this.check_mplay);
            this.groupBox1.Controls.Add(this.check_mprev);
            this.groupBox1.Controls.Add(this.check_func);
            this.groupBox1.Controls.Add(this.check_shift);
            this.groupBox1.Controls.Add(this.check_alt);
            this.groupBox1.Controls.Add(this.check_ctrl);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Snow;
            this.groupBox1.Location = new System.Drawing.Point(282, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 189);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Binds";
            // 
            // check_mnext
            // 
            this.check_mnext.AutoSize = true;
            this.check_mnext.Location = new System.Drawing.Point(6, 165);
            this.check_mnext.Name = "check_mnext";
            this.check_mnext.Size = new System.Drawing.Size(80, 17);
            this.check_mnext.TabIndex = 6;
            this.check_mnext.Text = "Media Next";
            this.check_mnext.UseVisualStyleBackColor = true;
            this.check_mnext.CheckedChanged += new System.EventHandler(this.check_mnxt_CheckedChanged);
            // 
            // check_mplay
            // 
            this.check_mplay.AutoSize = true;
            this.check_mplay.Location = new System.Drawing.Point(5, 139);
            this.check_mplay.Name = "check_mplay";
            this.check_mplay.Size = new System.Drawing.Size(113, 17);
            this.check_mplay.TabIndex = 5;
            this.check_mplay.Text = "Media Play/Pause";
            this.check_mplay.UseVisualStyleBackColor = true;
            this.check_mplay.CheckedChanged += new System.EventHandler(this.check_mplay_CheckedChanged);
            // 
            // check_mprev
            // 
            this.check_mprev.AutoSize = true;
            this.check_mprev.Location = new System.Drawing.Point(6, 115);
            this.check_mprev.Name = "check_mprev";
            this.check_mprev.Size = new System.Drawing.Size(99, 17);
            this.check_mprev.TabIndex = 4;
            this.check_mprev.Text = "Media Previous";
            this.check_mprev.UseVisualStyleBackColor = true;
            this.check_mprev.CheckedChanged += new System.EventHandler(this.check_mprev_CheckedChanged);
            // 
            // check_func
            // 
            this.check_func.AutoSize = true;
            this.check_func.Location = new System.Drawing.Point(7, 92);
            this.check_func.Name = "check_func";
            this.check_func.Size = new System.Drawing.Size(55, 17);
            this.check_func.TabIndex = 3;
            this.check_func.Text = "FUNC";
            this.check_func.UseVisualStyleBackColor = true;
            this.check_func.CheckedChanged += new System.EventHandler(this.Check_Func_CheckedChanged);
            // 
            // check_shift
            // 
            this.check_shift.AutoSize = true;
            this.check_shift.Location = new System.Drawing.Point(7, 68);
            this.check_shift.Name = "check_shift";
            this.check_shift.Size = new System.Drawing.Size(57, 17);
            this.check_shift.TabIndex = 2;
            this.check_shift.Text = "SHIFT";
            this.check_shift.UseVisualStyleBackColor = true;
            this.check_shift.CheckedChanged += new System.EventHandler(this.check_shift_CheckedChanged);
            // 
            // check_alt
            // 
            this.check_alt.AutoSize = true;
            this.check_alt.Location = new System.Drawing.Point(7, 44);
            this.check_alt.Name = "check_alt";
            this.check_alt.Size = new System.Drawing.Size(46, 17);
            this.check_alt.TabIndex = 1;
            this.check_alt.Text = "ALT";
            this.check_alt.UseVisualStyleBackColor = true;
            this.check_alt.CheckedChanged += new System.EventHandler(this.check_alt_CheckedChanged);
            // 
            // check_ctrl
            // 
            this.check_ctrl.AutoSize = true;
            this.check_ctrl.Location = new System.Drawing.Point(7, 20);
            this.check_ctrl.Name = "check_ctrl";
            this.check_ctrl.Size = new System.Drawing.Size(54, 17);
            this.check_ctrl.TabIndex = 0;
            this.check_ctrl.Text = "CTRL";
            this.check_ctrl.UseVisualStyleBackColor = true;
            this.check_ctrl.CheckedChanged += new System.EventHandler(this.check_ctrl_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.list_keys);
            this.groupBox2.ForeColor = System.Drawing.Color.Snow;
            this.groupBox2.Location = new System.Drawing.Point(282, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 115);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keys";
            // 
            // list_keys
            // 
            this.list_keys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.list_keys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_keys.ForeColor = System.Drawing.Color.White;
            this.list_keys.FormattingEnabled = true;
            this.list_keys.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.list_keys.Location = new System.Drawing.Point(7, 19);
            this.list_keys.Name = "list_keys";
            this.list_keys.Size = new System.Drawing.Size(125, 93);
            this.list_keys.TabIndex = 5;
            this.list_keys.SelectedIndexChanged += new System.EventHandler(this.list_keys_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Bind: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "New Bind: ";
            // 
            // current_bind_label
            // 
            this.current_bind_label.AutoSize = true;
            this.current_bind_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_bind_label.Location = new System.Drawing.Point(121, 56);
            this.current_bind_label.Name = "current_bind_label";
            this.current_bind_label.Size = new System.Drawing.Size(98, 20);
            this.current_bind_label.TabIndex = 8;
            this.current_bind_label.Text = "current_bind";
            // 
            // new_bind_label
            // 
            this.new_bind_label.AutoSize = true;
            this.new_bind_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_bind_label.Location = new System.Drawing.Point(102, 112);
            this.new_bind_label.Name = "new_bind_label";
            this.new_bind_label.Size = new System.Drawing.Size(77, 20);
            this.new_bind_label.TabIndex = 9;
            this.new_bind_label.Text = "new_bind";
            // 
            // bind_btn
            // 
            this.bind_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.bind_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bind_btn.Location = new System.Drawing.Point(16, 273);
            this.bind_btn.Name = "bind_btn";
            this.bind_btn.Size = new System.Drawing.Size(110, 46);
            this.bind_btn.TabIndex = 10;
            this.bind_btn.Text = "BIND";
            this.bind_btn.UseVisualStyleBackColor = false;
            this.bind_btn.Click += new System.EventHandler(this.bind_btn_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Test Tip Text";
            this.notifyIcon1.BalloonTipTitle = "Test Tip Title";
            this.notifyIcon1.Text = "Notify Text";
            this.notifyIcon1.Visible = true;
            // 
            // bind_status_label
            // 
            this.bind_status_label.AutoSize = true;
            this.bind_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bind_status_label.ForeColor = System.Drawing.Color.Lime;
            this.bind_status_label.Location = new System.Drawing.Point(60, 184);
            this.bind_status_label.Name = "bind_status_label";
            this.bind_status_label.Size = new System.Drawing.Size(177, 17);
            this.bind_status_label.TabIndex = 12;
            this.bind_status_label.Text = "Key Binded Successful!";
            this.bind_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bind_status_label.Visible = false;
            // 
            // config_title_label
            // 
            this.config_title_label.AutoSize = true;
            this.config_title_label.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_title_label.ForeColor = System.Drawing.Color.White;
            this.config_title_label.Location = new System.Drawing.Point(83, 9);
            this.config_title_label.Name = "config_title_label";
            this.config_title_label.Size = new System.Drawing.Size(111, 23);
            this.config_title_label.TabIndex = 13;
            this.config_title_label.Text = " Button 0";
            this.config_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BindingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(425, 334);
            this.Controls.Add(this.config_title_label);
            this.Controls.Add(this.bind_status_label);
            this.Controls.Add(this.bind_btn);
            this.Controls.Add(this.new_bind_label);
            this.Controls.Add(this.current_bind_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.test_btn);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bind_form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnApplicationClose);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox check_func;
        private System.Windows.Forms.CheckBox check_shift;
        private System.Windows.Forms.CheckBox check_alt;
        private System.Windows.Forms.CheckBox check_ctrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox list_keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label current_bind_label;
        private System.Windows.Forms.Label new_bind_label;
        private System.Windows.Forms.Button bind_btn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label bind_status_label;
        private System.Windows.Forms.Label config_title_label;
        private System.Windows.Forms.CheckBox check_mnext;
        private System.Windows.Forms.CheckBox check_mplay;
        private System.Windows.Forms.CheckBox check_mprev;
    }
}