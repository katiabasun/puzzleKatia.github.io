using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int cols = 10;
        int rows = 5;
        int pieceWidth;
        int pieceHeight;
        Bitmap original;
        List<PictureBox> pieces = new List<PictureBox>();
        PictureBox firstClicked = null;
      

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                string imagePath = "C:\\Ausbildug\\Projects\\VisualStudio2022\\Puzzle\\WinFormsApp1\\Pic.jpg";
                Bitmap loaded = new Bitmap(imagePath);
                Bitmap resized = new Bitmap(loaded, new Size(1000, 600));
                original = resized;
                previewBox.Image = loaded;

                if (!System.IO.File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found!");
                    return;
                }

                if (original.Width < cols || original.Height < rows)
                {
                    MessageBox.Show("Image is too small for the selected grid size.");
                    return;
                }

                pieceWidth = original.Width / cols;
                pieceHeight = original.Height / rows;

                panel1.Controls.Clear();
                pieces.Clear();

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        Rectangle cropArea = new Rectangle(c * pieceWidth, r * pieceHeight, pieceWidth, pieceHeight);
                        Bitmap piece = original.Clone(cropArea, original.PixelFormat);

                        PictureBox pb = new PictureBox
                        {
                            Image = piece,
                            Size = new Size(pieceWidth, pieceHeight),
                            Location = new Point(c * pieceWidth, r * pieceHeight),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = new Point(r, c)
                        };
                        pb.Click += Piece_Click;

                        panel1.Controls.Add(pb);
                        pieces.Add(pb);
                    }
                }

                ShufflePieces();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShufflePieces()
        {
            Random rand = new Random();
            var shuffled = pieces.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < shuffled.Count; i++)
            {
                int row = i / cols;
                int col = i % cols;
                shuffled[i].Location = new Point(col * pieceWidth, row * pieceHeight);
            }
        }
        private void CheckPieceCorrectness(PictureBox pb)
        {
            Point correctPos = (Point)pb.Tag;

            // Berechne die aktuelle Position im Grid anhand der Location
            int currentCol = pb.Location.X / pieceWidth;
            int currentRow = pb.Location.Y / pieceHeight;
            Point currentPos = new Point(currentCol, currentRow);

            if (correctPos == currentPos)
            {
                pb.Enabled = false;
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.BackColor = Color.LightGreen;
            }
        }


        private void Piece_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked == null || !clicked.Enabled)
                return;

            if (firstClicked == null)
            {
                firstClicked = clicked;
                clicked.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                // Swap Image and Tag
                Image tempImage = clicked.Image;
                object tempTag = clicked.Tag;

                clicked.Image = firstClicked.Image;
                clicked.Tag = firstClicked.Tag;

                firstClicked.Image = tempImage;
                firstClicked.Tag = tempTag;

                firstClicked.BorderStyle = BorderStyle.None;

                CheckPieceCorrectness(firstClicked);
                CheckPieceCorrectness(clicked);

                firstClicked = null;
            }
        }

    }
}