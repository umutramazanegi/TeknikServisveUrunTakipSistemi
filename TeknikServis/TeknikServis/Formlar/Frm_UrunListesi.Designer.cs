namespace TeknikServis.Formlar
{
    partial class Frm_UrunListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UrunListesi));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnlistele = new DevExpress.XtraEditors.SimpleButton();
            this.btntemizle = new DevExpress.XtraEditors.SimpleButton();
            this.txturunid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnguncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnsil = new DevExpress.XtraEditors.SimpleButton();
            this.btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lblkattegori = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtstok = new DevExpress.XtraEditors.TextEdit();
            this.lblstok = new DevExpress.XtraEditors.LabelControl();
            this.txtsatisfiyat = new DevExpress.XtraEditors.TextEdit();
            this.lblsatisfiyat = new DevExpress.XtraEditors.LabelControl();
            this.txtalisfiyat = new DevExpress.XtraEditors.TextEdit();
            this.lblalisfiyat = new DevExpress.XtraEditors.LabelControl();
            this.txtmarka = new DevExpress.XtraEditors.TextEdit();
            this.lblmarka = new DevExpress.XtraEditors.LabelControl();
            this.txturunad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txturunid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsatisfiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtalisfiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txturunad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, -4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1678, 899);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(209)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnlistele);
            this.groupControl2.Controls.Add(this.btntemizle);
            this.groupControl2.Controls.Add(this.txturunid);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.btnguncelle);
            this.groupControl2.Controls.Add(this.btnsil);
            this.groupControl2.Controls.Add(this.btnkaydet);
            this.groupControl2.Controls.Add(this.lblkattegori);
            this.groupControl2.Controls.Add(this.lookUpEdit1);
            this.groupControl2.Controls.Add(this.txtstok);
            this.groupControl2.Controls.Add(this.lblstok);
            this.groupControl2.Controls.Add(this.txtsatisfiyat);
            this.groupControl2.Controls.Add(this.lblsatisfiyat);
            this.groupControl2.Controls.Add(this.txtalisfiyat);
            this.groupControl2.Controls.Add(this.lblalisfiyat);
            this.groupControl2.Controls.Add(this.txtmarka);
            this.groupControl2.Controls.Add(this.lblmarka);
            this.groupControl2.Controls.Add(this.txturunad);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(1684, -4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(361, 899);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Ürün İşlemleri";
            // 
            // btnlistele
            // 
            this.btnlistele.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnlistele.Appearance.Options.UseFont = true;
            this.btnlistele.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnlistele.ImageOptions.Image")));
            this.btnlistele.Location = new System.Drawing.Point(209, 426);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(147, 45);
            this.btnlistele.TabIndex = 10;
            this.btnlistele.Text = "Listele";
            this.btnlistele.Click += new System.EventHandler(this.btnlistele_Click);
            // 
            // btntemizle
            // 
            this.btntemizle.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btntemizle.Appearance.Options.UseFont = true;
            this.btntemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btntemizle.ImageOptions.Image")));
            this.btntemizle.Location = new System.Drawing.Point(113, 477);
            this.btntemizle.Name = "btntemizle";
            this.btntemizle.Size = new System.Drawing.Size(147, 47);
            this.btntemizle.TabIndex = 11;
            this.btntemizle.Text = "Temizle";
            this.btntemizle.Click += new System.EventHandler(this.btntemizle_Click);
            // 
            // txturunid
            // 
            this.txturunid.Enabled = false;
            this.txturunid.Location = new System.Drawing.Point(134, 100);
            this.txturunid.Name = "txturunid";
            this.txturunid.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txturunid.Properties.Appearance.Options.UseFont = true;
            this.txturunid.Size = new System.Drawing.Size(179, 30);
            this.txturunid.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(55, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 24);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Ürün ID:";
            // 
            // btnguncelle
            // 
            this.btnguncelle.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnguncelle.Appearance.Options.UseFont = true;
            this.btnguncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnguncelle.ImageOptions.Image")));
            this.btnguncelle.Location = new System.Drawing.Point(15, 426);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(147, 45);
            this.btnguncelle.TabIndex = 9;
            this.btnguncelle.Text = "Güncelle";
            this.btnguncelle.Click += new System.EventHandler(this.btnguncelle_Click);
            // 
            // btnsil
            // 
            this.btnsil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.Appearance.Options.UseFont = true;
            this.btnsil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsil.ImageOptions.Image")));
            this.btnsil.Location = new System.Drawing.Point(209, 376);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(147, 44);
            this.btnsil.TabIndex = 8;
            this.btnsil.Text = "Sil";
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Appearance.Options.UseFont = true;
            this.btnkaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnkaydet.ImageOptions.Image")));
            this.btnkaydet.Location = new System.Drawing.Point(15, 376);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(147, 44);
            this.btnkaydet.TabIndex = 7;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // lblkattegori
            // 
            this.lblkattegori.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblkattegori.Appearance.Options.UseFont = true;
            this.lblkattegori.Location = new System.Drawing.Point(55, 319);
            this.lblkattegori.Name = "lblkattegori";
            this.lblkattegori.Size = new System.Drawing.Size(74, 24);
            this.lblkattegori.TabIndex = 14;
            this.lblkattegori.Text = "Kategori:";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(134, 316);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DisplayMember = "AD";
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(179, 30);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // txtstok
            // 
            this.txtstok.Location = new System.Drawing.Point(134, 280);
            this.txtstok.Name = "txtstok";
            this.txtstok.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtstok.Properties.Appearance.Options.UseFont = true;
            this.txtstok.Size = new System.Drawing.Size(179, 30);
            this.txtstok.TabIndex = 5;
            // 
            // lblstok
            // 
            this.lblstok.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblstok.Appearance.Options.UseFont = true;
            this.lblstok.Location = new System.Drawing.Point(87, 283);
            this.lblstok.Name = "lblstok";
            this.lblstok.Size = new System.Drawing.Size(41, 24);
            this.lblstok.TabIndex = 11;
            this.lblstok.Text = "Stok:";
            // 
            // txtsatisfiyat
            // 
            this.txtsatisfiyat.Location = new System.Drawing.Point(134, 244);
            this.txtsatisfiyat.Name = "txtsatisfiyat";
            this.txtsatisfiyat.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsatisfiyat.Properties.Appearance.Options.UseFont = true;
            this.txtsatisfiyat.Size = new System.Drawing.Size(179, 30);
            this.txtsatisfiyat.TabIndex = 4;
            // 
            // lblsatisfiyat
            // 
            this.lblsatisfiyat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblsatisfiyat.Appearance.Options.UseFont = true;
            this.lblsatisfiyat.Location = new System.Drawing.Point(40, 247);
            this.lblsatisfiyat.Name = "lblsatisfiyat";
            this.lblsatisfiyat.Size = new System.Drawing.Size(88, 24);
            this.lblsatisfiyat.TabIndex = 9;
            this.lblsatisfiyat.Text = "Satış Fiyat:";
            // 
            // txtalisfiyat
            // 
            this.txtalisfiyat.Location = new System.Drawing.Point(134, 208);
            this.txtalisfiyat.Name = "txtalisfiyat";
            this.txtalisfiyat.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtalisfiyat.Properties.Appearance.Options.UseFont = true;
            this.txtalisfiyat.Size = new System.Drawing.Size(179, 30);
            this.txtalisfiyat.TabIndex = 3;
            // 
            // lblalisfiyat
            // 
            this.lblalisfiyat.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblalisfiyat.Appearance.Options.UseFont = true;
            this.lblalisfiyat.Location = new System.Drawing.Point(49, 211);
            this.lblalisfiyat.Name = "lblalisfiyat";
            this.lblalisfiyat.Size = new System.Drawing.Size(79, 24);
            this.lblalisfiyat.TabIndex = 7;
            this.lblalisfiyat.Text = "Alış Fiyat:";
            // 
            // txtmarka
            // 
            this.txtmarka.Location = new System.Drawing.Point(134, 172);
            this.txtmarka.Name = "txtmarka";
            this.txtmarka.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmarka.Properties.Appearance.Options.UseFont = true;
            this.txtmarka.Size = new System.Drawing.Size(179, 30);
            this.txtmarka.TabIndex = 2;
            // 
            // lblmarka
            // 
            this.lblmarka.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblmarka.Appearance.Options.UseFont = true;
            this.lblmarka.Location = new System.Drawing.Point(72, 178);
            this.lblmarka.Name = "lblmarka";
            this.lblmarka.Size = new System.Drawing.Size(56, 24);
            this.lblmarka.TabIndex = 5;
            this.lblmarka.Text = "Marka:";
            // 
            // txturunad
            // 
            this.txturunad.Location = new System.Drawing.Point(134, 136);
            this.txturunad.Name = "txturunad";
            this.txturunad.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txturunad.Properties.Appearance.Options.UseFont = true;
            this.txturunad.Size = new System.Drawing.Size(179, 30);
            this.txturunad.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(49, 139);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 24);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Ürün Ad:";
            // 
            // Frm_UrunListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2057, 898);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm_UrunListesi";
            this.Text = "Ürün Listesi";
            this.Load += new System.EventHandler(this.Frm_UrunListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txturunid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsatisfiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtalisfiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txturunad.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnlistele;
        private DevExpress.XtraEditors.SimpleButton btntemizle;
        private DevExpress.XtraEditors.TextEdit txturunid;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnguncelle;
        private DevExpress.XtraEditors.SimpleButton btnsil;
        private DevExpress.XtraEditors.SimpleButton btnkaydet;
        private DevExpress.XtraEditors.LabelControl lblkattegori;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.TextEdit txtstok;
        private DevExpress.XtraEditors.LabelControl lblstok;
        private DevExpress.XtraEditors.TextEdit txtsatisfiyat;
        private DevExpress.XtraEditors.LabelControl lblsatisfiyat;
        private DevExpress.XtraEditors.TextEdit txtalisfiyat;
        private DevExpress.XtraEditors.LabelControl lblalisfiyat;
        private DevExpress.XtraEditors.TextEdit txtmarka;
        private DevExpress.XtraEditors.LabelControl lblmarka;
        private DevExpress.XtraEditors.TextEdit txturunad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}