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

namespace bakalarka_final
{
    public partial class Form1 : Form
    {
        Config cfgFile = new Config(); //load config file

        //variables
        private VideoCapture camera = null;
        Mat frame = new Mat();
        private Image<Bgr, Byte> cFrame = null;
        Image<Bgr, byte> doneImage = null;
        CascadeClassifier haar;
        int count = 0; //overall count of faces
        bool faceSide = false; //define if face is in region of interest (ROI)
        int rectEmpty = 0; //number of frames in which ROI doesn't have any faces in it
        Size minSize = new System.Drawing.Size(24, 24); // size that equals to size of trained images from XML
        System.Globalization.CultureInfo systemLanguage = System.Globalization.CultureInfo.CurrentUICulture;
        FilterInfoCollection DataCollector;
        string count_LT, side_LT, rectEmpty_LT, minFaceSize_LT = null;
        int p1x, p2x, p1y, p2y;
        Point px, py;

        public Form1()
        {
            InitializeComponent();
            haar = new CascadeClassifier(cfgFile.haarFile); //initialize haar cascade
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            px = new Point(p1x, p1y);
            py = new Point(p2x, p2y);

            if (camera != null) //comes from button1.click
            {
                camera.Retrieve(frame, 0);
                cFrame = frame.ToImage<Bgr, byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic); //edit image to fit the pictureBox; convert it to System class image
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(cFrame, grayFrame, ColorConversion.Bgr2Gray); //convert image to grayscale
                Rectangle[] faces = haar.DetectMultiScale(grayFrame, 1.1, 3, minSize, Size.Empty); //detect 
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        if (face.Width >= minFaceSize.Value)
                        {
                            faceCount_L.Text = faces.Length.ToString();
                            CvInvoke.Rectangle(cFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                            count_L.Text = count.ToString() + count_LT;
                            side_L.Text = side_LT + faceSide.ToString();
                            rectEmpty_L.Text = rectEmpty_LT + rectEmpty.ToString();
                            if (face.Location.X >= 200)
                            {
                                rectEmpty += 1;
                                if (rectEmpty >= 20)
                                {
                                    faceSide = false;
                                }
                            }
                            if (faceSide == false && face.Location.X < 200)
                            {
                                timer1.Start();
                                faceSide = true;
                                count += 1;
                                rectEmpty = 0;
                            }
                            drawLine();
                            doneImage = cFrame.Convert<Bgr, Byte>(); //pass image to doneImage
                        }
                    }
                }
                pictureBox1.Image = cFrame.ToBitmap(); //show image in pictureBox
            }
            GC.RemoveMemoryPressure(1028); //set pressure releasing
            GC.Collect(); //execute pressure releasing
        }

        void EN()
        {
            optionsToolStripMenuItem.Text = "Options";
            languageToolStripMenuItem.Text = "Language";
            displaySettingsToolStripMenuItem.Text = "Display settings";
            showCountLineToolStripMenuItem.Text = "Show count line";
            deviceToolStripMenuItem.Text = "Device";
            chooseCameraDeviceToolStripMenuItem.Text = "Choose camera device";
            aspectRatioToolStripMenuItem.Text = "Aspect ratio";
            count_LT = " people counted";
            side_LT = "Face in ROI: ";
            rectEmpty_LT = "Frames without face in ROI: ";
            minFaceSize_LT = "Filter out faces smaller than ";
            button1.Text = "Start";
            count_L.Text = count.ToString() + count_LT;
            side_L.Text = side_LT;
            rectEmpty_L.Text = rectEmpty_LT;
            minFaceSize_L.Text = minFaceSize_LT + minFaceSize.ToString();
        }

        void SK()
        {
            optionsToolStripMenuItem.Text = "Možnosti";
            languageToolStripMenuItem.Text = "Jazyk";
            displaySettingsToolStripMenuItem.Text = "Nastavenia zobrazenia";
            showCountLineToolStripMenuItem.Text = "Zobraziť počítaciu čiaru";
            deviceToolStripMenuItem.Text = "Zariadenie";
            chooseCameraDeviceToolStripMenuItem.Text = "Zvoliť zaznamenávacie zariadenie";
            aspectRatioToolStripMenuItem.Text = "Pomer strán";
            count_LT = " započítaných ľudí";
            side_LT = "Tvár v ROI: ";
            rectEmpty_LT = "Počet snímkov bez tváre v ROI: ";
            minFaceSize_LT = "Vyfiltrovať tváre menšie ako ";
            button1.Text = "Spustiť";
            count_L.Text = count.ToString() + count_LT;
            side_L.Text = side_LT;
            rectEmpty_L.Text = rectEmpty_LT;
            minFaceSize_L.Text = minFaceSize_LT + minFaceSize.ToString();
        }

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
            button1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 6, pictureBox1.Location.Y);
            count_L.Location = new Point(button1.Location.X, button1.Location.Y + button1.Size.Height + 3);
            side_L.Location = new Point(count_L.Location.X, count_L.Location.Y + count_L.Height + 3);
            rectEmpty_L.Location = new Point(side_L.Location.X, side_L.Location.Y + side_L.Height + 3);
            minFaceSize_L.Location = new Point(rectEmpty_L.Location.X, rectEmpty_L.Location.Y + rectEmpty_L.Height + 60);
            minFaceSize.Location = new Point(minFaceSize_L.Location.X, minFaceSize_L.Location.Y + minFaceSize_L.Height + 3);
            minFaceSize.Maximum = pictureBox1.Height;
            this.Size = new Size(button1.Location.X + button1.Width + 120, pictureBox1.Location.Y + pictureBox1.Height + 50);
        }

        void drawLine()
        {
            if (timer1.Enabled == false)
            {
                CvInvoke.Line(cFrame, px, py, new MCvScalar(0, 0, 255), 2);
            }
            else CvInvoke.Line(cFrame, px, py, new MCvScalar(0, 255, 0), 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = systemLanguage.ToString(); //remove
            faceCount_L.Text = Properties.Settings.Default.Language; //remove
            p1x = 200;
            p1y = 0;
            p2x = 200;
            //p2y defines after camera is load
            timer1.Interval = 100; // 0,1 second
            timer1.Enabled = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == true)
            {
                if (systemLanguage.ToString() == "sk-SK")
                {
                    SK();
                }
                else
                {
                    EN();
                }
            }
            else if (String.IsNullOrEmpty(Properties.Settings.Default.Language) == false)
            {
                if (Properties.Settings.Default.Language == "SK")
                {
                    SK();
                }
                else if (Properties.Settings.Default.Language == "EN")
                {
                    EN();
                }
            }
            DataCollector = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Data in DataCollector)
            {
                chooseCameraDeviceToolStripMenuItem.DropDownItems.Add(Data.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Webcam();
        }

        private void button2_Click(object sender, EventArgs e) //temporary maybe
        {
            Properties.Settings.Default.Language = null;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
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
    }
}
