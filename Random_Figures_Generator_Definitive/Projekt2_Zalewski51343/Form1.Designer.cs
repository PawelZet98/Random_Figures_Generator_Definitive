namespace Projekt2_Zalewski51343
{
    partial class Form1
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
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.lblN = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnWykreślFiguryGeometryczne = new System.Windows.Forms.Button();
            this.btnPrzesuńDoNowejLokalizacji = new System.Windows.Forms.Button();
            this.btnPrzesuńIZmieńAtrybutyGraficzne = new System.Windows.Forms.Button();
            this.btnWlaczSlajder = new System.Windows.Forms.Button();
            this.btnWylaczSlajder = new System.Windows.Forms.Button();
            this.gbPokazFigur = new System.Windows.Forms.GroupBox();
            this.rbManualny = new System.Windows.Forms.RadioButton();
            this.rbAutomatyczny = new System.Windows.Forms.RadioButton();
            this.btnNastepny = new System.Windows.Forms.Button();
            this.txtNumerFigury = new System.Windows.Forms.TextBox();
            this.lblNumerFigury = new System.Windows.Forms.Label();
            this.btnPoprzedni = new System.Windows.Forms.Button();
            this.chlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.gbFiguraMysz = new System.Windows.Forms.GroupBox();
            this.rdbRectangleFill = new System.Windows.Forms.RadioButton();
            this.rbDrawPie = new System.Windows.Forms.RadioButton();
            this.rbDrawArc = new System.Windows.Forms.RadioButton();
            this.rbFillPath = new System.Windows.Forms.RadioButton();
            this.rbDrawCurve = new System.Windows.Forms.RadioButton();
            this.rbEllipse = new System.Windows.Forms.RadioButton();
            this.rbKwadrat = new System.Windows.Forms.RadioButton();
            this.rbElipsa = new System.Windows.Forms.RadioButton();
            this.rbProstokat = new System.Windows.Forms.RadioButton();
            this.rbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rbDrawPath = new System.Windows.Forms.RadioButton();
            this.rbClosedCurve = new System.Windows.Forms.RadioButton();
            this.rbFillPie = new System.Windows.Forms.RadioButton();
            this.rbLiniaMysz = new System.Windows.Forms.RadioButton();
            this.rbWielokatForemny = new System.Windows.Forms.RadioButton();
            this.rbOkrag = new System.Windows.Forms.RadioButton();
            this.rbPunkt = new System.Windows.Forms.RadioButton();
            this.btnZmienLokalizacjeMysz = new System.Windows.Forms.Button();
            this.btnAtrybutyGraficzneMysz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStopieńWielokąta = new System.Windows.Forms.TextBox();
            this.txtKątKońcowy = new System.Windows.Forms.TextBox();
            this.txtKątKońcowyArc = new System.Windows.Forms.TextBox();
            this.txtKątKońcowyPie = new System.Windows.Forms.TextBox();
            this.txtLiczbaPunktowKrzywej = new System.Windows.Forms.TextBox();
            this.txtLiczbaPunktowSciezki = new System.Windows.Forms.TextBox();
            this.txtLiczbaPunktowKrzywejOtwartej = new System.Windows.Forms.TextBox();
            this.txtLiczbaPunktowDoSciezkiZamknietej = new System.Windows.Forms.TextBox();
            this.txtKątPoczątkowy = new System.Windows.Forms.TextBox();
            this.txtKątPoczątkowyArc = new System.Windows.Forms.TextBox();
            this.txtKątPoczątkowyPie = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            this.gbPokazFigur.SuspendLayout();
            this.gbFiguraMysz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.Location = new System.Drawing.Point(183, 55);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(900, 483);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbRysownica_MouseDown);
            this.pbRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbRysownica_MouseMove);
            this.pbRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbRysownica_MouseUp);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(10, 9);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(102, 39);
            this.lblN.TabIndex = 2;
            this.lblN.Text = "Podaj liczbę figur \r\ngeometrycznych do \r\nprezentacji.";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(12, 55);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(99, 20);
            this.txtN.TabIndex = 3;
            // 
            // btnWykreślFiguryGeometryczne
            // 
            this.btnWykreślFiguryGeometryczne.Location = new System.Drawing.Point(10, 103);
            this.btnWykreślFiguryGeometryczne.Name = "btnWykreślFiguryGeometryczne";
            this.btnWykreślFiguryGeometryczne.Size = new System.Drawing.Size(146, 56);
            this.btnWykreślFiguryGeometryczne.TabIndex = 4;
            this.btnWykreślFiguryGeometryczne.Text = "Wykreśl figury geometryczne";
            this.btnWykreślFiguryGeometryczne.UseVisualStyleBackColor = true;
            this.btnWykreślFiguryGeometryczne.Click += new System.EventHandler(this.BtnWykreślFiguryGeometryczne_Click);
            // 
            // btnPrzesuńDoNowejLokalizacji
            // 
            this.btnPrzesuńDoNowejLokalizacji.Enabled = false;
            this.btnPrzesuńDoNowejLokalizacji.Location = new System.Drawing.Point(10, 181);
            this.btnPrzesuńDoNowejLokalizacji.Name = "btnPrzesuńDoNowejLokalizacji";
            this.btnPrzesuńDoNowejLokalizacji.Size = new System.Drawing.Size(146, 56);
            this.btnPrzesuńDoNowejLokalizacji.TabIndex = 5;
            this.btnPrzesuńDoNowejLokalizacji.Text = "Przesuń do nowej lokalizacji";
            this.btnPrzesuńDoNowejLokalizacji.UseVisualStyleBackColor = true;
            this.btnPrzesuńDoNowejLokalizacji.Click += new System.EventHandler(this.BtnPrzesuńDoNowejLokalizacji_Click);
            // 
            // btnPrzesuńIZmieńAtrybutyGraficzne
            // 
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Enabled = false;
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Location = new System.Drawing.Point(10, 259);
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Name = "btnPrzesuńIZmieńAtrybutyGraficzne";
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Size = new System.Drawing.Size(145, 61);
            this.btnPrzesuńIZmieńAtrybutyGraficzne.TabIndex = 6;
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Text = "Zmień atrybuty graficzne figur geometrycznych";
            this.btnPrzesuńIZmieńAtrybutyGraficzne.UseVisualStyleBackColor = true;
            this.btnPrzesuńIZmieńAtrybutyGraficzne.Click += new System.EventHandler(this.BtnPrzesuńIZmieńAtrybutyGraficzne_Click);
            // 
            // btnWlaczSlajder
            // 
            this.btnWlaczSlajder.Enabled = false;
            this.btnWlaczSlajder.Location = new System.Drawing.Point(17, 564);
            this.btnWlaczSlajder.Name = "btnWlaczSlajder";
            this.btnWlaczSlajder.Size = new System.Drawing.Size(100, 48);
            this.btnWlaczSlajder.TabIndex = 7;
            this.btnWlaczSlajder.Text = "Włącz slajder figur geometrycznych";
            this.btnWlaczSlajder.UseVisualStyleBackColor = true;
            this.btnWlaczSlajder.Click += new System.EventHandler(this.BtnWlaczSlajder_Click);
            // 
            // btnWylaczSlajder
            // 
            this.btnWylaczSlajder.Enabled = false;
            this.btnWylaczSlajder.Location = new System.Drawing.Point(123, 564);
            this.btnWylaczSlajder.Name = "btnWylaczSlajder";
            this.btnWylaczSlajder.Size = new System.Drawing.Size(100, 49);
            this.btnWylaczSlajder.TabIndex = 8;
            this.btnWylaczSlajder.Text = "Wyłącz slajder figur geometrycznych";
            this.btnWylaczSlajder.UseVisualStyleBackColor = true;
            this.btnWylaczSlajder.Click += new System.EventHandler(this.BtnWylaczSlajder_Click);
            // 
            // gbPokazFigur
            // 
            this.gbPokazFigur.Controls.Add(this.rbManualny);
            this.gbPokazFigur.Controls.Add(this.rbAutomatyczny);
            this.gbPokazFigur.Location = new System.Drawing.Point(256, 564);
            this.gbPokazFigur.Name = "gbPokazFigur";
            this.gbPokazFigur.Size = new System.Drawing.Size(246, 49);
            this.gbPokazFigur.TabIndex = 9;
            this.gbPokazFigur.TabStop = false;
            this.gbPokazFigur.Text = "Pokaz figur";
            // 
            // rbManualny
            // 
            this.rbManualny.AutoSize = true;
            this.rbManualny.Location = new System.Drawing.Point(103, 20);
            this.rbManualny.Name = "rbManualny";
            this.rbManualny.Size = new System.Drawing.Size(137, 17);
            this.rbManualny.TabIndex = 1;
            this.rbManualny.TabStop = true;
            this.rbManualny.Text = "Manualny (przyciskowy)";
            this.rbManualny.UseVisualStyleBackColor = true;
            // 
            // rbAutomatyczny
            // 
            this.rbAutomatyczny.AutoSize = true;
            this.rbAutomatyczny.Location = new System.Drawing.Point(7, 20);
            this.rbAutomatyczny.Name = "rbAutomatyczny";
            this.rbAutomatyczny.Size = new System.Drawing.Size(91, 17);
            this.rbAutomatyczny.TabIndex = 0;
            this.rbAutomatyczny.TabStop = true;
            this.rbAutomatyczny.Text = "Automatyczny";
            this.rbAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // btnNastepny
            // 
            this.btnNastepny.Enabled = false;
            this.btnNastepny.Location = new System.Drawing.Point(920, 564);
            this.btnNastepny.Name = "btnNastepny";
            this.btnNastepny.Size = new System.Drawing.Size(96, 40);
            this.btnNastepny.TabIndex = 10;
            this.btnNastepny.Text = "Następny";
            this.btnNastepny.UseVisualStyleBackColor = true;
            this.btnNastepny.Click += new System.EventHandler(this.BtnNastepny_Click);
            // 
            // txtNumerFigury
            // 
            this.txtNumerFigury.Enabled = false;
            this.txtNumerFigury.Location = new System.Drawing.Point(790, 582);
            this.txtNumerFigury.Name = "txtNumerFigury";
            this.txtNumerFigury.Size = new System.Drawing.Size(100, 20);
            this.txtNumerFigury.TabIndex = 11;
            this.txtNumerFigury.Text = "0";
            this.txtNumerFigury.TextChanged += new System.EventHandler(this.TxtNumerFigury_TextChanged);
            // 
            // lblNumerFigury
            // 
            this.lblNumerFigury.AutoSize = true;
            this.lblNumerFigury.Location = new System.Drawing.Point(787, 566);
            this.lblNumerFigury.Name = "lblNumerFigury";
            this.lblNumerFigury.Size = new System.Drawing.Size(67, 13);
            this.lblNumerFigury.TabIndex = 12;
            this.lblNumerFigury.Text = "Indeks figury";
            // 
            // btnPoprzedni
            // 
            this.btnPoprzedni.Enabled = false;
            this.btnPoprzedni.Location = new System.Drawing.Point(651, 564);
            this.btnPoprzedni.Name = "btnPoprzedni";
            this.btnPoprzedni.Size = new System.Drawing.Size(105, 40);
            this.btnPoprzedni.TabIndex = 13;
            this.btnPoprzedni.Text = "Poprzedni";
            this.btnPoprzedni.UseVisualStyleBackColor = true;
            this.btnPoprzedni.Click += new System.EventHandler(this.BtnPoprzedni_Click);
            // 
            // chlbFiguryGeometryczne
            // 
            this.chlbFiguryGeometryczne.FormattingEnabled = true;
            this.chlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Prostokąt",
            "Wielokąt",
            "Okrąg",
            "Kwadrat",
            "Wypełniony wycinek koła",
            "Wypełniona elipsa",
            "Łuk",
            "Wycinek koła"});
            this.chlbFiguryGeometryczne.Location = new System.Drawing.Point(1090, 55);
            this.chlbFiguryGeometryczne.Name = "chlbFiguryGeometryczne";
            this.chlbFiguryGeometryczne.Size = new System.Drawing.Size(442, 169);
            this.chlbFiguryGeometryczne.TabIndex = 14;
            // 
            // gbFiguraMysz
            // 
            this.gbFiguraMysz.Controls.Add(this.rdbRectangleFill);
            this.gbFiguraMysz.Controls.Add(this.rbDrawPie);
            this.gbFiguraMysz.Controls.Add(this.rbDrawArc);
            this.gbFiguraMysz.Controls.Add(this.rbFillPath);
            this.gbFiguraMysz.Controls.Add(this.rbDrawCurve);
            this.gbFiguraMysz.Controls.Add(this.rbEllipse);
            this.gbFiguraMysz.Controls.Add(this.rbKwadrat);
            this.gbFiguraMysz.Controls.Add(this.rbElipsa);
            this.gbFiguraMysz.Controls.Add(this.rbProstokat);
            this.gbFiguraMysz.Controls.Add(this.rbLiniaProsta);
            this.gbFiguraMysz.Controls.Add(this.rbDrawPath);
            this.gbFiguraMysz.Controls.Add(this.rbClosedCurve);
            this.gbFiguraMysz.Controls.Add(this.rbFillPie);
            this.gbFiguraMysz.Controls.Add(this.rbLiniaMysz);
            this.gbFiguraMysz.Controls.Add(this.rbWielokatForemny);
            this.gbFiguraMysz.Controls.Add(this.rbOkrag);
            this.gbFiguraMysz.Controls.Add(this.rbPunkt);
            this.gbFiguraMysz.Location = new System.Drawing.Point(1090, 230);
            this.gbFiguraMysz.Name = "gbFiguraMysz";
            this.gbFiguraMysz.Size = new System.Drawing.Size(442, 242);
            this.gbFiguraMysz.TabIndex = 15;
            this.gbFiguraMysz.TabStop = false;
            this.gbFiguraMysz.Text = "Wybierz figurę geometryczną do kreślenia myszą";
            // 
            // rdbRectangleFill
            // 
            this.rdbRectangleFill.AutoSize = true;
            this.rdbRectangleFill.Location = new System.Drawing.Point(215, 143);
            this.rdbRectangleFill.Name = "rdbRectangleFill";
            this.rdbRectangleFill.Size = new System.Drawing.Size(133, 17);
            this.rdbRectangleFill.TabIndex = 45;
            this.rdbRectangleFill.TabStop = true;
            this.rdbRectangleFill.Text = "Prostokąt (Fill egzamin)";
            this.rdbRectangleFill.UseVisualStyleBackColor = true;
            // 
            // rbDrawPie
            // 
            this.rbDrawPie.AutoSize = true;
            this.rbDrawPie.Location = new System.Drawing.Point(215, 166);
            this.rbDrawPie.Name = "rbDrawPie";
            this.rbDrawPie.Size = new System.Drawing.Size(141, 17);
            this.rbDrawPie.TabIndex = 15;
            this.rbDrawPie.TabStop = true;
            this.rbDrawPie.Text = "Wycinek koła (DrawPie)";
            this.rbDrawPie.UseVisualStyleBackColor = true;
            // 
            // rbDrawArc
            // 
            this.rbDrawArc.AutoSize = true;
            this.rbDrawArc.Location = new System.Drawing.Point(215, 189);
            this.rbDrawArc.Name = "rbDrawArc";
            this.rbDrawArc.Size = new System.Drawing.Size(94, 17);
            this.rbDrawArc.TabIndex = 14;
            this.rbDrawArc.TabStop = true;
            this.rbDrawArc.Text = "Łuk (DrawArc)";
            this.rbDrawArc.UseVisualStyleBackColor = true;
            // 
            // rbFillPath
            // 
            this.rbFillPath.AutoSize = true;
            this.rbFillPath.Location = new System.Drawing.Point(6, 189);
            this.rbFillPath.Name = "rbFillPath";
            this.rbFillPath.Size = new System.Drawing.Size(165, 17);
            this.rbFillPath.TabIndex = 13;
            this.rbFillPath.TabStop = true;
            this.rbFillPath.Text = "Wypełniona ścieżka (FillPath)";
            this.rbFillPath.UseVisualStyleBackColor = true;
            // 
            // rbDrawCurve
            // 
            this.rbDrawCurve.AutoSize = true;
            this.rbDrawCurve.Location = new System.Drawing.Point(6, 212);
            this.rbDrawCurve.Name = "rbDrawCurve";
            this.rbDrawCurve.Size = new System.Drawing.Size(121, 17);
            this.rbDrawCurve.TabIndex = 12;
            this.rbDrawCurve.TabStop = true;
            this.rbDrawCurve.Text = "Krzywa (DrawCurve)";
            this.rbDrawCurve.UseVisualStyleBackColor = true;
            // 
            // rbEllipse
            // 
            this.rbEllipse.AutoSize = true;
            this.rbEllipse.Location = new System.Drawing.Point(215, 120);
            this.rbEllipse.Name = "rbEllipse";
            this.rbEllipse.Size = new System.Drawing.Size(164, 17);
            this.rbEllipse.TabIndex = 11;
            this.rbEllipse.TabStop = true;
            this.rbEllipse.Text = "Wypełniona elipsa (FillEllipse)";
            this.rbEllipse.UseVisualStyleBackColor = true;
            this.rbEllipse.CheckedChanged += new System.EventHandler(this.rbEllipse_CheckedChanged);
            // 
            // rbKwadrat
            // 
            this.rbKwadrat.AutoSize = true;
            this.rbKwadrat.Location = new System.Drawing.Point(215, 97);
            this.rbKwadrat.Name = "rbKwadrat";
            this.rbKwadrat.Size = new System.Drawing.Size(64, 17);
            this.rbKwadrat.TabIndex = 10;
            this.rbKwadrat.TabStop = true;
            this.rbKwadrat.Text = "Kwadrat";
            this.rbKwadrat.UseVisualStyleBackColor = true;
            // 
            // rbElipsa
            // 
            this.rbElipsa.AutoSize = true;
            this.rbElipsa.Location = new System.Drawing.Point(215, 74);
            this.rbElipsa.Name = "rbElipsa";
            this.rbElipsa.Size = new System.Drawing.Size(53, 17);
            this.rbElipsa.TabIndex = 9;
            this.rbElipsa.TabStop = true;
            this.rbElipsa.Text = "Elipsa";
            this.rbElipsa.UseVisualStyleBackColor = true;
            // 
            // rbProstokat
            // 
            this.rbProstokat.AutoSize = true;
            this.rbProstokat.Location = new System.Drawing.Point(215, 52);
            this.rbProstokat.Name = "rbProstokat";
            this.rbProstokat.Size = new System.Drawing.Size(70, 17);
            this.rbProstokat.TabIndex = 8;
            this.rbProstokat.TabStop = true;
            this.rbProstokat.Text = "Prostokąt";
            this.rbProstokat.UseVisualStyleBackColor = true;
            // 
            // rbLiniaProsta
            // 
            this.rbLiniaProsta.AutoSize = true;
            this.rbLiniaProsta.Location = new System.Drawing.Point(215, 29);
            this.rbLiniaProsta.Name = "rbLiniaProsta";
            this.rbLiniaProsta.Size = new System.Drawing.Size(79, 17);
            this.rbLiniaProsta.TabIndex = 7;
            this.rbLiniaProsta.TabStop = true;
            this.rbLiniaProsta.Text = "Linia prosta";
            this.rbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rbDrawPath
            // 
            this.rbDrawPath.AutoSize = true;
            this.rbDrawPath.Location = new System.Drawing.Point(6, 166);
            this.rbDrawPath.Name = "rbDrawPath";
            this.rbDrawPath.Size = new System.Drawing.Size(119, 17);
            this.rbDrawPath.TabIndex = 6;
            this.rbDrawPath.TabStop = true;
            this.rbDrawPath.Text = "Ścieżka (DrawPath)";
            this.rbDrawPath.UseVisualStyleBackColor = true;
            // 
            // rbClosedCurve
            // 
            this.rbClosedCurve.AutoSize = true;
            this.rbClosedCurve.Location = new System.Drawing.Point(6, 143);
            this.rbClosedCurve.Name = "rbClosedCurve";
            this.rbClosedCurve.Size = new System.Drawing.Size(205, 17);
            this.rbClosedCurve.TabIndex = 5;
            this.rbClosedCurve.TabStop = true;
            this.rbClosedCurve.Text = "Zamknięta krzywa (DrawClosedCurve)";
            this.rbClosedCurve.UseVisualStyleBackColor = true;
            // 
            // rbFillPie
            // 
            this.rbFillPie.AutoSize = true;
            this.rbFillPie.Location = new System.Drawing.Point(6, 120);
            this.rbFillPie.Name = "rbFillPie";
            this.rbFillPie.Size = new System.Drawing.Size(185, 17);
            this.rbFillPie.TabIndex = 4;
            this.rbFillPie.TabStop = true;
            this.rbFillPie.Text = "Wypełniony wycinek koła (FillPie)";
            this.rbFillPie.UseVisualStyleBackColor = true;
            // 
            // rbLiniaMysz
            // 
            this.rbLiniaMysz.AutoSize = true;
            this.rbLiniaMysz.Location = new System.Drawing.Point(6, 97);
            this.rbLiniaMysz.Name = "rbLiniaMysz";
            this.rbLiniaMysz.Size = new System.Drawing.Size(138, 17);
            this.rbLiniaMysz.TabIndex = 3;
            this.rbLiniaMysz.TabStop = true;
            this.rbLiniaMysz.Text = "Linia \"kreślona\" myszką";
            this.rbLiniaMysz.UseVisualStyleBackColor = true;
            // 
            // rbWielokatForemny
            // 
            this.rbWielokatForemny.AutoSize = true;
            this.rbWielokatForemny.Location = new System.Drawing.Point(6, 74);
            this.rbWielokatForemny.Name = "rbWielokatForemny";
            this.rbWielokatForemny.Size = new System.Drawing.Size(107, 17);
            this.rbWielokatForemny.TabIndex = 2;
            this.rbWielokatForemny.TabStop = true;
            this.rbWielokatForemny.Text = "Wielokąt foremny";
            this.rbWielokatForemny.UseVisualStyleBackColor = true;
            // 
            // rbOkrag
            // 
            this.rbOkrag.AutoSize = true;
            this.rbOkrag.Location = new System.Drawing.Point(6, 51);
            this.rbOkrag.Name = "rbOkrag";
            this.rbOkrag.Size = new System.Drawing.Size(54, 17);
            this.rbOkrag.TabIndex = 1;
            this.rbOkrag.TabStop = true;
            this.rbOkrag.Text = "Okrąg";
            this.rbOkrag.UseVisualStyleBackColor = true;
            // 
            // rbPunkt
            // 
            this.rbPunkt.AutoSize = true;
            this.rbPunkt.Location = new System.Drawing.Point(6, 29);
            this.rbPunkt.Name = "rbPunkt";
            this.rbPunkt.Size = new System.Drawing.Size(53, 17);
            this.rbPunkt.TabIndex = 0;
            this.rbPunkt.TabStop = true;
            this.rbPunkt.Text = "Punkt";
            this.rbPunkt.UseVisualStyleBackColor = true;
            // 
            // btnZmienLokalizacjeMysz
            // 
            this.btnZmienLokalizacjeMysz.Location = new System.Drawing.Point(1365, 525);
            this.btnZmienLokalizacjeMysz.Name = "btnZmienLokalizacjeMysz";
            this.btnZmienLokalizacjeMysz.Size = new System.Drawing.Size(167, 87);
            this.btnZmienLokalizacjeMysz.TabIndex = 16;
            this.btnZmienLokalizacjeMysz.Text = "Zmień losowo lokalizację figur geometrycznych kreślonych myszą";
            this.btnZmienLokalizacjeMysz.UseVisualStyleBackColor = true;
            this.btnZmienLokalizacjeMysz.Click += new System.EventHandler(this.BtnZmienLokalizacjeMysz_Click);
            // 
            // btnAtrybutyGraficzneMysz
            // 
            this.btnAtrybutyGraficzneMysz.Location = new System.Drawing.Point(1089, 523);
            this.btnAtrybutyGraficzneMysz.Name = "btnAtrybutyGraficzneMysz";
            this.btnAtrybutyGraficzneMysz.Size = new System.Drawing.Size(167, 89);
            this.btnAtrybutyGraficzneMysz.TabIndex = 17;
            this.btnAtrybutyGraficzneMysz.Text = "Zmień losowo atrybuty graficzne figur geometrycznych kreślonych myszą";
            this.btnAtrybutyGraficzneMysz.UseVisualStyleBackColor = true;
            this.btnAtrybutyGraficzneMysz.Click += new System.EventHandler(this.BtnAtrybutyGraficzneMysz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(931, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Współrzędne położenia myszy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(931, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "X";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(951, 23);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(931, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Y";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(951, 39);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 22;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1244, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Koniec kąta";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1092, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Początek kąta";
            this.label6.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1241, 475);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Koniec kąta";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1089, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Początek kąta";
            this.label12.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1092, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Liczba punktów do krzywej";
            this.label9.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1089, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Stopień wielokąta";
            this.label4.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1092, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Liczba punktów do ścieżki";
            this.label10.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1089, 475);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Początek kąta";
            this.label13.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1092, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Liczba punktów do ścieżki";
            this.label8.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1241, 475);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Koniec kąta";
            this.label14.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1092, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Liczba punktów do krzywej";
            this.label5.Visible = false;
            // 
            // txtStopieńWielokąta
            // 
            this.txtStopieńWielokąta.Location = new System.Drawing.Point(1092, 491);
            this.txtStopieńWielokąta.Name = "txtStopieńWielokąta";
            this.txtStopieńWielokąta.Size = new System.Drawing.Size(88, 20);
            this.txtStopieńWielokąta.TabIndex = 23;
            this.txtStopieńWielokąta.Visible = false;
            // 
            // txtKątKońcowy
            // 
            this.txtKątKońcowy.Location = new System.Drawing.Point(1244, 491);
            this.txtKątKońcowy.Name = "txtKątKońcowy";
            this.txtKątKońcowy.Size = new System.Drawing.Size(88, 20);
            this.txtKątKońcowy.TabIndex = 30;
            this.txtKątKońcowy.Visible = false;
            // 
            // txtKątKońcowyArc
            // 
            this.txtKątKońcowyArc.Location = new System.Drawing.Point(1244, 491);
            this.txtKątKońcowyArc.Name = "txtKątKońcowyArc";
            this.txtKątKońcowyArc.Size = new System.Drawing.Size(88, 20);
            this.txtKątKońcowyArc.TabIndex = 38;
            this.txtKątKońcowyArc.Visible = false;
            // 
            // txtKątKońcowyPie
            // 
            this.txtKątKońcowyPie.Location = new System.Drawing.Point(1244, 491);
            this.txtKątKońcowyPie.Name = "txtKątKońcowyPie";
            this.txtKątKońcowyPie.Size = new System.Drawing.Size(88, 20);
            this.txtKątKońcowyPie.TabIndex = 40;
            // 
            // txtLiczbaPunktowKrzywej
            // 
            this.txtLiczbaPunktowKrzywej.Location = new System.Drawing.Point(1092, 491);
            this.txtLiczbaPunktowKrzywej.Name = "txtLiczbaPunktowKrzywej";
            this.txtLiczbaPunktowKrzywej.Size = new System.Drawing.Size(88, 20);
            this.txtLiczbaPunktowKrzywej.TabIndex = 26;
            this.txtLiczbaPunktowKrzywej.Visible = false;
            // 
            // txtLiczbaPunktowSciezki
            // 
            this.txtLiczbaPunktowSciezki.Location = new System.Drawing.Point(1092, 491);
            this.txtLiczbaPunktowSciezki.Name = "txtLiczbaPunktowSciezki";
            this.txtLiczbaPunktowSciezki.Size = new System.Drawing.Size(88, 20);
            this.txtLiczbaPunktowSciezki.TabIndex = 32;
            this.txtLiczbaPunktowSciezki.Visible = false;
            // 
            // txtLiczbaPunktowKrzywejOtwartej
            // 
            this.txtLiczbaPunktowKrzywejOtwartej.Location = new System.Drawing.Point(1092, 491);
            this.txtLiczbaPunktowKrzywejOtwartej.Name = "txtLiczbaPunktowKrzywejOtwartej";
            this.txtLiczbaPunktowKrzywejOtwartej.Size = new System.Drawing.Size(88, 20);
            this.txtLiczbaPunktowKrzywejOtwartej.TabIndex = 34;
            this.txtLiczbaPunktowKrzywejOtwartej.Visible = false;
            // 
            // txtLiczbaPunktowDoSciezkiZamknietej
            // 
            this.txtLiczbaPunktowDoSciezkiZamknietej.Location = new System.Drawing.Point(1092, 491);
            this.txtLiczbaPunktowDoSciezkiZamknietej.Name = "txtLiczbaPunktowDoSciezkiZamknietej";
            this.txtLiczbaPunktowDoSciezkiZamknietej.Size = new System.Drawing.Size(88, 20);
            this.txtLiczbaPunktowDoSciezkiZamknietej.TabIndex = 36;
            this.txtLiczbaPunktowDoSciezkiZamknietej.Visible = false;
            // 
            // txtKątPoczątkowy
            // 
            this.txtKątPoczątkowy.Location = new System.Drawing.Point(1092, 491);
            this.txtKątPoczątkowy.Name = "txtKątPoczątkowy";
            this.txtKątPoczątkowy.Size = new System.Drawing.Size(88, 20);
            this.txtKątPoczątkowy.TabIndex = 28;
            this.txtKątPoczątkowy.Visible = false;
            // 
            // txtKątPoczątkowyArc
            // 
            this.txtKątPoczątkowyArc.Location = new System.Drawing.Point(1092, 491);
            this.txtKątPoczątkowyArc.Name = "txtKątPoczątkowyArc";
            this.txtKątPoczątkowyArc.Size = new System.Drawing.Size(88, 20);
            this.txtKątPoczątkowyArc.TabIndex = 37;
            this.txtKątPoczątkowyArc.Visible = false;
            // 
            // txtKątPoczątkowyPie
            // 
            this.txtKątPoczątkowyPie.Location = new System.Drawing.Point(1092, 491);
            this.txtKątPoczątkowyPie.Name = "txtKątPoczątkowyPie";
            this.txtKątPoczątkowyPie.Size = new System.Drawing.Size(88, 20);
            this.txtKątPoczątkowyPie.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 625);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtKątKońcowyPie);
            this.Controls.Add(this.txtKątPoczątkowyPie);
            this.Controls.Add(this.txtKątKońcowyArc);
            this.Controls.Add(this.txtKątPoczątkowyArc);
            this.Controls.Add(this.txtKątKońcowy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtrybutyGraficzneMysz);
            this.Controls.Add(this.btnZmienLokalizacjeMysz);
            this.Controls.Add(this.gbFiguraMysz);
            this.Controls.Add(this.chlbFiguryGeometryczne);
            this.Controls.Add(this.btnPoprzedni);
            this.Controls.Add(this.lblNumerFigury);
            this.Controls.Add(this.txtNumerFigury);
            this.Controls.Add(this.btnNastepny);
            this.Controls.Add(this.gbPokazFigur);
            this.Controls.Add(this.btnWylaczSlajder);
            this.Controls.Add(this.btnWlaczSlajder);
            this.Controls.Add(this.btnPrzesuńIZmieńAtrybutyGraficzne);
            this.Controls.Add(this.btnPrzesuńDoNowejLokalizacji);
            this.Controls.Add(this.btnWykreślFiguryGeometryczne);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.pbRysownica);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKątPoczątkowy);
            this.Controls.Add(this.txtLiczbaPunktowDoSciezkiZamknietej);
            this.Controls.Add(this.txtLiczbaPunktowKrzywejOtwartej);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLiczbaPunktowSciezki);
            this.Controls.Add(this.txtLiczbaPunktowKrzywej);
            this.Controls.Add(this.txtStopieńWielokąta);
            this.Controls.Add(this.label9);
            this.Name = "Form1";
            this.Text = "FiguryGeometryczne";
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            this.gbPokazFigur.ResumeLayout(false);
            this.gbPokazFigur.PerformLayout();
            this.gbFiguraMysz.ResumeLayout(false);
            this.gbFiguraMysz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnWykreślFiguryGeometryczne;
        private System.Windows.Forms.Button btnPrzesuńDoNowejLokalizacji;
        private System.Windows.Forms.Button btnPrzesuńIZmieńAtrybutyGraficzne;
        private System.Windows.Forms.Button btnWlaczSlajder;
        private System.Windows.Forms.Button btnWylaczSlajder;
        private System.Windows.Forms.GroupBox gbPokazFigur;
        private System.Windows.Forms.RadioButton rbManualny;
        private System.Windows.Forms.RadioButton rbAutomatyczny;
        private System.Windows.Forms.Button btnNastepny;
        private System.Windows.Forms.TextBox txtNumerFigury;
        private System.Windows.Forms.Label lblNumerFigury;
        private System.Windows.Forms.Button btnPoprzedni;
        private System.Windows.Forms.CheckedListBox chlbFiguryGeometryczne;
        private System.Windows.Forms.GroupBox gbFiguraMysz;
        private System.Windows.Forms.RadioButton rbDrawPie;
        private System.Windows.Forms.RadioButton rbDrawArc;
        private System.Windows.Forms.RadioButton rbFillPath;
        private System.Windows.Forms.RadioButton rbDrawCurve;
        private System.Windows.Forms.RadioButton rbEllipse;
        private System.Windows.Forms.RadioButton rbKwadrat;
        private System.Windows.Forms.RadioButton rbElipsa;
        private System.Windows.Forms.RadioButton rbProstokat;
        private System.Windows.Forms.RadioButton rbLiniaProsta;
        private System.Windows.Forms.RadioButton rbDrawPath;
        private System.Windows.Forms.RadioButton rbClosedCurve;
        private System.Windows.Forms.RadioButton rbFillPie;
        private System.Windows.Forms.RadioButton rbLiniaMysz;
        private System.Windows.Forms.RadioButton rbWielokatForemny;
        private System.Windows.Forms.RadioButton rbOkrag;
        private System.Windows.Forms.RadioButton rbPunkt;
        private System.Windows.Forms.Button btnZmienLokalizacjeMysz;
        private System.Windows.Forms.Button btnAtrybutyGraficzneMysz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKątKońcowyPie;
        private System.Windows.Forms.TextBox txtKątPoczątkowyPie;
        private System.Windows.Forms.TextBox txtKątKońcowyArc;
        private System.Windows.Forms.TextBox txtKątPoczątkowyArc;
        private System.Windows.Forms.TextBox txtKątKońcowy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKątPoczątkowy;
        private System.Windows.Forms.TextBox txtLiczbaPunktowDoSciezkiZamknietej;
        private System.Windows.Forms.TextBox txtLiczbaPunktowKrzywejOtwartej;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLiczbaPunktowSciezki;
        private System.Windows.Forms.TextBox txtLiczbaPunktowKrzywej;
        private System.Windows.Forms.TextBox txtStopieńWielokąta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdbRectangleFill;
    }
}

