namespace WinTouchUp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ProgramId = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            DarkThemeEnable = new RadioButton();
            LightThemeEnable = new RadioButton();
            ThemeSettingsBox = new GroupBox();
            label12 = new Label();
            AppContainer = new TabControl();
            GeneralTab = new TabPage();
            ToggleSettingsBox = new GroupBox();
            label13 = new Label();
            BorderColorToggle = new CheckBox();
            ColorPrevalenceToggle = new CheckBox();
            TransparencyEffectToggle = new CheckBox();
            ColorsTab = new TabPage();
            AdvancedControlsBox = new GroupBox();
            label14 = new Label();
            InactiveHexCode = new Label();
            InactivePick = new Button();
            label9 = new Label();
            label1 = new Label();
            TaskbarBackPick = new Button();
            AccentHexCode = new Label();
            TaskbarFrontPick = new Button();
            label3 = new Label();
            StartPick = new Button();
            label4 = new Label();
            SettingsIconPick = new Button();
            label5 = new Label();
            TitlebarPick = new Button();
            label6 = new Label();
            HoverPick = new Button();
            label7 = new Label();
            AccentPick = new Button();
            label8 = new Label();
            TaskbarBackHexCode = new Label();
            HoverHexCode = new Label();
            TaskbarFrontHexCode = new Label();
            TitlebarHexCode = new Label();
            StartHexCode = new Label();
            SettingsIconHexCode = new Label();
            AdvancedViewButton = new Button();
            ThemeColorPick = new Button();
            CloseControl = new Button();
            MinimizeControl = new Button();
            panel1 = new Panel();
            LinkIssueGithub = new LinkLabel();
            label11 = new Label();
            ReloadButton = new Button();
            label10 = new Label();
            AboutButton = new PictureBox();
            ProgramId.SuspendLayout();
            ThemeSettingsBox.SuspendLayout();
            AppContainer.SuspendLayout();
            GeneralTab.SuspendLayout();
            ToggleSettingsBox.SuspendLayout();
            ColorsTab.SuspendLayout();
            AdvancedControlsBox.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AboutButton).BeginInit();
            SuspendLayout();
            // 
            // ProgramId
            // 
            ProgramId.BackColor = Color.FromArgb(64, 64, 64);
            ProgramId.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProgramId.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            ProgramId.Location = new Point(0, 319);
            ProgramId.Name = "ProgramId";
            ProgramId.Size = new Size(291, 22);
            ProgramId.SizingGrip = false;
            ProgramId.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Transparent;
            toolStripStatusLabel1.ForeColor = Color.White;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(137, 17);
            toolStripStatusLabel1.Text = "© (MIT) 2026 sprow-dev";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.BackColor = Color.Transparent;
            toolStripStatusLabel2.ForeColor = Color.White;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Padding = new Padding(0, 0, 15, 0);
            toolStripStatusLabel2.Size = new Size(124, 17);
            toolStripStatusLabel2.Text = "v0.0r Build 260713";
            // 
            // DarkThemeEnable
            // 
            DarkThemeEnable.AutoSize = true;
            DarkThemeEnable.Location = new Point(6, 47);
            DarkThemeEnable.Name = "DarkThemeEnable";
            DarkThemeEnable.Size = new Size(51, 19);
            DarkThemeEnable.TabIndex = 2;
            DarkThemeEnable.TabStop = true;
            DarkThemeEnable.Text = "Dark";
            DarkThemeEnable.UseVisualStyleBackColor = true;
            DarkThemeEnable.CheckedChanged += DarkThemeEnable_CheckedChanged;
            // 
            // LightThemeEnable
            // 
            LightThemeEnable.AutoSize = true;
            LightThemeEnable.Location = new Point(6, 22);
            LightThemeEnable.Name = "LightThemeEnable";
            LightThemeEnable.Size = new Size(52, 19);
            LightThemeEnable.TabIndex = 1;
            LightThemeEnable.TabStop = true;
            LightThemeEnable.Text = "Light";
            LightThemeEnable.UseVisualStyleBackColor = true;
            LightThemeEnable.CheckedChanged += LightThemeEnable_CheckedChanged;
            // 
            // ThemeSettingsBox
            // 
            ThemeSettingsBox.Controls.Add(label12);
            ThemeSettingsBox.Controls.Add(DarkThemeEnable);
            ThemeSettingsBox.Controls.Add(LightThemeEnable);
            ThemeSettingsBox.Location = new Point(6, 6);
            ThemeSettingsBox.Name = "ThemeSettingsBox";
            ThemeSettingsBox.Size = new Size(265, 75);
            ThemeSettingsBox.TabIndex = 3;
            ThemeSettingsBox.TabStop = false;
            ThemeSettingsBox.Text = "Theme";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 0);
            label12.Name = "label12";
            label12.Size = new Size(46, 15);
            label12.TabIndex = 3;
            label12.Text = "Theme";
            // 
            // AppContainer
            // 
            AppContainer.Controls.Add(GeneralTab);
            AppContainer.Controls.Add(ColorsTab);
            AppContainer.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AppContainer.Location = new Point(-2, 0);
            AppContainer.Name = "AppContainer";
            AppContainer.SelectedIndex = 0;
            AppContainer.Size = new Size(295, 284);
            AppContainer.TabIndex = 4;
            AppContainer.SelectedIndexChanged += AppContainer_SelectedIndexChanged;
            AppContainer.MouseDown += App_DragTitleBar;
            // 
            // GeneralTab
            // 
            GeneralTab.BackColor = Color.Black;
            GeneralTab.Controls.Add(ToggleSettingsBox);
            GeneralTab.Controls.Add(ThemeSettingsBox);
            GeneralTab.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GeneralTab.ForeColor = Color.White;
            GeneralTab.Location = new Point(4, 24);
            GeneralTab.Name = "GeneralTab";
            GeneralTab.Padding = new Padding(3);
            GeneralTab.Size = new Size(287, 256);
            GeneralTab.TabIndex = 0;
            GeneralTab.Text = "General";
            // 
            // ToggleSettingsBox
            // 
            ToggleSettingsBox.Controls.Add(label13);
            ToggleSettingsBox.Controls.Add(BorderColorToggle);
            ToggleSettingsBox.Controls.Add(ColorPrevalenceToggle);
            ToggleSettingsBox.Controls.Add(TransparencyEffectToggle);
            ToggleSettingsBox.Location = new Point(6, 87);
            ToggleSettingsBox.Name = "ToggleSettingsBox";
            ToggleSettingsBox.Size = new Size(265, 94);
            ToggleSettingsBox.TabIndex = 4;
            ToggleSettingsBox.TabStop = false;
            ToggleSettingsBox.Text = "Advanced Toggles";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 0);
            label13.Name = "label13";
            label13.Size = new Size(107, 15);
            label13.TabIndex = 4;
            label13.Text = "Advanced Toggles";
            // 
            // BorderColorToggle
            // 
            BorderColorToggle.AutoSize = true;
            BorderColorToggle.Location = new Point(4, 43);
            BorderColorToggle.Name = "BorderColorToggle";
            BorderColorToggle.Size = new Size(218, 19);
            BorderColorToggle.TabIndex = 2;
            BorderColorToggle.Text = "Enable Colors On Window Borders";
            BorderColorToggle.UseVisualStyleBackColor = true;
            BorderColorToggle.CheckedChanged += BorderColorToggle_CheckedChanged;
            // 
            // ColorPrevalenceToggle
            // 
            ColorPrevalenceToggle.AutoSize = true;
            ColorPrevalenceToggle.Location = new Point(4, 18);
            ColorPrevalenceToggle.Name = "ColorPrevalenceToggle";
            ColorPrevalenceToggle.Size = new Size(256, 19);
            ColorPrevalenceToggle.TabIndex = 1;
            ColorPrevalenceToggle.Text = "Enable Colors On Taskbar and Start Menu";
            ColorPrevalenceToggle.UseVisualStyleBackColor = true;
            ColorPrevalenceToggle.CheckedChanged += ColorPrevalenceToggle_CheckedChanged;
            // 
            // TransparencyEffectToggle
            // 
            TransparencyEffectToggle.AutoSize = true;
            TransparencyEffectToggle.Location = new Point(4, 68);
            TransparencyEffectToggle.Name = "TransparencyEffectToggle";
            TransparencyEffectToggle.Size = new Size(183, 19);
            TransparencyEffectToggle.TabIndex = 0;
            TransparencyEffectToggle.Text = "Enable Transparency Effects";
            TransparencyEffectToggle.UseVisualStyleBackColor = true;
            TransparencyEffectToggle.CheckedChanged += TransparencyEffectToggle_CheckedChanged;
            // 
            // ColorsTab
            // 
            ColorsTab.BackColor = Color.Black;
            ColorsTab.Controls.Add(AdvancedControlsBox);
            ColorsTab.Controls.Add(AdvancedViewButton);
            ColorsTab.Controls.Add(ThemeColorPick);
            ColorsTab.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ColorsTab.ForeColor = Color.White;
            ColorsTab.Location = new Point(4, 24);
            ColorsTab.Name = "ColorsTab";
            ColorsTab.Padding = new Padding(3);
            ColorsTab.Size = new Size(287, 256);
            ColorsTab.TabIndex = 1;
            ColorsTab.Text = "Colors";
            // 
            // AdvancedControlsBox
            // 
            AdvancedControlsBox.Controls.Add(label14);
            AdvancedControlsBox.Controls.Add(InactiveHexCode);
            AdvancedControlsBox.Controls.Add(InactivePick);
            AdvancedControlsBox.Controls.Add(label9);
            AdvancedControlsBox.Controls.Add(label1);
            AdvancedControlsBox.Controls.Add(TaskbarBackPick);
            AdvancedControlsBox.Controls.Add(AccentHexCode);
            AdvancedControlsBox.Controls.Add(TaskbarFrontPick);
            AdvancedControlsBox.Controls.Add(label3);
            AdvancedControlsBox.Controls.Add(StartPick);
            AdvancedControlsBox.Controls.Add(label4);
            AdvancedControlsBox.Controls.Add(SettingsIconPick);
            AdvancedControlsBox.Controls.Add(label5);
            AdvancedControlsBox.Controls.Add(TitlebarPick);
            AdvancedControlsBox.Controls.Add(label6);
            AdvancedControlsBox.Controls.Add(HoverPick);
            AdvancedControlsBox.Controls.Add(label7);
            AdvancedControlsBox.Controls.Add(AccentPick);
            AdvancedControlsBox.Controls.Add(label8);
            AdvancedControlsBox.Controls.Add(TaskbarBackHexCode);
            AdvancedControlsBox.Controls.Add(HoverHexCode);
            AdvancedControlsBox.Controls.Add(TaskbarFrontHexCode);
            AdvancedControlsBox.Controls.Add(TitlebarHexCode);
            AdvancedControlsBox.Controls.Add(StartHexCode);
            AdvancedControlsBox.Controls.Add(SettingsIconHexCode);
            AdvancedControlsBox.Location = new Point(7, 64);
            AdvancedControlsBox.Name = "AdvancedControlsBox";
            AdvancedControlsBox.Size = new Size(272, 177);
            AdvancedControlsBox.TabIndex = 3;
            AdvancedControlsBox.TabStop = false;
            AdvancedControlsBox.Text = "Advanced Controls";
            AdvancedControlsBox.Visible = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 0);
            label14.Name = "label14";
            label14.Size = new Size(110, 15);
            label14.TabIndex = 24;
            label14.Text = "Advanced Controls";
            // 
            // InactiveHexCode
            // 
            InactiveHexCode.AutoSize = true;
            InactiveHexCode.Location = new Point(142, 77);
            InactiveHexCode.Name = "InactiveHexCode";
            InactiveHexCode.Size = new Size(56, 15);
            InactiveHexCode.TabIndex = 23;
            InactiveHexCode.Text = "#000000";
            // 
            // InactivePick
            // 
            InactivePick.BackColor = Color.FromArgb(64, 64, 64);
            InactivePick.FlatStyle = FlatStyle.Popup;
            InactivePick.Font = new Font("Calibri", 9F);
            InactivePick.ForeColor = Color.White;
            InactivePick.Location = new Point(231, 74);
            InactivePick.Margin = new Padding(0);
            InactivePick.Name = "InactivePick";
            InactivePick.Size = new Size(37, 20);
            InactivePick.TabIndex = 22;
            InactivePick.Text = "Pick";
            InactivePick.UseVisualStyleBackColor = false;
            InactivePick.Click += PickButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 77);
            label9.Name = "label9";
            label9.Size = new Size(92, 15);
            label9.TabIndex = 21;
            label9.Text = "Inactive Titlebar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Accent";
            // 
            // TaskbarBackPick
            // 
            TaskbarBackPick.BackColor = Color.FromArgb(64, 64, 64);
            TaskbarBackPick.FlatStyle = FlatStyle.Popup;
            TaskbarBackPick.Font = new Font("Calibri", 9F);
            TaskbarBackPick.ForeColor = Color.White;
            TaskbarBackPick.Location = new Point(231, 154);
            TaskbarBackPick.Margin = new Padding(0);
            TaskbarBackPick.Name = "TaskbarBackPick";
            TaskbarBackPick.Size = new Size(37, 20);
            TaskbarBackPick.TabIndex = 20;
            TaskbarBackPick.Text = "Pick";
            TaskbarBackPick.UseVisualStyleBackColor = false;
            TaskbarBackPick.Click += PickButton_Click;
            // 
            // AccentHexCode
            // 
            AccentHexCode.AutoSize = true;
            AccentHexCode.Location = new Point(142, 17);
            AccentHexCode.Name = "AccentHexCode";
            AccentHexCode.Size = new Size(56, 15);
            AccentHexCode.TabIndex = 1;
            AccentHexCode.Text = "#000000";
            // 
            // TaskbarFrontPick
            // 
            TaskbarFrontPick.BackColor = Color.FromArgb(64, 64, 64);
            TaskbarFrontPick.FlatStyle = FlatStyle.Popup;
            TaskbarFrontPick.Font = new Font("Calibri", 9F);
            TaskbarFrontPick.ForeColor = Color.White;
            TaskbarFrontPick.Location = new Point(231, 134);
            TaskbarFrontPick.Margin = new Padding(0);
            TaskbarFrontPick.Name = "TaskbarFrontPick";
            TaskbarFrontPick.Size = new Size(37, 20);
            TaskbarFrontPick.TabIndex = 19;
            TaskbarFrontPick.Text = "Pick";
            TaskbarFrontPick.UseVisualStyleBackColor = false;
            TaskbarFrontPick.Click += PickButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 37);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Hover";
            // 
            // StartPick
            // 
            StartPick.BackColor = Color.FromArgb(64, 64, 64);
            StartPick.FlatStyle = FlatStyle.Popup;
            StartPick.Font = new Font("Calibri", 9F);
            StartPick.ForeColor = Color.White;
            StartPick.Location = new Point(231, 114);
            StartPick.Margin = new Padding(0);
            StartPick.Name = "StartPick";
            StartPick.Size = new Size(37, 20);
            StartPick.TabIndex = 18;
            StartPick.Text = "Pick";
            StartPick.UseVisualStyleBackColor = false;
            StartPick.Click += PickButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 57);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 3;
            label4.Text = "Window Borders";
            // 
            // SettingsIconPick
            // 
            SettingsIconPick.BackColor = Color.FromArgb(64, 64, 64);
            SettingsIconPick.FlatStyle = FlatStyle.Popup;
            SettingsIconPick.Font = new Font("Calibri", 9F);
            SettingsIconPick.ForeColor = Color.White;
            SettingsIconPick.Location = new Point(231, 94);
            SettingsIconPick.Margin = new Padding(0);
            SettingsIconPick.Name = "SettingsIconPick";
            SettingsIconPick.Size = new Size(37, 20);
            SettingsIconPick.TabIndex = 17;
            SettingsIconPick.Text = "Pick";
            SettingsIconPick.UseVisualStyleBackColor = false;
            SettingsIconPick.Click += PickButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 97);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 4;
            label5.Text = "Settings Icon";
            // 
            // TitlebarPick
            // 
            TitlebarPick.BackColor = Color.FromArgb(64, 64, 64);
            TitlebarPick.FlatStyle = FlatStyle.Popup;
            TitlebarPick.Font = new Font("Calibri", 9F);
            TitlebarPick.ForeColor = Color.White;
            TitlebarPick.Location = new Point(231, 54);
            TitlebarPick.Margin = new Padding(0);
            TitlebarPick.Name = "TitlebarPick";
            TitlebarPick.Size = new Size(37, 20);
            TitlebarPick.TabIndex = 16;
            TitlebarPick.Text = "Pick";
            TitlebarPick.UseVisualStyleBackColor = false;
            TitlebarPick.Click += PickButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 117);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 5;
            label6.Text = "Start/Notifications";
            // 
            // HoverPick
            // 
            HoverPick.BackColor = Color.FromArgb(64, 64, 64);
            HoverPick.FlatStyle = FlatStyle.Popup;
            HoverPick.Font = new Font("Calibri", 9F);
            HoverPick.ForeColor = Color.White;
            HoverPick.Location = new Point(231, 34);
            HoverPick.Margin = new Padding(0);
            HoverPick.Name = "HoverPick";
            HoverPick.Size = new Size(37, 20);
            HoverPick.TabIndex = 15;
            HoverPick.Text = "Pick";
            HoverPick.UseVisualStyleBackColor = false;
            HoverPick.Click += PickButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 137);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 6;
            label7.Text = "Taskbar Front";
            // 
            // AccentPick
            // 
            AccentPick.BackColor = Color.FromArgb(64, 64, 64);
            AccentPick.FlatStyle = FlatStyle.Popup;
            AccentPick.Font = new Font("Calibri", 9F);
            AccentPick.ForeColor = Color.White;
            AccentPick.Location = new Point(231, 14);
            AccentPick.Margin = new Padding(0);
            AccentPick.Name = "AccentPick";
            AccentPick.Size = new Size(37, 20);
            AccentPick.TabIndex = 14;
            AccentPick.Text = "Pick";
            AccentPick.UseVisualStyleBackColor = false;
            AccentPick.Click += PickButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 157);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 7;
            label8.Text = "Taskbar Back";
            // 
            // TaskbarBackHexCode
            // 
            TaskbarBackHexCode.AutoSize = true;
            TaskbarBackHexCode.Location = new Point(142, 157);
            TaskbarBackHexCode.Name = "TaskbarBackHexCode";
            TaskbarBackHexCode.Size = new Size(56, 15);
            TaskbarBackHexCode.TabIndex = 13;
            TaskbarBackHexCode.Text = "#000000";
            // 
            // HoverHexCode
            // 
            HoverHexCode.AutoSize = true;
            HoverHexCode.Location = new Point(142, 37);
            HoverHexCode.Name = "HoverHexCode";
            HoverHexCode.Size = new Size(56, 15);
            HoverHexCode.TabIndex = 8;
            HoverHexCode.Text = "#000000";
            // 
            // TaskbarFrontHexCode
            // 
            TaskbarFrontHexCode.AutoSize = true;
            TaskbarFrontHexCode.Location = new Point(142, 137);
            TaskbarFrontHexCode.Name = "TaskbarFrontHexCode";
            TaskbarFrontHexCode.Size = new Size(56, 15);
            TaskbarFrontHexCode.TabIndex = 12;
            TaskbarFrontHexCode.Text = "#000000";
            // 
            // TitlebarHexCode
            // 
            TitlebarHexCode.AutoSize = true;
            TitlebarHexCode.Location = new Point(142, 57);
            TitlebarHexCode.Name = "TitlebarHexCode";
            TitlebarHexCode.Size = new Size(56, 15);
            TitlebarHexCode.TabIndex = 9;
            TitlebarHexCode.Text = "#000000";
            // 
            // StartHexCode
            // 
            StartHexCode.AutoSize = true;
            StartHexCode.Location = new Point(142, 117);
            StartHexCode.Name = "StartHexCode";
            StartHexCode.Size = new Size(56, 15);
            StartHexCode.TabIndex = 11;
            StartHexCode.Text = "#000000";
            // 
            // SettingsIconHexCode
            // 
            SettingsIconHexCode.AutoSize = true;
            SettingsIconHexCode.Location = new Point(142, 97);
            SettingsIconHexCode.Name = "SettingsIconHexCode";
            SettingsIconHexCode.Size = new Size(56, 15);
            SettingsIconHexCode.TabIndex = 10;
            SettingsIconHexCode.Text = "#000000";
            // 
            // AdvancedViewButton
            // 
            AdvancedViewButton.BackColor = Color.FromArgb(64, 64, 64);
            AdvancedViewButton.FlatStyle = FlatStyle.Popup;
            AdvancedViewButton.ForeColor = Color.White;
            AdvancedViewButton.Location = new Point(6, 35);
            AdvancedViewButton.Name = "AdvancedViewButton";
            AdvancedViewButton.Size = new Size(75, 23);
            AdvancedViewButton.TabIndex = 1;
            AdvancedViewButton.Text = "Advanced";
            AdvancedViewButton.UseVisualStyleBackColor = false;
            AdvancedViewButton.Click += AdvancedViewButton_Click;
            // 
            // ThemeColorPick
            // 
            ThemeColorPick.BackColor = Color.FromArgb(64, 64, 64);
            ThemeColorPick.FlatStyle = FlatStyle.Popup;
            ThemeColorPick.ForeColor = Color.White;
            ThemeColorPick.Location = new Point(6, 6);
            ThemeColorPick.Name = "ThemeColorPick";
            ThemeColorPick.Size = new Size(115, 23);
            ThemeColorPick.TabIndex = 0;
            ThemeColorPick.Text = "Pick Accent Color";
            ThemeColorPick.UseVisualStyleBackColor = false;
            ThemeColorPick.Click += ThemeColorPick_Click;
            // 
            // CloseControl
            // 
            CloseControl.BackColor = Color.Red;
            CloseControl.BackgroundImageLayout = ImageLayout.Stretch;
            CloseControl.FlatAppearance.BorderSize = 0;
            CloseControl.FlatStyle = FlatStyle.Flat;
            CloseControl.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseControl.ForeColor = Color.White;
            CloseControl.Location = new Point(255, -2);
            CloseControl.Margin = new Padding(0);
            CloseControl.Name = "CloseControl";
            CloseControl.Size = new Size(36, 24);
            CloseControl.TabIndex = 9;
            CloseControl.TabStop = false;
            CloseControl.Text = "X";
            CloseControl.UseVisualStyleBackColor = false;
            CloseControl.Click += CloseControl_Click;
            // 
            // MinimizeControl
            // 
            MinimizeControl.BackColor = Color.White;
            MinimizeControl.FlatAppearance.BorderSize = 0;
            MinimizeControl.FlatStyle = FlatStyle.Flat;
            MinimizeControl.ForeColor = Color.Black;
            MinimizeControl.Location = new Point(208, -2);
            MinimizeControl.Name = "MinimizeControl";
            MinimizeControl.Size = new Size(24, 24);
            MinimizeControl.TabIndex = 8;
            MinimizeControl.TabStop = false;
            MinimizeControl.Text = "-";
            MinimizeControl.UseVisualStyleBackColor = false;
            MinimizeControl.Click += MinimizeControl_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(LinkIssueGithub);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(ReloadButton);
            panel1.Controls.Add(label10);
            panel1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 282);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 39);
            panel1.TabIndex = 10;
            // 
            // LinkIssueGithub
            // 
            LinkIssueGithub.AutoSize = true;
            LinkIssueGithub.LinkColor = Color.FromArgb(128, 128, 255);
            LinkIssueGithub.Location = new Point(138, 22);
            LinkIssueGithub.Name = "LinkIssueGithub";
            LinkIssueGithub.Size = new Size(153, 15);
            LinkIssueGithub.TabIndex = 3;
            LinkIssueGithub.TabStop = true;
            LinkIssueGithub.Text = "Create an issue on GitHub";
            LinkIssueGithub.VisitedLinkColor = Color.FromArgb(255, 128, 255);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 22);
            label11.Name = "label11";
            label11.Size = new Size(119, 15);
            label11.TabIndex = 2;
            label11.Text = "If that does not work:";
            // 
            // ReloadButton
            // 
            ReloadButton.BackColor = Color.FromArgb(64, 64, 64);
            ReloadButton.FlatStyle = FlatStyle.Popup;
            ReloadButton.Font = new Font("Segoe UI", 7.75F);
            ReloadButton.ForeColor = Color.White;
            ReloadButton.Location = new Point(176, 0);
            ReloadButton.Name = "ReloadButton";
            ReloadButton.Size = new Size(115, 20);
            ReloadButton.TabIndex = 1;
            ReloadButton.Text = "Click me to reload";
            ReloadButton.UseVisualStyleBackColor = false;
            ReloadButton.Click += ReloadButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 3);
            label10.Name = "label10";
            label10.Size = new Size(172, 15);
            label10.TabIndex = 0;
            label10.Text = "If your changes don't show up:";
            // 
            // AboutButton
            // 
            AboutButton.BackColor = Color.PowderBlue;
            AboutButton.BackgroundImage = (Image)resources.GetObject("AboutButton.BackgroundImage");
            AboutButton.BackgroundImageLayout = ImageLayout.Stretch;
            AboutButton.Location = new Point(232, 0);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(24, 22);
            AboutButton.TabIndex = 11;
            AboutButton.TabStop = false;
            AboutButton.Click += AboutButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(291, 341);
            Controls.Add(AboutButton);
            Controls.Add(panel1);
            Controls.Add(MinimizeControl);
            Controls.Add(CloseControl);
            Controls.Add(AppContainer);
            Controls.Add(ProgramId);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Opacity = 0.98D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTouchUp";
            TopMost = true;
            Load += MainForm_Load;
            MouseDown += App_DragTitleBar;
            ProgramId.ResumeLayout(false);
            ProgramId.PerformLayout();
            ThemeSettingsBox.ResumeLayout(false);
            ThemeSettingsBox.PerformLayout();
            AppContainer.ResumeLayout(false);
            GeneralTab.ResumeLayout(false);
            ToggleSettingsBox.ResumeLayout(false);
            ToggleSettingsBox.PerformLayout();
            ColorsTab.ResumeLayout(false);
            AdvancedControlsBox.ResumeLayout(false);
            AdvancedControlsBox.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AboutButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip ProgramId;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private RadioButton DarkThemeEnable;
        private RadioButton LightThemeEnable;
        private GroupBox ThemeSettingsBox;
        private TabControl AppContainer;
        private TabPage GeneralTab;
        private TabPage ColorsTab;
        private GroupBox ToggleSettingsBox;
        private CheckBox TransparencyEffectToggle;
        private CheckBox ColorPrevalenceToggle;
        private CheckBox BorderColorToggle;
        private Button ThemeColorPick;
        private Button AdvancedViewButton;
        private GroupBox AdvancedControlsBox;
        private Label label1;
        private Button TaskbarBackPick;
        private Label AccentHexCode;
        private Button TaskbarFrontPick;
        private Label label3;
        private Button StartPick;
        private Label label4;
        private Button SettingsIconPick;
        private Label label5;
        private Button TitlebarPick;
        private Label label6;
        private Button HoverPick;
        private Label label7;
        private Button AccentPick;
        private Label label8;
        private Label TaskbarBackHexCode;
        private Label HoverHexCode;
        private Label TaskbarFrontHexCode;
        private Label TitlebarHexCode;
        private Label StartHexCode;
        private Label SettingsIconHexCode;
        private Label InactiveHexCode;
        private Button InactivePick;
        private Label label9;
        private Button CloseControl;
        private Button MinimizeControl;
        private Panel panel1;
        private Button ReloadButton;
        private Label label10;
        private LinkLabel LinkIssueGithub;
        private Label label11;
        private PictureBox AboutButton;
        private Label label12;
        private Label label13;
        private Label label14;
    }
}
