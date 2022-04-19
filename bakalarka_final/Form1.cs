using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using AForge.Video.DirectShow;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace bakalarka_final
{
    public partial class Form1 : Form
    {
        Config cfgFile = new Config(); //load config file

        //variables
        private VideoCapture camera = null;
        Mat frame = new Mat();
        private Image<Bgr, Byte> cFrame = null;
        CascadeClassifier haar;
        int count = 0; //overall count of faces
        bool faceSide = false; //define if face is in region of interest (ROI)
        int rectEmpty = 0; //number of frames in which ROI doesn't have any faces in it
        Size minSize = new System.Drawing.Size(24, 24); // size that equals to size of trained images from XML
        System.Globalization.CultureInfo systemLanguage = System.Globalization.CultureInfo.CurrentUICulture;
        FilterInfoCollection DataCollector;
        string count_LT, side_LT, rectEmpty_LT, minFaceSize_LT, stat_LT = null;
        int p1x, p2x, p1y, p2y;
        bool stopClicked, startClicked = false;
        Point px, py;
        Rectangle rect_label, rect_buttons;
        Stopwatch loop = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            haar = new CascadeClassifier(cfgFile.haarFile); //initialize haar cascade
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            loop = Stopwatch.StartNew();
            if (camera != null) //comes from button1.click
            {
                camera.Retrieve(frame, 0);
                cFrame = frame.ToImage<Bgr, byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic); //edit image to fit the pictureBox; convert it to System class image
                //int loop = DateTime.Now.Millisecond;
                loop.Start();
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(cFrame, grayFrame, ColorConversion.Bgr2Gray); //convert image to grayscale
                Rectangle[] faces = haar.DetectMultiScale(grayFrame, 1.1, 3, minSize, Size.Empty); //detect 
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        if (face.Width >= minFaceSize.Value)
                        {
                            CvInvoke.Rectangle(cFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                            count_L.Text = count.ToString() + count_LT;
                            side_L.Text = side_LT + faceSide.ToString();
                            rectEmpty_L.Text = rectEmpty_LT + rectEmpty.ToString();
                            if (face.Location.X >= px.X)
                            {
                                rectEmpty += 1;
                                if (rectEmpty >= 20) faceSide = false;
                            }
                            if (face.Location.X < px.X)
                            {
                                rectEmpty = 0;
                                if (faceSide == false)
                                {
                                    timer1.Start();
                                    faceSide = true;
                                    count += 1;
                                }
                            }
                            cFrame.Convert<Bgr, Byte>(); //pass image to picturebox
                        }
                    }
                }
                loop.Stop();
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.ChartAreas[0].AxisY.Minimum = Double.NaN;
                chart1.Series["Series1"].Points.AddY(loop.ElapsedMilliseconds);
                if (chart1.Series["Series1"].Points.Count >= 30)
                {
                    chart1.Series["Series1"].Points.RemoveAt(0);
                }
                //this.Text = (loop.ElapsedMilliseconds).ToString();
                if (showCountLineToolStripMenuItem.Checked == true) drawLine();
                pictureBox1.Image = cFrame.ToBitmap(); //show image in pictureBox
            }
            GC.RemoveMemoryPressure(1028); //set pressure releasing
            GC.Collect(); //execute pressure releasing
            if (stopClicked == true)
            {
                Application.Idle -= ProcessFrame;
                pictureBox1.Image = null;
            }
        }

        #region languages
        void EN()
        {
            optionsToolStripMenuItem.Text = "Options";
            languageToolStripMenuItem.Text = "Language";
            settingsToolStripMenuItem.Text = "Settings";
            displaySettingsToolStripMenuItem.Text = "Display settings";
            showCountLineToolStripMenuItem.Text = "Show count line";
            otherSettingsToolStripMenuItem.Text = "Other settings";
            developerModeToolStripMenuItem.Text = "Developer mode";
            statisticsToolStripMenuItem.Text = "Statistics";
            deviceToolStripMenuItem.Text = "Device";
            chooseCameraDeviceToolStripMenuItem.Text = "Choose camera device";
            count_LT = " people counted";
            side_LT = "Face in ROI: ";
            rectEmpty_LT = "Frames without face in ROI: ";
            minFaceSize_LT = "Filter out faces smaller than ";
            stat_LT = "Time of face detection per picture";
            start.Text = "Start";
            count_L.Text = count.ToString() + count_LT;
            side_L.Text = side_LT;
            rectEmpty_L.Text = rectEmpty_LT;
            minFaceSize_L.Text = minFaceSize_LT + minFaceSize.Value.ToString() + "px";
            stat_L.Text = stat_LT;
            chart1.Series["Series1"].LegendText = "Time (in milliseconds)";
        }

        void SK()
        {
            optionsToolStripMenuItem.Text = "Možnosti";
            languageToolStripMenuItem.Text = "Jazyk";
            settingsToolStripMenuItem.Text = "Nastavenia";
            displaySettingsToolStripMenuItem.Text = "Nastavenia zobrazenia";
            showCountLineToolStripMenuItem.Text = "Zobraziť počítaciu čiaru";
            otherSettingsToolStripMenuItem.Text = "Ostatné nastavenia";
            developerModeToolStripMenuItem.Text = "Mód vývojára";
            statisticsToolStripMenuItem.Text = "Štatistiky";
            deviceToolStripMenuItem.Text = "Zariadenie";
            chooseCameraDeviceToolStripMenuItem.Text = "Zvoliť zaznamenávacie zariadenie";
            count_LT = " započítaných ľudí";
            side_LT = "Tvár v ROI: ";
            rectEmpty_LT = "Počet snímkov bez tváre v ROI: ";
            minFaceSize_LT = "Vyfiltrovať tváre menšie ako ";
            stat_LT = "Doba detegovania tvárí z obrazu";
            start.Text = "Spustiť";
            count_L.Text = count.ToString() + count_LT;
            side_L.Text = side_LT;
            rectEmpty_L.Text = rectEmpty_LT;
            minFaceSize_L.Text = minFaceSize_LT + minFaceSize.Value.ToString() + "px";
            stat_L.Text = stat_LT;
            chart1.Series["Series1"].LegendText = "Čas (v milisekundách)";
            this.Invalidate();
        }
        #endregion

        void Webcam()
        {
            if (camera != null) camera.Dispose();
            camera = new VideoCapture(Properties.Settings.Default.cameraIndex);
            adaptPictureBox();
            camera.QueryFrame(); //necessarry
            camera.Start(); //necessarry
            Application.Idle += ProcessFrame; //pass it to ProcessFrame void
        }

        void adaptPictureBox()
        {
            if (Screen.PrimaryScreen.Bounds.Height < Screen.PrimaryScreen.Bounds.Width)
            {
                pictureBox1.Height = (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.5, 0);
                pictureBox1.Width = (int)(pictureBox1.Height * (Decimal.Divide(camera.Width, camera.Height)));
            }
            else if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
            {
                pictureBox1.Width = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.5, 0);
                pictureBox1.Height = (int)(pictureBox1.Width * (Decimal.Divide(camera.Height, camera.Width)));
            }
            p2y = pictureBox1.Height;
            px = new Point(p1x, p1y);
            py = new Point(p2x, p2y);
            start.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 25, pictureBox1.Location.Y + 100);
            stop.Location = new Point(start.Location.X + start.Width + 35, start.Location.Y);
            this.Invalidate(); //refresh interface cause of rectangles
            side_L.Location = new Point(start.Location.X, start.Location.Y + start.Height + 30);
            rectEmpty_L.Location = new Point(side_L.Location.X, side_L.Location.Y + side_L.Height + 3);
            minFaceSize_L.Location = new Point(rectEmpty_L.Location.X, rectEmpty_L.Location.Y + rectEmpty_L.Height + 30);
            minFaceSize.Location = new Point(minFaceSize_L.Location.X, minFaceSize_L.Location.Y + minFaceSize_L.Height + 3);
            chart1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 10, start.Location.Y + start.Height + 30);
            stat_L.Location = new Point(chart1.Location.X + ((((chart1.Location.X + chart1.Width) - chart1.Location.X) / 2) - stat_L.Width / 2), chart1.Location.Y - 15);
            minFaceSize.Maximum = pictureBox1.Height;
            this.Size = new Size(start.Location.X + start.Width + 150, pictureBox1.Location.Y + pictureBox1.Height + 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            Pen pen = new Pen(Color.FromArgb(20, 0, 0, 0), 5);
            SolidBrush brush = new SolidBrush(Color.FromArgb(25, 0, 0, 0));
            if (startClicked == true)
            {
                rect_label = new Rectangle(start.Location.X - 10, pictureBox1.Location.Y, ((stop.Location.X + stop.Width) - start.Location.X) + 20, (start.Location.Y - pictureBox1.Location.Y) - 15);
                rect_buttons = new Rectangle(start.Location.X - 10, start.Location.Y - 10, ((stop.Location.X + stop.Width) - start.Location.X) + 20, start.Height + 20);
                FillRoundedRectangle(e.Graphics, brush, rect_label, 20);
                FillRoundedRectangle(e.Graphics, brush, rect_buttons, 20);
                count_L.Location = new Point(rect_label.Location.X + ((((rect_label.Location.X + rect_label.Width) - rect_label.Location.X) / 2) - count_L.Width / 2), ((((rect_label.Location.Y + rect_label.Height) - rect_label.Location.Y) / 2) + rect_label.Location.Y) - count_L.Height / 2);
            }
            else if (startClicked == false)
            {
                rect_label = new Rectangle(count_L.Location.X - 5, count_L.Location.Y - 10, count_L.Width + 10, count_L.Height + 20);
                FillRoundedRectangle(e.Graphics, brush, rect_label, 10);
            }
        }

        #region rounded_rectangles
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius) //create rounded rectangle
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius) //draw rounded rectangle
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius) //fill rounded rectangle
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }
        #endregion

        void drawLine()
        {
            if (timer1.Enabled == false)
            {
                CvInvoke.Line(cFrame, px, py, new MCvScalar(0, 0, 255), 2);
            }
            else CvInvoke.Line(cFrame, px, py, new MCvScalar(0, 255, 0), 2);
        }

        #region created_by_system
        private void Form1_Load(object sender, EventArgs e)
        {
            side_L.Visible = false;
            rectEmpty_L.Visible = false;
            minFaceSize_L.Visible = false;
            minFaceSize.Visible = false;
            stop.Visible = false;
            stop.Enabled = false;
            pictureBox1.Visible = false;
            p1x = 200;
            p1y = 0;
            p2x = 200;
            //p2y defines after camera is load
            chart1.Series["Series1"].Points.Clear();
            timer1.Interval = 100; // 0,1 second
            timer1.Enabled = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == true)
            {
                if (systemLanguage.ToString() == "sk-SK")
                {
                    SK();
                    count_L.Text = "Pre spustenie počítadla, kliknite na tlačidlo 'Štart'";
                }
                else
                {
                    EN();
                    count_L.Text = "Click on 'Start' to start the counter";
                }
            }
            else if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == false)
            {
                if (Properties.Settings.Default.Language == "SK")
                {
                    SK();
                    count_L.Text = "Pre spustenie počítadla, kliknite na tlačidlo 'Spustiť'";
                }
                else if (Properties.Settings.Default.Language == "EN")
                {
                    EN();
                    count_L.Text = "Click on 'Start' to start the counter";
                }
            }
            count_L.Location = new Point(20, menuStrip1.Height + 20);
            start.Location = new Point(((count_L.Width / 2) + count_L.Location.X) - start.Width / 2, count_L.Location.Y + count_L.Height + 20 );
            Size = new Size(count_L.Location.X + count_L.Width + 35, start.Location.Y + start.Height + 5 + 39);
            DataCollector = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Data in DataCollector)
            {
                chooseCameraDeviceToolStripMenuItem.DropDownItems.Add(Data.Name);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (showCountLineToolStripMenuItem.Checked == true)
            {
                Point mouseLocation = this.PointToClient(MousePosition);
                px = new Point(mouseLocation.X - pictureBox1.Location.X, px.Y);
                py = new Point(mouseLocation.X - pictureBox1.Location.X, py.Y);
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statisticsToolStripMenuItem.Checked == true)
            {
                chart1.Visible = true;
                stat_L.Visible = true;
            }
            else
            {
                chart1.Visible = false;
                stat_L.Visible = false;
            }
        }

        private void developerModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (developerModeToolStripMenuItem.Checked == true)
            {
                chart1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 5, minFaceSize.Location.Y + minFaceSize.Height + 10);
                stat_L.Location = new Point(chart1.Location.X + ((((chart1.Location.X + chart1.Width) - chart1.Location.X) / 2) - stat_L.Width / 2), chart1.Location.Y - 15);
                side_L.Visible = true;
                rectEmpty_L.Visible = true;
                minFaceSize_L.Visible = true;
                minFaceSize.Visible = true;
            }
            else
            {
                chart1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 10, start.Location.Y + start.Height + 30);
                stat_L.Location = new Point(chart1.Location.X + ((((chart1.Location.X + chart1.Width) - chart1.Location.X) / 2) - stat_L.Width / 2), chart1.Location.Y - 15);
                side_L.Visible = false;
                rectEmpty_L.Visible = false;
                minFaceSize_L.Visible = false;
                minFaceSize.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //start button
        {
            Webcam();
            start.Enabled = false;
            stop.Enabled = true;
            startClicked = true;
            stopClicked = false;
            stop.Visible = true;
            pictureBox1.Visible = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == true)
            {
                if (systemLanguage.ToString() == "sk-SK") SK();
                else EN();
            }
            else if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == false)
            {
                if (Properties.Settings.Default.Language == "SK") SK();
                else if (Properties.Settings.Default.Language == "EN") EN();
            }
        }

        private void stop_Click(object sender, EventArgs e) //stop button
        {
            stopClicked = true;
            start.Enabled = true;
            camera.Stop();
            camera = null;
        }

        private void button2_Click(object sender, EventArgs e) //temporary button (will be deleted later)
        {
            Properties.Settings.Default.Language = null;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e) //timer for count line
        {
            timer1.Stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) //trackbar for minFaceSize
        {
            minFaceSize_L.Text = minFaceSize_LT + minFaceSize.Value.ToString() + " px";
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EN();
            Properties.Settings.Default.Language = "EN";
            Properties.Settings.Default.Save();
            trackBar1_Scroll(sender, e);
        }

        private void slovakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SK();
            Properties.Settings.Default.Language = "SK";
            Properties.Settings.Default.Save();
            trackBar1_Scroll(sender, e);
        }
        
        private void chooseCameraDeviceToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Properties.Settings.Default.cameraIndex = chooseCameraDeviceToolStripMenuItem.DropDownItems.IndexOf(e.ClickedItem);
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
