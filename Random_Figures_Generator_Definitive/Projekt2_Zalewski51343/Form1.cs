using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Projekt2_Zalewski51343
{
    public partial class Form1 : Form
    {
        const int pzMargines = 20;
        int pzLicznikPunktówDoKrzywejZamkniętej = 0;
        int pzLicznikPunktówDoKrzywejOtwartej = 0;
        int pzLicznikPunktówDoŚcieżki = 0;
        int pzLicznikPunktówDoŚcieżkiZamkniętej = 0;
        int pzIndexTFG, pzXDoLiniiWykreślanejMyszą, pzYDoLiniiWykreślanejMyszą;
        ushort pzInterwałZegara = 1000;
        Graphics pzRysownica;
        Graphics pzRysownicaPomocnicza;
        Pen pzPióroPomocnicze;
        Brush pzPędzelPomocniczy;
        Punkt[] pzTFG;
        List<Punkt> pzLFG = new List<Punkt>();
        Point pzPunktStartu = Point.Empty;
        Point[] pzPunktyDoKrzywejZamkniętej = new Point[1000];
        Point[] pzPunktyDoKrzywejOtwartej = new Point[1000];
        Point[] pzPunktyDoŚcieżki = new Point[1000];
        Point[] pzPunktyDoŚcieżkiZamkniętej = new Point[1000];
        public Form1()
        {
            InitializeComponent();
            pbRysownica.BackColor = Color.Beige;
            pbRysownica.BorderStyle = BorderStyle.Fixed3D;
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            pzRysownica = Graphics.FromImage(pbRysownica.Image);
            pzRysownicaPomocnicza = this.pbRysownica.CreateGraphics();
            pzPióroPomocnicze = new Pen(Color.Blue, 1);
            pzPędzelPomocniczy = new SolidBrush(Color.Blue);
        }
        public class Punkt
        {
            protected const int pzPromieńPunktu = 20;
            protected int pzX, pzY;
            protected int pzGrubość;
            protected bool pzWidoczny;
            protected Color pzKolorTła;
            protected Color pzKolorLinii;
            protected DashStyle pzStylLinii;
            public virtual void PrzesuńDoNowegoXY(Control Kontrolka, Graphics PowierzchniaGraficzna, int x, int y)
            {
                this.pzX = x;
                this.pzY = y;
                Wykreśl(PowierzchniaGraficzna);
            }
            public virtual void PrzesuńDoNowegoXY(Control Kontrolka, Graphics PowierzchniaGraficzna, int x, int y, Color KolorLinii, Color KolorTła, DashStyle StylLinii)
            {
                this.pzX = x;
                this.pzY = y;
                this.pzKolorLinii = KolorLinii;
                this.pzKolorTła = KolorTła;
                this.pzStylLinii = StylLinii;
                Wykreśl(PowierzchniaGraficzna);
            }
            public Punkt(int x, int y)
            {
                pzX = x;
                pzY = y;
                pzKolorLinii = Color.Black;
                pzKolorTła = Color.Black;
                pzStylLinii = DashStyle.Solid;
                pzGrubość = pzPromieńPunktu;
                pzWidoczny = false;
            }
            public Punkt(int x, int y, Color KolorPunktu) : this(x, y)
            {
                pzKolorTła = KolorPunktu;
            }
            public Punkt(int x, int y, Color KolorPunktu, int RozmiarPunktu) : this(x, y, KolorPunktu)
            {
                pzGrubość = RozmiarPunktu;
            }
            void UstalAtrybutyGraficzne(Color KolorLinii, DashStyle StylLinii, int GrubośćLinii, Color KolorTła)
            {
                this.pzKolorLinii = KolorLinii;
                this.pzStylLinii = StylLinii;
                this.pzKolorTła = KolorTła;
                pzGrubość = GrubośćLinii;
            }
            public virtual void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                SolidBrush Pędzel = new SolidBrush(pzKolorTła);
                PowierzchniaGraficzna.FillEllipse(Pędzel, pzX - pzGrubość / 2, pzY - pzGrubość / 2, pzGrubość, pzGrubość);
                pzWidoczny = true;
                Pędzel.Dispose();
            }
            public virtual void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (pzWidoczny)
                {
                    SolidBrush Pędzel = new SolidBrush(Kontrolka.BackColor);
                    PowierzchniaGraficzna.FillEllipse(Pędzel, pzX - pzGrubość / 2, pzY - pzGrubość / 2, pzGrubość, pzGrubość);
                    pzWidoczny = false;
                    Pędzel.Dispose();
                }
            }
        }
        public class Linia : Punkt
        {
            int pzXk, pzYk;
            public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(Xp, Yp, KolorLinii, GrubośćLinii)
            {
                this.pzXk = Xk;
                this.pzYk = Yk;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(base.pzKolorTła, base.pzGrubość);
                Pióro.DashStyle = base.pzStylLinii;
                base.Wykreśl(PowierzchniaGraficzna);
                PowierzchniaGraficzna.DrawLine(Pióro, base.pzX, base.pzY, pzXk, pzYk);
                pzWidoczny = true;
                Pióro.Dispose();
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (pzWidoczny)
                {
                    Pen Pióro = new Pen(Kontrolka.BackColor, base.pzGrubość);
                    Pióro.DashStyle = base.pzStylLinii;
                    PowierzchniaGraficzna.DrawLine(Pióro, base.pzX, base.pzY, pzXk, pzYk);
                    pzWidoczny = false;
                    Pióro.Dispose();
                }
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics PowierzchniaGraficzna, int x, int y)
            {
                int dx, dy;
                if (x > pzX)
                {
                    dx = x - pzX;
                }
                else
                {
                    dx = pzX - x;
                }
                if (y > pzY)
                {
                    dy = y - pzY;
                }
                else
                {
                    dy = pzY - y;
                }
                pzX = x;
                pzY = y;
                pzXk = (pzXk + dx) % Kontrolka.Width;
                pzYk = (pzYk + dy) % Kontrolka.Height;
                Wykreśl(PowierzchniaGraficzna);
            }
        }
        public class Elipsa : Punkt
        {
            protected int OśDuża, OśMała;
            public Elipsa(int x, int y, int OśDuża, int OśMała) : base(x, y)
            {
                this.OśDuża = OśDuża;
                this.OśMała = OśMała;
            }
            public Elipsa(int x, int y, int OśDuża, int OśMała, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
            {
                this.OśDuża = OśDuża;
                this.OśMała = OśMała;
                base.pzStylLinii = StylLinii;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(pzKolorTła, pzGrubość))
                {
                    Pióro.DashStyle = pzStylLinii;
                    PowierzchniaGraficzna.DrawEllipse(Pióro, pzX, pzY, OśDuża, OśMała);
                    pzWidoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, pzGrubość))
                    {
                        Pióro.DashStyle = pzStylLinii;
                        PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - OśMała, pzY - OśMała, 2 * OśDuża, 2 * OśDuża);
                        pzWidoczny = false;
                    }
                }
            }
        }
        public class Okrąg : Elipsa
        {
            protected int Promień;
            public Okrąg(int x, int y, int Promień) : base(x, y, 2 * Promień, 2 * Promień)
            {
                this.Promień = Promień;
            }
            public Okrąg(int x, int y, int Promień, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, 2 * Promień, 2 * Promień, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.Promień = Promień;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(pzKolorTła, pzGrubość))
                {
                    Pióro.DashStyle = pzStylLinii;
                    PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - Promień, pzY - Promień, 2 * Promień, 2 * Promień);
                    pzWidoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, pzGrubość))
                    {
                        Pióro.DashStyle = pzStylLinii;
                        PowierzchniaGraficzna.DrawEllipse(Pióro, pzX - Promień, pzY - Promień, 2 * Promień, 2 * Promień);
                        pzWidoczny = false;
                    }
                }
            }
        }
        public class FillEllipse : Elipsa
        {
            public FillEllipse(int x, int y, int OśDuża, int OśMała) : base(x, y, OśDuża, OśMała)
            {

            }
            public FillEllipse(int x, int y, int OśDuża, int OśMała, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, OśDuża, OśMała, KolorLinii, StylLinii, GrubośćLinii)
            {

            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Brush Pędzel = new SolidBrush(pzKolorTła))
                {
                    PowierzchniaGraficzna.FillEllipse(Pędzel, pzX, pzY, OśDuża, OśMała);
                    pzWidoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    using (Brush Pędzel = new SolidBrush(Kontrolka.BackColor))
                    {
                        PowierzchniaGraficzna.FillEllipse(Pędzel, pzX, pzY, OśDuża, OśMała);
                        pzWidoczny = false;
                    }
                }
            }
        }
        public class Prostokąt : Punkt
        {
            protected int BokX;
            protected int BokY;
            public Prostokąt(int x, int y, int BokX, int BokY) : base(x, y)
            {
                this.BokX = BokX;
                this.BokY = BokY;
            }
            public Prostokąt(int x, int y, int BokX, int BokY, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
            {
                this.BokX = BokX;
                this.BokY = BokY;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(pzKolorTła, pzGrubość);
                Pióro.DashStyle = pzStylLinii;
                PowierzchniaGraficzna.DrawRectangle(Pióro, pzX, pzY, BokX, BokY);
                pzWidoczny = true;
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, pzGrubość))
                    {
                        Pióro.DashStyle = pzStylLinii;
                        PowierzchniaGraficzna.DrawRectangle(Pióro, pzX, pzY, BokX, BokY);
                        pzWidoczny = false;
                    }
                }
            }
        }
       
        public class WielokątForemny : Punkt
        {
            protected int PromieńOkręgu;
            protected int StopieńWielokąta;
            protected Point[] TablicaWierzchołkówWielokąta;
            protected float KątPołożeniaPierwszegoWierzchołka;
            public WielokątForemny(int StopieńWielokąta, int x, int y, int PromieńOkręgu) : base(x, y)
            {
                this.PromieńOkręgu = PromieńOkręgu;
                this.StopieńWielokąta = StopieńWielokąta;
                this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    TablicaWierzchołkówWielokąta[i] = new Point();
                }
            }
            public WielokątForemny(int StopieńWielokąta, int x, int y, int PromieńOkręgu, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii)
            {
                this.PromieńOkręgu = PromieńOkręgu;
                this.StopieńWielokąta = StopieńWielokąta;
                this.pzX = x;
                this.pzY = y;
                this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                base.pzStylLinii = StylLinii;
                base.pzGrubość = GrubośćLinii;
                TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    TablicaWierzchołkówWielokąta[i] = new Point();
                }
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                using (Pen Pióro = new Pen(pzKolorLinii, pzGrubość))
                {
                    Pióro.DashStyle = pzStylLinii;
                    float KąpziędzyWierzchołkami = 360F / StopieńWielokąta;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i].X = (int)(pzX + PromieńOkręgu * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KąpziędzyWierzchołkami) / 180));
                        TablicaWierzchołkówWielokąta[i].Y = (int)(pzY - PromieńOkręgu * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KąpziędzyWierzchołkami) / 180));
                    }
                    for (int i = 0; i < this.StopieńWielokąta; i++)
                    {
                        PowierzchniaGraficzna.DrawLine(Pióro, TablicaWierzchołkówWielokąta[i].X, TablicaWierzchołkówWielokąta[i].Y, TablicaWierzchołkówWielokąta[i + 1].X, TablicaWierzchołkówWielokąta[i + 1].Y);
                    }
                    pzWidoczny = true;
                }
            }
        }
        public class Kwadrat : Punkt
        {
            protected int Bok;
            public Kwadrat(int x, int y, int Bok) : base(x, y)
            {
                this.Bok = Bok;
            }
            public Kwadrat(int x, int y, int Bok, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
            {
                this.Bok = Bok;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(pzKolorTła, pzGrubość);
                Pióro.DashStyle = pzStylLinii;
                PowierzchniaGraficzna.DrawRectangle(Pióro, pzX, pzY, Bok, Bok);
                pzWidoczny = true;
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, pzGrubość))
                    {
                        Pióro.DashStyle = pzStylLinii;
                        PowierzchniaGraficzna.DrawRectangle(Pióro, pzX, pzY, Bok, Bok);
                        pzWidoczny = false;
                    }
                }
            }
        }
        public class FillPie : Punkt
        {
            protected int KątPoczątkowy;
            protected int KątKońcowy;
            protected int Szerokość;
            protected int Wysokość;
            public FillPie(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy) : base(x, y)
            {
                this.KątPoczątkowy = KątPoczątkowy;
                this.KątKońcowy = KątKońcowy;
                this.Szerokość = Szerokość;
                this.Wysokość = Wysokość;
            }
            public FillPie(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
            {
                this.KątPoczątkowy = KątPoczątkowy;
                this.KątKońcowy = KątKońcowy;
                this.Szerokość = Szerokość;
                this.Wysokość = Wysokość;
            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(pzKolorTła, pzGrubość);
                Brush Pędzel = new SolidBrush(pzKolorTła);
                PowierzchniaGraficzna.DrawEllipse(Pióro, new Rectangle(pzX, pzY, Szerokość, Szerokość));
                PowierzchniaGraficzna.FillPie(Pędzel, new Rectangle(pzX, pzY, Szerokość, Szerokość), KątPoczątkowy, KątKońcowy);
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    Pen Pióro = new Pen(Kontrolka.BackColor);
                    Brush Pędzel = new SolidBrush(Kontrolka.BackColor);
                    PowierzchniaGraficzna.DrawEllipse(Pióro, new Rectangle(pzX, pzY, Szerokość, Szerokość));
                    PowierzchniaGraficzna.FillPie(Pędzel, new Rectangle(pzX, pzY, Szerokość, Szerokość), KątPoczątkowy, KątKońcowy);
                    pzWidoczny = false;
                }
            }
        }
        
        public class DrawPie : FillPie
        {
            public DrawPie(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy) : base(x, y, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy)
            {

            }
            public DrawPie(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, GrubośćLinii)
            {

            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(pzKolorTła, pzGrubość);
                Pióro.DashStyle = pzStylLinii;
                PowierzchniaGraficzna.DrawPie(Pióro, new Rectangle(pzX, pzY, Szerokość, Szerokość), KątPoczątkowy, KątKońcowy);
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    Pen Pióro = new Pen(Kontrolka.BackColor, pzGrubość);
                    Pióro.DashStyle = pzStylLinii;
                    PowierzchniaGraficzna.DrawPie(Pióro, new Rectangle(pzX, pzY, Szerokość, Szerokość), KątPoczątkowy, KątKońcowy);
                }
            }
        }
        public class DrawArc : FillPie
        {
            public DrawArc(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy) : base(x, y, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy)
            {

            }
            public DrawArc(int x, int y, int Szerokość, int Wysokość, int KątPoczątkowy, int KątKońcowy, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) : base(x, y, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, GrubośćLinii)
            {

            }
            public override void Wykreśl(Graphics PowierzchniaGraficzna)
            {
                Pen Pióro = new Pen(pzKolorTła, pzGrubość);
                Pióro.DashStyle = pzStylLinii;
                PowierzchniaGraficzna.DrawArc(Pióro, new Rectangle(pzX, pzY, Szerokość, Wysokość), KątPoczątkowy, KątKońcowy);
            }
            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
            {
                if (this.pzWidoczny)
                {
                    Pen Pióro = new Pen(Kontrolka.BackColor);
                    Pióro.DashStyle = pzStylLinii;
                    PowierzchniaGraficzna.DrawArc(Pióro, new Rectangle(pzX, pzY, Szerokość, Wysokość), KątPoczątkowy, KątKońcowy);
                    pzWidoczny = false;
                }
            }
        }
        public void Wykreślanie(Graphics PowierzchniaGraficzna)
        {
            if (chlbFiguryGeometryczne.SelectedItems.Count <= 0)
            {
                errorProvider1.SetError(chlbFiguryGeometryczne, "Musisz wybrać figury geometryczne do wizualizacji.");
                return;
            }
            ushort N;
            while ((!ushort.TryParse(txtN.Text, out N)) || (N <= 0))
            {
                errorProvider1.SetError(txtN, "Musisz podać liczbę figur lub wystąpił niedozwolony znak.");
                return;
            }
            errorProvider1.Dispose();
            btnPrzesuńDoNowejLokalizacji.Enabled = true;
            btnPrzesuńIZmieńAtrybutyGraficzne.Enabled = true;
            btnWlaczSlajder.Enabled = true;
            chlbFiguryGeometryczne.Enabled = false;
            txtN.Enabled = false;
            pzTFG = new Punkt[N];
            pzIndexTFG = 0;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            int GrubośćLinii, Xp, Yp;
            Color KolorLinii;
            Color KolorTła;
            DashStyle StylLinii;
            Random LiczbaLosowa = new Random();
            CheckedListBox.CheckedItemCollection WybraneFigury = chlbFiguryGeometryczne.CheckedItems;
            for (int i = 0; i < N; i++)
            {
                Xp = LiczbaLosowa.Next(pzMargines, Xmax - pzMargines);
                Yp = LiczbaLosowa.Next(pzMargines, Ymax - pzMargines);
                KolorLinii = Color.FromArgb(LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255));
                KolorTła = Color.FromArgb(LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255), LiczbaLosowa.Next(0, 255));
                switch (LiczbaLosowa.Next(1, 6))
                {
                    case 1: StylLinii = DashStyle.Dash;
                        break;
                    case 2: StylLinii = DashStyle.DashDot;
                        break;
                    case 3: StylLinii = DashStyle.DashDotDot;
                        break;
                    case 4: StylLinii = DashStyle.Dot;
                        break;
                    case 5: StylLinii = DashStyle.Solid;
                        break;
                    default: StylLinii = DashStyle.Solid;
                        break;
                }
                int OśDuża = LiczbaLosowa.Next(pzMargines, Xmax / 4 - pzMargines);
                int OśMała = LiczbaLosowa.Next(pzMargines, Ymax / 4 - pzMargines);
                int Szerokość = LiczbaLosowa.Next(pzMargines, Xmax / 4 - pzMargines);
                int Wysokość = LiczbaLosowa.Next(pzMargines, Ymax / 4 - pzMargines);
                int KątPoczątkowy = LiczbaLosowa.Next(0, 360);
                int KątKońcowy = LiczbaLosowa.Next(0, 360);
                GrubośćLinii = LiczbaLosowa.Next(1, 10);
                string WylosowanaFigura = WybraneFigury[LiczbaLosowa.Next(WybraneFigury.Count)].ToString();
                switch (WylosowanaFigura)
                {
                    case "Punkt":
                        pzTFG[pzIndexTFG] = new Punkt(Xp, Yp, KolorLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Linia":
                        int Xk = LiczbaLosowa.Next(pzMargines, Xmax - pzMargines);
                        int Yk = LiczbaLosowa.Next(pzMargines, Ymax - pzMargines);
                        pzTFG[pzIndexTFG] = new Linia(Xp, Yp, Xk, Yk, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Elipsa":
                        pzTFG[pzIndexTFG] = new Elipsa(Xp, Yp, OśDuża, OśMała, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Okrąg":
                        int Promień = LiczbaLosowa.Next(pzMargines, Ymax / 4);
                        pzTFG[pzIndexTFG] = new Okrąg(Xp, Yp, Promień, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Wielokąt":
                        int ROkręgu = LiczbaLosowa.Next(1, Ymax / 3);
                        int StopieńWielokąta = LiczbaLosowa.Next(3, 21);
                        pzTFG[pzIndexTFG] = new WielokątForemny(StopieńWielokąta, Xp, Yp, ROkręgu, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Kwadrat":
                        int Bok = LiczbaLosowa.Next(pzMargines, Ymax / 4);
                        pzTFG[pzIndexTFG] = new Kwadrat(Xp, Yp, Bok, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Prostokąt":
                        int BokX = LiczbaLosowa.Next(pzMargines, Xmax / 4 - pzMargines);
                        int BokY = LiczbaLosowa.Next(pzMargines, Ymax / 4 - pzMargines);
                        pzTFG[pzIndexTFG] = new Prostokąt(Xp, Yp, BokX, BokY, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Wypełniony wycinek koła":
                        pzTFG[pzIndexTFG] = new FillPie(Xp, Yp, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Wypełniona elipsa":
                        pzTFG[pzIndexTFG] = new FillEllipse(Xp, Yp, OśDuża, OśMała, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Łuk":
                        pzTFG[pzIndexTFG] = new DrawArc(Xp, Yp, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    case "Wycinek koła":
                        pzTFG[pzIndexTFG] = new DrawPie(Xp, Yp, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, GrubośćLinii);
                        pzTFG[pzIndexTFG].Wykreśl(pzRysownica);
                        pzIndexTFG++;
                        break;
                    default:
                        errorProvider1.SetError(btnWykreślFiguryGeometryczne, "Proszę wybrać figurę.");
                        return;
                }
            }
            pbRysownica.Refresh();
            btnWykreślFiguryGeometryczne.Enabled = false;
        }
        private void BtnWykreślFiguryGeometryczne_Click(object sender, EventArgs e)
        {
            Wykreślanie(pzRysownica);
        }
        private void BtnPrzesuńDoNowejLokalizacji_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int Xp, Yp;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            Random LosowaLiczba = new Random();
            for (int i = 0; i < pzTFG.Length; i++)
            {
                Xp = LosowaLiczba.Next(pzMargines, Xmax - pzMargines);
                Yp = LosowaLiczba.Next(pzMargines, Ymax - pzMargines);
                pzTFG[i].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xp, Yp);
            }
            pbRysownica.Refresh();
        }
        private void BtnPrzesuńIZmieńAtrybutyGraficzne_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int Xp, Yp;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            Color KolorLinii, KolorTła;
            DashStyle StylLinii;
            Random LosowaLiczba = new Random();
            for (int i = 0; i < pzTFG.Length; i++)
            {
                KolorLinii = Color.FromArgb(LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255));
                KolorTła = Color.FromArgb(LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255));
                switch (LosowaLiczba.Next(1, 6))
                {
                    case 1: StylLinii = DashStyle.Dash;
                        break;
                    case 2: StylLinii = DashStyle.DashDot;
                        break;
                    case 3: StylLinii = DashStyle.DashDotDot;
                        break;
                    case 4: StylLinii = DashStyle.Dot;
                        break;
                    case 5: StylLinii = DashStyle.Solid;
                        break;
                    default: StylLinii = DashStyle.Solid;
                        break;
                }
                Xp = LosowaLiczba.Next(pzMargines, Xmax - pzMargines);
                Yp = LosowaLiczba.Next(pzMargines, Ymax - pzMargines);
                pzTFG[i].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xp, Yp, KolorLinii, KolorTła, StylLinii);
            }
            pbRysownica.Refresh();
        }
        private void BtnZmienLokalizacjeMysz_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int Xp, Yp;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            Random LosowaLiczba = new Random();
            for (int i = 0; i < pzLFG.Count; i++)
            {
                Xp = LosowaLiczba.Next(pzMargines, Xmax - pzMargines);
                Yp = LosowaLiczba.Next(pzMargines, Ymax - pzMargines);
                pzLFG[i].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xp, Yp);
            }
            pbRysownica.Refresh();
        }
        private void BtnAtrybutyGraficzneMysz_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int Xp, Yp;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            Color KolorLinii, KolorTła;
            DashStyle StylLinii;
            Random LosowaLiczba = new Random();
            for (int i = 0; i < pzLFG.Count; i++)
            {
                KolorLinii = Color.FromArgb(LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255));
                KolorTła = Color.FromArgb(LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255), LosowaLiczba.Next(0, 255));
                switch (LosowaLiczba.Next(1, 6))
                {
                    case 1:
                        StylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        StylLinii = DashStyle.DashDot;
                        break;
                    case 3:
                        StylLinii = DashStyle.DashDotDot;
                        break;
                    case 4:
                        StylLinii = DashStyle.Dot;
                        break;
                    case 5:
                        StylLinii = DashStyle.Solid;
                        break;
                    default:
                        StylLinii = DashStyle.Solid;
                        break;
                }
                Xp = LosowaLiczba.Next(pzMargines, Xmax - pzMargines);
                Yp = LosowaLiczba.Next(pzMargines, Ymax - pzMargines);
                pzLFG[i].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xp, Yp, KolorLinii, KolorTła, StylLinii);
            }
            pbRysownica.Refresh();
        }
        private void BtnWlaczSlajder_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            if (rbAutomatyczny.Checked)
            {
                timer1.Tag = 0;
                timer1.Interval = pzInterwałZegara;
                timer1.Enabled = true;
                txtNumerFigury.Text = "0";
                rbAutomatyczny.Enabled = false;
                rbManualny.Enabled = false;
                btnWlaczSlajder.Enabled = false;
                btnWylaczSlajder.Enabled = true;
            }
            else
            if (rbManualny.Checked)
            {
                int IndeksFigury;
                if (string.IsNullOrEmpty(txtNumerFigury.Text.Trim()))
                    txtNumerFigury.Text = "0";
                else
                {
                    if (!int.TryParse(txtNumerFigury.Text, out IndeksFigury))
                    {
                        errorProvider1.SetError(txtNumerFigury, "Proszę wpisać poprawny numer figury.");
                        return;
                    }
                    if ((IndeksFigury < 0) || (IndeksFigury >= (pzTFG.Length)))
                    {
                        errorProvider1.SetError(txtNumerFigury, "Wpisany numer wykracza poza tablicę.");
                        return;
                    }
                    int Ymax = pbRysownica.Width;
                    int Xmax = pbRysownica.Height;
                    pzTFG[IndeksFigury].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xmax / 2, Ymax / 2);
                    txtNumerFigury.ReadOnly = true;
                    btnNastepny.Enabled = true;
                    btnPoprzedni.Enabled = true;
                    btnWlaczSlajder.Enabled = false;
                    btnWylaczSlajder.Enabled = true;
                    rbAutomatyczny.Enabled = false;
                    rbManualny.Enabled = false;
                    pbRysownica.Refresh();
                }
                errorProvider1.Dispose();
            }
            else
            {
                errorProvider1.SetError(gbPokazFigur, "Proszę wybrać sposób wyświetlania figur.");
                return;
            }
            errorProvider1.Dispose();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            txtNumerFigury.Text = timer1.Tag.ToString();
            pzTFG[(int)timer1.Tag].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xmax / 2, Ymax / 2);
            timer1.Tag = (int.Parse(timer1.Tag.ToString()) + 1) % pzTFG.Length;
            pbRysownica.Refresh();
        }
        private void BtnNastepny_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int IndeksFigury;
            IndeksFigury = int.Parse(txtNumerFigury.Text);
            pzTFG[IndeksFigury].Wymaż(pbRysownica, pzRysownica);
            if (IndeksFigury < (pzTFG.Length - 1))
                IndeksFigury++;
            else
                IndeksFigury = 0;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            pzTFG[IndeksFigury].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xmax / 2, Ymax / 2);
            txtNumerFigury.Text = IndeksFigury.ToString();
            pbRysownica.Refresh();
        }
        private void BtnPoprzedni_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            int IndeksFigury;
            IndeksFigury = int.Parse(txtNumerFigury.Text);
            pzTFG[IndeksFigury].Wymaż(pbRysownica, pzRysownica);
            if (IndeksFigury > 0)
                IndeksFigury--;
            else
                IndeksFigury = pzTFG.Length - 1;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            pzTFG[IndeksFigury].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xmax / 2, Ymax / 2);
            txtNumerFigury.Text = IndeksFigury.ToString();
            pbRysownica.Refresh();
        }
        private void BtnWylaczSlajder_Click(object sender, EventArgs e)
        {
            pzRysownica.Clear(pbRysownica.BackColor);
            timer1.Enabled = false;
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            int Xp, Yp;
            Random LiczbaLosowa = new Random();
            for (int i = 0; i < pzTFG.Length; i++)
            {
                Xp = LiczbaLosowa.Next(pzMargines, Xmax - pzMargines);
                Yp = LiczbaLosowa.Next(pzMargines, Ymax - pzMargines);
                pzTFG[i].PrzesuńDoNowegoXY(pbRysownica, pzRysownica, Xp, Yp);
            }
            pbRysownica.Refresh();
            txtNumerFigury.ReadOnly = false;
            btnWylaczSlajder.Enabled = false;
            btnWlaczSlajder.Enabled = true;
            btnNastepny.Enabled = false;
            btnPoprzedni.Enabled = false;
            rbAutomatyczny.Enabled = true;
            rbManualny.Enabled = true;
        }
        private void TxtNumerFigury_TextChanged(object sender, EventArgs e)
        {
            ushort IndeksFigury;
            if (!ushort.TryParse(txtNumerFigury.Text, out IndeksFigury))
            {
                errorProvider1.SetError(txtNumerFigury, "Proszę wpisać poprawny numer figury.");
                return;
            }
            if ((IndeksFigury < 0) || (IndeksFigury >= (pzTFG.Length)))
            {
                errorProvider1.SetError(txtNumerFigury, "Wpisany numer wykracza poza tablicę.");
                return;
            }
            errorProvider1.Dispose();
        }
        private void PbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {
                pzPunktStartu = e.Location;
            }
        }

        //rdbRectangleFill
        private void PbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            int LewyGórnyNarożnikX = (pzPunktStartu.X > e.Location.X) ? e.Location.X : pzPunktStartu.X;
            int LewyGórnyNarożnikY = (pzPunktStartu.Y > e.Location.Y) ? e.Location.Y : pzPunktStartu.Y;
            int Szerokość = Math.Abs(pzPunktStartu.X - e.Location.X);
            int Wysokość = Math.Abs(pzPunktStartu.Y - e.Location.Y);
            if (e.Button == MouseButtons.Left)
            {
                Pen Pióro = new Pen(Color.Black, 10);
                ushort PromieńPunktu = 10;
                Color KolorLinii = Color.Black;
                DashStyle StylLinii = DashStyle.Solid;
                if (rbPunkt.Checked)
                {
                    Color KolorPunktu = Color.Black;
                    pzRysownica.FillEllipse(Brushes.Black, e.Location.X, e.Location.Y, PromieńPunktu, PromieńPunktu);
                    pzLFG.Add(new Punkt(pzPunktStartu.X, pzPunktStartu.Y, KolorPunktu, PromieńPunktu));
                }
                else if (rbLiniaProsta.Checked)
                {
                    pzRysownica.DrawLine(Pióro, pzPunktStartu, e.Location);
                    pzLFG.Add(new Linia(LewyGórnyNarożnikX, LewyGórnyNarożnikY, e.Location.X, e.Location.Y, KolorLinii, StylLinii, PromieńPunktu));
                }
                else if (rbElipsa.Checked)
                {
                    pzRysownica.DrawEllipse(Pióro, LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość);
                    pzLFG.Add(new Elipsa(LewyGórnyNarożnikX - Szerokość / 2, LewyGórnyNarożnikY - Szerokość / 2, Szerokość, Wysokość, KolorLinii, StylLinii, PromieńPunktu));
                }
                else if (rbOkrag.Checked)
                {
                    pzRysownica.DrawEllipse(Pióro, LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość);
                    pzLFG.Add(new Okrąg(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość/2, KolorLinii, StylLinii, PromieńPunktu));
                }
                else if (rbWielokatForemny.Checked)
                {
                    int StopieńWielokąta;
                    if (!int.TryParse(txtStopieńWielokąta.Text, out StopieńWielokąta) || StopieńWielokąta < 3)
                    {
                        errorProvider1.SetError(txtStopieńWielokąta, "Proszę wpisać poprawny stopień wielokąta (większy lub równy 3).");
                        return;
                    }
                    errorProvider1.Dispose();
                    Point[] TablicaWierzchołkówWielokąta;
                    TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i] = new Point();
                    }
                    float KąpziędzyWierzchołkami = 360F / StopieńWielokąta;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i].X = (int)(e.Location.X + (Szerokość+Wysokość) * Math.Cos(Math.PI * (0 + i * KąpziędzyWierzchołkami) / 180));
                        TablicaWierzchołkówWielokąta[i].Y = (int)(e.Location.Y - (Wysokość+Szerokość) * Math.Sin(Math.PI * (0 + i * KąpziędzyWierzchołkami) / 180));
                    }
                    pzRysownica.DrawPolygon(Pióro, TablicaWierzchołkówWielokąta);
                    pzLFG.Add(new WielokątForemny(StopieńWielokąta, e.Location.X, e.Location.Y, Szerokość+Wysokość, KolorLinii, StylLinii, PromieńPunktu));
                }
                else if (rbLiniaMysz.Checked)
                {

                }
                else if (rbFillPie.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowy.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 360)
                    {
                        errorProvider1.SetError(txtKątPoczątkowy, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 360.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowy.Text, out KątKońcowy) || KątKońcowy < 0 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowy, "Proszę wpisać poprawny kąt końcowy z przedziału od 0 do 360.");
                        return;
                    }
                    errorProvider1.Dispose();
                    Brush Pędzel = new SolidBrush(Color.Black);
                    pzRysownica.DrawEllipse(Pióro, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość));
                    pzRysownica.FillPie(Pędzel, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość), KątPoczątkowy, KątKońcowy);
                    pzLFG.Add(new FillPie(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość, KątPoczątkowy, KątKońcowy, KolorLinii, StylLinii, PromieńPunktu));
                }
                else if(rbClosedCurve.Checked)
                {
                    int LiczbaPunktówKrzywej;
                    if (!int.TryParse(txtLiczbaPunktowKrzywej.Text, out LiczbaPunktówKrzywej) || LiczbaPunktówKrzywej < 3)
                    {
                        errorProvider1.SetError(txtLiczbaPunktowKrzywej, "Proszę wpisać poprawną liczbę punktów (większą lub równą 3).");
                        return;
                    }
                    errorProvider1.Dispose();
                    txtLiczbaPunktowKrzywej.Enabled = false;
                    pzPunktyDoKrzywejZamkniętej[pzLicznikPunktówDoKrzywejZamkniętej] = new Point(e.X, e.Y);
                    pzRysownica.FillEllipse(Brushes.Black, e.Location.X - PromieńPunktu, e.Location.Y - PromieńPunktu, PromieńPunktu + PromieńPunktu, PromieńPunktu + PromieńPunktu);
                    pzLicznikPunktówDoKrzywejZamkniętej++;
                    if (pzLicznikPunktówDoKrzywejZamkniętej == LiczbaPunktówKrzywej)
                    {
                        Point[] NowePunktyDoKrzywej = new Point[pzLicznikPunktówDoKrzywejZamkniętej];
                        Array.Copy(pzPunktyDoKrzywejZamkniętej, NowePunktyDoKrzywej, pzLicznikPunktówDoKrzywejZamkniętej);
                        pzRysownica.DrawClosedCurve(Pióro, NowePunktyDoKrzywej);
                        pzLicznikPunktówDoKrzywejZamkniętej = 0;
                        Array.Clear(pzPunktyDoKrzywejZamkniętej, 0, 1000);
                        txtLiczbaPunktowKrzywej.Enabled = true;
                    }
                }
                else if (rbDrawPath.Checked)
                {
                    int LiczbaPunktówŚcieżki;
                    if (!int.TryParse(txtLiczbaPunktowSciezki.Text, out LiczbaPunktówŚcieżki) || LiczbaPunktówŚcieżki < 3)
                    {
                        errorProvider1.SetError(txtLiczbaPunktowSciezki, "Proszę wpisać poprawną liczbę punktów (większą lub równą 3).");
                        return;
                    }
                    errorProvider1.Dispose();
                    txtLiczbaPunktowSciezki.Enabled = false;
                    pzPunktyDoŚcieżki[pzLicznikPunktówDoŚcieżki] = new Point(e.X, e.Y);
                    pzRysownica.FillEllipse(Brushes.Black, e.Location.X - PromieńPunktu, e.Location.Y - PromieńPunktu, PromieńPunktu + PromieńPunktu, PromieńPunktu + PromieńPunktu);
                    pzLicznikPunktówDoŚcieżki++;
                    if (pzLicznikPunktówDoŚcieżki == LiczbaPunktówŚcieżki)
                    {
                        Point[] NowePunktyDoKrzywej = new Point[pzLicznikPunktówDoŚcieżki];
                        Array.Copy(pzPunktyDoŚcieżki, NowePunktyDoKrzywej, pzLicznikPunktówDoŚcieżki);
                        GraphicsPath Ścieżka = new GraphicsPath();
                        Ścieżka.AddPolygon(NowePunktyDoKrzywej);
                        pzRysownica.DrawPath(Pióro, Ścieżka);
                        pzLicznikPunktówDoŚcieżki = 0;
                        Array.Clear(pzPunktyDoŚcieżki, 0, 1000);
                        txtLiczbaPunktowSciezki.Enabled = true;
                    }
                }
                else if (rdbRectangleFill.Checked)
                {
                    pzRysownica.FillRectangle(Brushes.Black, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                    pzLFG.Add(new Prostokąt(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else if (rbProstokat.Checked)
                {
                    pzRysownica.DrawRectangle(Pióro, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                    pzLFG.Add(new Prostokąt(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else if (rbKwadrat.Checked)
                {
                    pzRysownica.DrawRectangle(Pióro, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość));
                    pzLFG.Add(new Kwadrat(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość));
                }
                else if (rbEllipse.Checked)
                {
                    Brush Pędzel = new SolidBrush(Color.Black);
                    pzRysownica.FillEllipse(Pędzel, LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość);
                    pzLFG.Add(new FillEllipse(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else if (rbDrawCurve.Checked)
                {
                    int LiczbaPunktówKrzywej;
                    if (!int.TryParse(txtLiczbaPunktowKrzywejOtwartej.Text, out LiczbaPunktówKrzywej) || LiczbaPunktówKrzywej < 3)
                    {
                        errorProvider1.SetError(txtLiczbaPunktowKrzywejOtwartej, "Proszę wpisać poprawną liczbę punktów (większą lub równą 3).");
                        return;
                    }
                    errorProvider1.Dispose();
                    txtLiczbaPunktowKrzywejOtwartej.Enabled = false;
                    pzPunktyDoKrzywejOtwartej[pzLicznikPunktówDoKrzywejOtwartej] = new Point(e.X, e.Y);
                    pzRysownica.FillEllipse(Brushes.Black, e.Location.X - PromieńPunktu, e.Location.Y - PromieńPunktu, PromieńPunktu + PromieńPunktu, PromieńPunktu + PromieńPunktu);
                    pzLicznikPunktówDoKrzywejOtwartej++;
                    if (pzLicznikPunktówDoKrzywejOtwartej == LiczbaPunktówKrzywej)
                    {
                        Point[] NowePunktyDoKrzywej = new Point[pzLicznikPunktówDoKrzywejOtwartej];
                        Array.Copy(pzPunktyDoKrzywejOtwartej, NowePunktyDoKrzywej, pzLicznikPunktówDoKrzywejOtwartej);
                        pzRysownica.DrawCurve(Pióro, NowePunktyDoKrzywej);
                        pzLicznikPunktówDoKrzywejOtwartej = 0;
                        Array.Clear(pzPunktyDoKrzywejOtwartej, 0, 1000);
                        txtLiczbaPunktowKrzywejOtwartej.Enabled = true;
                    }
                }
                else if (rbFillPath.Checked)
                {
                    int LiczbaPunktówŚcieżki;
                    if (!int.TryParse(txtLiczbaPunktowDoSciezkiZamknietej.Text, out LiczbaPunktówŚcieżki) || LiczbaPunktówŚcieżki < 3)
                    {
                        errorProvider1.SetError(txtLiczbaPunktowDoSciezkiZamknietej, "Proszę wpisać poprawną liczbę punktów (większą lub równą 3).");
                        return;
                    }
                    errorProvider1.Dispose();
                    txtLiczbaPunktowDoSciezkiZamknietej.Enabled = false;
                    pzPunktyDoŚcieżkiZamkniętej[pzLicznikPunktówDoŚcieżkiZamkniętej] = new Point(e.X, e.Y);
                    pzRysownica.FillEllipse(Brushes.Black, e.Location.X - PromieńPunktu, e.Location.Y - PromieńPunktu, PromieńPunktu + PromieńPunktu, PromieńPunktu + PromieńPunktu);
                    pzLicznikPunktówDoŚcieżkiZamkniętej++;
                    if (pzLicznikPunktówDoŚcieżkiZamkniętej == LiczbaPunktówŚcieżki)
                    {
                        Brush Pędzel = new SolidBrush(Color.Black);
                        Point[] NowePunktyDoKrzywej = new Point[pzLicznikPunktówDoŚcieżkiZamkniętej];
                        Array.Copy(pzPunktyDoŚcieżkiZamkniętej, NowePunktyDoKrzywej, pzLicznikPunktówDoŚcieżkiZamkniętej);
                        GraphicsPath Ścieżka = new GraphicsPath();
                        Ścieżka.AddPolygon(NowePunktyDoKrzywej);
                        pzRysownica.FillPath(Pędzel, Ścieżka);
                        pzLicznikPunktówDoŚcieżkiZamkniętej = 0;
                        Array.Clear(pzPunktyDoŚcieżkiZamkniętej, 0, 1000);
                        txtLiczbaPunktowDoSciezkiZamknietej.Enabled = true;
                    }
                }
                else if (rbDrawArc.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowyArc.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 360)
                    {
                        errorProvider1.SetError(txtKątPoczątkowyArc, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 360.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowyArc.Text, out KątKońcowy) || KątKońcowy < 0 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowyArc, "Proszę wpisać poprawny kąt końcowy z przedziału od 0 do 360.");
                        return;
                    }
                    pzRysownica.DrawArc(Pióro, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość), KątPoczątkowy, KątKońcowy);
                    pzLFG.Add(new DrawArc(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy));
                }
                else if (rbDrawPie.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowyPie.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 360)
                    {
                        errorProvider1.SetError(txtKątPoczątkowyPie, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 360.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowyPie.Text, out KątKońcowy) || KątKońcowy < 0 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowyPie, "Proszę wpisać poprawny kąt końcowy z przedziału od 1 do 360.");
                        return;
                    }
                    pzRysownica.DrawPie(Pióro, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość), KątPoczątkowy, KątKońcowy);
                    pzLFG.Add(new DrawPie(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość, KątPoczątkowy, KątKońcowy));
                }
            }
            pbRysownica.Refresh();
        }

        private void txtKątPoczątkowyPie_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbEllipse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {
                int LewyGórnyNarożnikX = (pzPunktStartu.X > e.Location.X) ? e.Location.X : pzPunktStartu.X;
                int LewyGórnyNarożnikY = (pzPunktStartu.Y > e.Location.Y) ? e.Location.Y : pzPunktStartu.Y;
                int Szerokość = Math.Abs(pzPunktStartu.X - e.Location.X);
                int Wysokość = Math.Abs(pzPunktStartu.Y - e.Location.Y);
                if (rbPunkt.Checked)
                {

                }
                else if (rbLiniaProsta.Checked)
                {
                    pzRysownicaPomocnicza.DrawLine(pzPióroPomocnicze, pzPunktStartu.X, pzPunktStartu.Y, e.Location.X, e.Location.Y);
                }
                else if (rbElipsa.Checked)
                {
                    pzRysownicaPomocnicza.DrawEllipse(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else if (rbOkrag.Checked)
                {
                    pzRysownicaPomocnicza.DrawEllipse(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość));
                }
                else if (rbWielokatForemny.Checked)
                {
                    int StopieńWielokąta;
                    if (!int.TryParse(txtStopieńWielokąta.Text, out StopieńWielokąta) || StopieńWielokąta < 3)
                    {
                        errorProvider1.SetError(txtStopieńWielokąta, "Proszę wpisać poprawny stopień wielokąta (większy lub równy 3).");
                        return;
                    }
                    Point[] TablicaWierzchołkówWielokąta;
                    TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i] = new Point();
                    }
                    float KąpziędzyWierzchołkami = 360F / StopieńWielokąta;
                    for (int i = 0; i <= StopieńWielokąta; i++)
                    {
                        TablicaWierzchołkówWielokąta[i].X = (int)(e.Location.X + (Szerokość + Wysokość) * Math.Cos(Math.PI * (0 + i * KąpziędzyWierzchołkami) / 180));
                        TablicaWierzchołkówWielokąta[i].Y = (int)(e.Location.Y - (Wysokość + Szerokość) * Math.Sin(Math.PI * (0 + i * KąpziędzyWierzchołkami) / 180));
                    }
                    pzRysownicaPomocnicza.DrawPolygon(pzPióroPomocnicze, TablicaWierzchołkówWielokąta);
                }
                else if (rbLiniaMysz.Checked)
                {
                    Pen Pióro = new Pen(Color.Black, 1);
                    pzRysownica.DrawLine(Pióro, new Point(pzXDoLiniiWykreślanejMyszą, pzYDoLiniiWykreślanejMyszą), e.Location);
                }
                else if (rbFillPie.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowy.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 359)
                    {
                        errorProvider1.SetError(txtKątPoczątkowy, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 359.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowy.Text, out KątKońcowy) || KątKońcowy < 1 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowy, "Proszę wpisać poprawny kąt końcowy z przedziału od 1 do 360.");
                        txtKątKońcowy.Text = "360";
                        return;
                    }
                    pzRysownicaPomocnicza.DrawEllipse(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość));
                    pzRysownicaPomocnicza.FillPie(pzPędzelPomocniczy, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość + 1, Szerokość + 1), KątPoczątkowy, KątKońcowy);
                }
                else if (rbClosedCurve.Checked)
                {

                }
                else if (rbDrawPath.Checked)
                {

                }
                else if (rbProstokat.Checked)
                {
                    pzRysownicaPomocnicza.DrawRectangle(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else if (rbKwadrat.Checked)
                {
                    pzRysownicaPomocnicza.DrawRectangle(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Szerokość));
                }
                else if (rbEllipse.Checked)
                {
                    pzRysownicaPomocnicza.FillEllipse(pzPędzelPomocniczy, LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość, Wysokość);
                }
                else if (rbDrawCurve.Checked)
                {

                }
                else if (rbFillPath.Checked)
                {

                }
                else if (rbDrawArc.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowyArc.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 359)
                    {
                        errorProvider1.SetError(txtKątPoczątkowyArc, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 359.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowyArc.Text, out KątKońcowy) || KątKońcowy < 1 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowyArc, "Proszę wpisać poprawny kąt końcowy z przedziału od 1 do 360.");
                        return;
                    }
                    pzRysownicaPomocnicza.DrawArc(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość + 1, Wysokość + 1), KątPoczątkowy, KątKońcowy);
                }
                else if (rbDrawPie.Checked)
                {
                    int KątPoczątkowy;
                    int KątKońcowy;
                    if (!int.TryParse(txtKątPoczątkowyPie.Text, out KątPoczątkowy) || KątPoczątkowy < 0 || KątPoczątkowy > 359)
                    {
                        errorProvider1.SetError(txtKątPoczątkowyPie, "Proszę wpisać poprawny kąt początkowy z przedziału od 0 do 359.");
                        return;
                    }
                    errorProvider1.Dispose();
                    if (!int.TryParse(txtKątKońcowyPie.Text, out KątKońcowy) || KątKońcowy < 1 || KątKońcowy > 360)
                    {
                        errorProvider1.SetError(txtKątKońcowyPie, "Proszę wpisać poprawny kąt końcowy z przedziału od 1 do 360.");
                        return;
                    }
                    pzRysownicaPomocnicza.DrawPie(pzPióroPomocnicze, new Rectangle(LewyGórnyNarożnikX, LewyGórnyNarożnikY, Szerokość+1, Wysokość+1), KątPoczątkowy, KątKońcowy);
                }
            }
            pzXDoLiniiWykreślanejMyszą = e.X;
            pzYDoLiniiWykreślanejMyszą = e.Y;
            pbRysownica.Refresh();
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (rbWielokatForemny.Checked)
            {
                label4.Visible = true;
                txtStopieńWielokąta.Visible = true;
            }
            else
            {
                label4.Visible = false;
                txtStopieńWielokąta.Visible = false;
            }
            if (rbClosedCurve.Checked)
            {
                label5.Visible = true;
                txtLiczbaPunktowKrzywej.Visible = true;
            }
            else
            {
                label5.Visible = false;
                txtLiczbaPunktowKrzywej.Visible = false;
            }
            if (rbFillPie.Checked)
            {
                label13.Visible = true;
                label14.Visible = true;
                txtKątPoczątkowy.Visible = true;
                txtKątKońcowy.Visible = true;
            }
            else
            {
                label13.Visible = false;
                label14.Visible = false;
                txtKątPoczątkowy.Visible = false;
                txtKątKońcowy.Visible = false;
            }
            if (rbDrawPath.Checked)
            {
                label8.Visible = true;
                txtLiczbaPunktowSciezki.Visible = true;
            }
            else
            {
                label8.Visible = false;
                txtLiczbaPunktowSciezki.Visible = false;
            }
            if (rbDrawCurve.Checked)
            {
                label9.Visible = true;
                txtLiczbaPunktowKrzywejOtwartej.Visible = true;
            }
            else
            {
                label9.Visible = false;
                txtLiczbaPunktowKrzywejOtwartej.Visible = false;
            }
            if (rbFillPath.Checked)
            {
                label10.Visible = true;
                txtLiczbaPunktowDoSciezkiZamknietej.Visible = true;
            }
            else
            {
                label10.Visible = false;
                txtLiczbaPunktowDoSciezkiZamknietej.Visible = false;
            }
            if (rbDrawArc.Checked)
            {
                label12.Visible = true;
                label11.Visible = true;
                txtKątPoczątkowyArc.Visible = true;
                txtKątKońcowyArc.Visible = true;
            }
            else
            {
                label12.Visible = false;
                label11.Visible = false;
                txtKątPoczątkowyArc.Visible = false;
                txtKątKońcowyArc.Visible = false;
            }
            if (rbDrawPie.Checked)
            {
                label6.Visible = true;
                label7.Visible = true;
                txtKątPoczątkowyPie.Visible = true;
                txtKątKońcowyPie.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label7.Visible = false;
                txtKątPoczątkowyPie.Visible = false;
                txtKątKońcowyPie.Visible = false;
            }
        }
    }
}
