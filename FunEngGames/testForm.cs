using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunEngGames
{
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();
        }
        private Point MouseDownLocation;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           // button1.DoDragDrop(button1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
           // button1.DoDragDrop(button1, DragDropEffects.Copy | DragDropEffects.Move);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            //timer1.Enabled = true;

            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
           // if (e.Data.GetDataPresent(DataFormats.Text))
           //     e.Effect = DragDropEffects.Copy;
          //  else
           //     e.Effect = DragDropEffects.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.DragEnter += new DragEventHandler(button2_DragEnter);
            //button3.DragDrop += new DragEventHandler(button2_DragDrop);
            Form h = new Home();
            h.Show();
        }


        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;

        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            //textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("x: " + Cursor.Position.X + " y: " + Cursor.Position.Y);

            //button1.Location.X= Cursor.Position.X;
            //button1.Location.Y = Cursor.Position.Y;


            button1.Left = Cursor.Position.X + button1.Left - MouseDownLocation.X;
            button1.Top = Cursor.Position.Y + button1.Top - MouseDownLocation.Y;
            label1.Text = button1.Left + "|" + button1.Top;

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           // label2.Text = MouseDownLocation.X + "|" + MouseDownLocation.Y;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                button1.Left = e.X + button1.Left - MouseDownLocation.X;
                button1.Top = e.Y + button1.Top - MouseDownLocation.Y;
               // label1.Text = button1.Left + "|" + button1.Top;

               // if (button1.Location.X==button2.Location.X && button1.Location.Y == button2.Location.Y)
               // {
               //     MessageBox.Show("Good");
               // }
            }
        }


        private void button2_DragLeave(object sender, EventArgs e)
        {
          //  button1.Left = button2.Left;
          //  button1.Top = button2.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  button1.Left = button2.Left;
          //  button1.Top = button2.Top;
        }

        private void button2_DragOver(object sender, DragEventArgs e)
        {
           // button1.Left = button2.Left;
          //  button1.Top = button2.Top;
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            button1.Left = button2.Left;
            button1.Top = button2.Top;
        }

        private void button3_DragDrop(object sender, DragEventArgs e)
        {
            button1.Left = button3.Left;
            button1.Top = button3.Top;
        }




        bool isDragged = false;
        Point ptOffset;
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
           // button4.DoDragDrop(button4, DragDropEffects.Copy | DragDropEffects.Move);
            dragDown(button4, e);
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            dragMove(button4, e);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;

        }


        private void dragDown(Button b, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                isDragged = true;
               // Point ptStartPosition = b.PointToScreen(new Point(e.X, e.Y));
                MouseDownLocation = e.Location;
               // ptOffset = new Point();
               // ptOffset.X = b.Location.X - ptStartPosition.X;
               // ptOffset.Y = b.Location.Y - ptStartPosition.Y;
            }
            else
            {
                isDragged = false;
            }
        }


        private void dragMove(Button b, MouseEventArgs e)
        {
            if (isDragged)
            {

               // if (e.Button == System.Windows.Forms.MouseButtons.Left)
               // {
                    b.Left = e.X + b.Left - MouseDownLocation.X;
                    b.Top = e.Y + b.Top - MouseDownLocation.Y;
                    // Point newPoint = b.PointToScreen(new Point(e.X, e.Y));
                    // newPoint.Offset(ptOffset);
                    // b.Location = newPoint;
                }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            isDragged = false;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            isDragged = false;
            label1.Text = "out form";
        }
    }
}
