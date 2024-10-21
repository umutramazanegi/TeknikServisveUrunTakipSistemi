namespace TeknikServis.Formlar
{
    partial class Frm_ArizaListesi
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
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D2 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Pie3DSeriesView pie3DSeriesView3 = new DevExpress.XtraCharts.Pie3DSeriesView();
            DevExpress.XtraCharts.Pie3DSeriesView pie3DSeriesView4 = new DevExpress.XtraCharts.Pie3DSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ArizaListesi));
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl36 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            simpleDiagram3D2.RotationMatrixSerializable = "0.998513796954425;0.000973437706906749;-0.0544908222610913;0;-0.0436102969043728;" +
    "0.613914237918789;-0.78816714628593;0;0.0326854600024462;0.789372130810067;0.613" +
    "044288616088;0;0;0;0;1";
            this.chartControl1.Diagram = simpleDiagram3D2;
            this.chartControl1.IndicatorsPaletteName = "Pastel Kit";
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(5, 108);
            this.chartControl1.Name = "chartControl1";
            series2.LegendTextPattern = "{A}";
            series2.Name = "Series 1";
            series2.View = pie3DSeriesView3;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl1.SeriesTemplate.View = pie3DSeriesView4;
            this.chartControl1.Size = new System.Drawing.Size(1015, 259);
            this.chartControl1.TabIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.labelControl39);
            this.panelControl1.Controls.Add(this.labelControl38);
            this.panelControl1.Controls.Add(this.chartControl1);
            this.panelControl1.Location = new System.Drawing.Point(1035, 388);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1020, 371);
            this.panelControl1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(99)))), ((int)(((byte)(130)))));
            this.panel3.Controls.Add(this.labelControl20);
            this.panel3.Controls.Add(this.labelControl19);
            this.panel3.Location = new System.Drawing.Point(1719, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 188);
            this.panel3.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(224)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Location = new System.Drawing.Point(1377, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 188);
            this.panel2.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Location = new System.Drawing.Point(1035, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 188);
            this.panel1.TabIndex = 33;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.panel5.Controls.Add(this.labelControl22);
            this.panel5.Controls.Add(this.labelControl21);
            this.panel5.Location = new System.Drawing.Point(1035, 194);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(336, 188);
            this.panel5.TabIndex = 32;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(209)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1027, 759);
            this.gridControl1.TabIndex = 31;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(105)))), ((int)(((byte)(189)))));
            this.panel6.Controls.Add(this.labelControl37);
            this.panel6.Controls.Add(this.labelControl36);
            this.panel6.Location = new System.Drawing.Point(1719, 194);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(336, 188);
            this.panel6.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.panel4.Controls.Add(this.labelControl35);
            this.panel4.Controls.Add(this.labelControl33);
            this.panel4.Location = new System.Drawing.Point(1377, 194);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(336, 188);
            this.panel4.TabIndex = 36;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(89, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(147, 54);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Mevcut Arızalı \r\nÜrün Sayısı";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(122, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 39);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "584";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(104, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(127, 39);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Arçelik";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(104, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(153, 54);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tadilatı Bitmiş\r\nÜrün Sayısı";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl20.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl20.Appearance.Options.UseFont = true;
            this.labelControl20.Appearance.Options.UseForeColor = true;
            this.labelControl20.Location = new System.Drawing.Point(121, 90);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(65, 39);
            this.labelControl20.TabIndex = 3;
            this.labelControl20.Text = "584";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl19.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.Location = new System.Drawing.Point(93, 12);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(155, 54);
            this.labelControl19.TabIndex = 2;
            this.labelControl19.Text = "Parça Bekleyen\r\nÜrün Sayısı";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl22.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Appearance.Options.UseForeColor = true;
            this.labelControl22.Location = new System.Drawing.Point(122, 95);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(65, 39);
            this.labelControl22.TabIndex = 3;
            this.labelControl22.Text = "584";
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl21.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.Appearance.Options.UseForeColor = true;
            this.labelControl21.Location = new System.Drawing.Point(89, 16);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(162, 54);
            this.labelControl21.TabIndex = 2;
            this.labelControl21.Text = "Mesaj Beklenen \r\nMüşteriler";
            // 
            // labelControl33
            // 
            this.labelControl33.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl33.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl33.Appearance.Options.UseFont = true;
            this.labelControl33.Appearance.Options.UseForeColor = true;
            this.labelControl33.Location = new System.Drawing.Point(65, 16);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(203, 27);
            this.labelControl33.TabIndex = 1;
            this.labelControl33.Text = "Toplam Ürün Sayısı";
            // 
            // labelControl35
            // 
            this.labelControl35.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl35.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl35.Appearance.Options.UseFont = true;
            this.labelControl35.Appearance.Options.UseForeColor = true;
            this.labelControl35.Location = new System.Drawing.Point(135, 95);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(65, 39);
            this.labelControl35.TabIndex = 2;
            this.labelControl35.Text = "584";
            // 
            // labelControl37
            // 
            this.labelControl37.Appearance.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl37.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl37.Appearance.Options.UseFont = true;
            this.labelControl37.Appearance.Options.UseForeColor = true;
            this.labelControl37.Location = new System.Drawing.Point(107, 95);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(127, 39);
            this.labelControl37.TabIndex = 3;
            this.labelControl37.Text = "Arçelik";
            // 
            // labelControl36
            // 
            this.labelControl36.Appearance.Font = new System.Drawing.Font("Georgia", 14F);
            this.labelControl36.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl36.Appearance.Options.UseFont = true;
            this.labelControl36.Appearance.Options.UseForeColor = true;
            this.labelControl36.Location = new System.Drawing.Point(107, 16);
            this.labelControl36.Name = "labelControl36";
            this.labelControl36.Size = new System.Drawing.Size(122, 54);
            this.labelControl36.TabIndex = 2;
            this.labelControl36.Text = "İptal Edilen\r\nİşlemler";
            // 
            // labelControl39
            // 
            this.labelControl39.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl39.Appearance.Options.UseFont = true;
            this.labelControl39.Location = new System.Drawing.Point(91, 51);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(779, 40);
            this.labelControl39.TabIndex = 7;
            this.labelControl39.Text = resources.GetString("labelControl39.Text");
            // 
            // labelControl38
            // 
            this.labelControl38.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl38.Appearance.Options.UseFont = true;
            this.labelControl38.Location = new System.Drawing.Point(407, 20);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(213, 25);
            this.labelControl38.TabIndex = 6;
            this.labelControl38.Text = "Arızalı Ürün İstatistikleri";
            // 
            // Frm_ArizaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2057, 759);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm_ArizaListesi";
            this.Text = "ARIZA ÜRÜN LİSTESİ";
            this.Load += new System.EventHandler(this.Frm_ArizaListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.LabelControl labelControl36;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.LabelControl labelControl33;
    }
}