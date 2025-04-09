using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edge_detection
{
    internal partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            colorBox.SelectedItem = "Green";
            blurBox.SelectedItem = "Median";
            xBox.SelectedItem = "avg (best)";
            yBox.SelectedItem = "avg (best)";
            deltaBox.SelectedItem = "+";
        }

        internal Form1()
        {
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        private int resizeTo;

        private readonly OpenFileDialog ofd = new()
        {
            Filter = "Image files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif",
            Title = "Veuiller choisir une image au format spécifier"
        };

        private Bitmap bmp;
        private Bitmap resized;
        private Bitmap colored;
        private Bitmap blurred;
        private Bitmap deltaX;
        private Bitmap deltaY;
        private Bitmap deltas;
        private Bitmap result;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                generate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(colored);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(blurred);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(deltaX);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(deltaY);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(deltas);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null && checkBox1.Checked == true) { generate(); }
        }

        private void blurBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null && checkBox2.Checked == true) { generate(); }
        }

        private void xBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void yBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void deltaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null) { generate(); }
        }

        private void pictureBoxes()
        {
            try
            {
                pictureBox1.Image = resized;
                pictureBox2.Image = colored;
                pictureBox3.Image = blurred;
                pictureBox4.Image = deltaX;
                pictureBox5.Image = deltaY;
                pictureBox6.Image = deltas;
                pictureBox7.Image = result;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generateNodeltaY()
        {
            try
            {
                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generateNodeltaX()
        {
            try
            {
                deltaY = Deltas.DeltaY(blurred, yBox.SelectedItem.ToString());

                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox4.Checked == true)
                {
                    deltaY = Erosion.Erode(deltaY);
                }

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generateNoblurred()
        {
            try
            {
                deltaX = Deltas.DeltaX(blurred, xBox.SelectedItem.ToString());

                deltaY = Deltas.DeltaY(blurred, yBox.SelectedItem.ToString());

                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox3.Checked == true)
                {
                    deltaX = Erosion.Erode(deltaX);
                }

                if (checkBox4.Checked == true)
                {
                    deltaY = Erosion.Erode(deltaY);
                }

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generateNocolored()
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    string blurType = blurBox.SelectedItem.ToString();

                    switch (blurType)
                    {
                        case "Mean":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Mean, 1.0 / 9.0);

                            break;

                        case "Gaussian":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Gaussian, 1.0 / 16.0);

                            break;

                        case "Median":

                            blurred = Blur.MedianBlur(colored);

                            break;
                    }
                }

                deltaX = Deltas.DeltaX(blurred, xBox.SelectedItem.ToString());

                deltaY = Deltas.DeltaY(blurred, yBox.SelectedItem.ToString());

                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox3.Checked == true)
                {
                    deltaX = Erosion.Erode(deltaX);
                }

                if (checkBox4.Checked == true)
                {
                    deltaY = Erosion.Erode(deltaY);
                }

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generateNoresized()
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    colored = ConvertToColor.RGB(resized, colorBox.SelectedItem.ToString());
                }
                else { colored = resized; }

                if (checkBox2.Checked == true)
                {
                    string blurType = blurBox.SelectedItem.ToString();

                    switch (blurType)
                    {
                        case "Mean":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Mean, 1.0 / 9.0);

                            break;

                        case "Gaussian":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Gaussian, 1.0 / 16.0);

                            break;

                        case "Median":

                            blurred = Blur.MedianBlur(colored);

                            break;
                    }
                }

                deltaX = Deltas.DeltaX(blurred, xBox.SelectedItem.ToString());

                deltaY = Deltas.DeltaY(blurred, yBox.SelectedItem.ToString());

                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox3.Checked == true)
                {
                    deltaX = Erosion.Erode(deltaX);
                }

                if (checkBox4.Checked == true)
                {
                    deltaY = Erosion.Erode(deltaY);
                }

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void generate()
        {
            try
            {
                bmp = new Bitmap(ofd.FileName);

                string resizeToString = textBox1.Text;
                if (int.TryParse(resizeToString, out resizeTo)) { }
                else { resizeTo = 1024; MessageBox.Show("Valeur de taille invalid (1024 par défaut)"); }

                resized = RedimensionImage.ScaleImage(bmp, resizeTo);

                if (checkBox1.Checked == true)
                {
                    colored = ConvertToColor.RGB(resized, colorBox.SelectedItem.ToString());
                }
                else { colored = resized; }

                if (checkBox2.Checked == true)
                {
                    string blurType = blurBox.SelectedItem.ToString();

                    switch (blurType)
                    {
                        case "Mean":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Mean, 1.0 / 9.0);

                            break;

                        case "Gaussian":

                            blurred = Blur.ConvolutionBlur(colored, Matrix.Gaussian, 1.0 / 16.0);

                            break;

                        case "Median":

                            blurred = Blur.MedianBlur(colored);

                            break;
                    }
                }

                deltaX = Deltas.DeltaX(blurred, xBox.SelectedItem.ToString());

                if (checkBox3.Checked == true)
                {
                    deltaX = Erosion.Erode(deltaX);
                }

                deltaY = Deltas.DeltaY(blurred, yBox.SelectedItem.ToString());

                if (checkBox4.Checked == true)
                {
                    deltaY = Erosion.Erode(deltaY);
                }

                deltas = Deltas.Both(deltaX, deltaY, deltaBox.SelectedItem.ToString());

                if (checkBox5.Checked == true)
                {
                    deltas = Erosion.Erode(deltas);
                }

                switch (colorBox.SelectedItem.ToString())
                {
                    case "Blue":

                        result = LayerMask.LayerMasking(resized, deltas, 0);

                        break;

                    case "Green":

                        result = LayerMask.LayerMasking(resized, deltas, 1);

                        break;

                    case "Red":

                        result = LayerMask.LayerMasking(resized, deltas, 2);

                        break;
                }

                pictureBoxes();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}