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
using AForge;
using Newtonsoft.Json;

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

        public Form1()
        {
            InitializeComponent();
            haar = new CascadeClassifier(cfgFile.haarFile); //initialize haar cascade
        }

        private void ProcessFrame(object sender, EventArgs e)
        { 
            if (camera != null) //comes from button1.click
            {
                camera.Retrieve(frame, 0); 
                //pictureBox1.Image = Image.FromHbitmap(cFrame
                cFrame = frame.ToImage<Bgr, byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic); //edit image to fit the pictureBox; convert it to System class image
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(cFrame, grayFrame, ColorConversion.Bgr2Gray); //convert image to grayscale
                Rectangle[] faces = haar.DetectMultiScale(grayFrame, 1.1, 3, minSize, Size.Empty); //detect face
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        if (face.Width >= minFaceSize.Value)
                        {
                            faceCount_L.Text = faces.Length.ToString();
                            CvInvoke.Rectangle(cFrame, face, new Bgr(Color.Green).MCvScalar, 2); //draw 
                            count_L.Text = "People passed: " + count.ToString();
                            label2.Text = "faceSide: " + faceSide.ToString();
                            label3.Text = "rectEmptyFrames: " + rectEmpty.ToString();
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
                                faceSide = true;
                                count += 1;
                                rectEmpty = 0;
                            }
                            doneImage = cFrame.Convert<Bgr, Byte>(); //pass image to doneImage
                        }
                    }
                }
                pictureBox1.Image = cFrame.ToBitmap(); //show image in pictureBox
            }
            GC.RemoveMemoryPressure(1028); //set pressure releasing
            GC.Collect(); //execute pressure releasing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Webcam();
        }

        void Webcam()
        {
            if (camera != null) camera.Dispose();
            camera = new VideoCapture();
            camera.QueryFrame(); //necessarry
            camera.Start(); //necessarry
            Application.Idle += ProcessFrame; //pass it to ProcessFrame void
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            minFaceSize.Maximum = pictureBox1.Height;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            minFaceSize_L.Text = minFaceSize.Value.ToString();
        }
    }
}
