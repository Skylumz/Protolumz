using Protolumz.Resources;
using RadicalCore.Gamefiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protolumz
{
    public partial class ImageViewer : UserControl, INodeView
    {
        private TextureNode CurrentTexture = null;

        public ImageViewer()
        {
            InitializeComponent();
        }

        public void LoadNode(P3DNode node)
        {
            ShowTexture(node as TextureNode);
        }

        private void SaveTexture()
        {
            if (CurrentTexture == null || PictureBox.Image == null) return;

            using(var sfd = new SaveFileDialog())
            {
                sfd.FileName = CurrentTexture.Name;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    PictureBox.Image.Save(sfd.FileName);
                }
            }
        }

        private void ShowTexture(TextureNode texture, int miplevel = 0)
        {
            CurrentTexture = texture;

            try
            {
                byte[] pixels = DDSIO.GetPixels(texture, miplevel);
                int w = (int)(texture.Width >> miplevel);
                int h = (int)(texture.Height >> miplevel);
                Bitmap bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb);

                if (pixels != null)
                {
                    var BoundsRect = new Rectangle(0, 0, w, h);
                    BitmapData bmpData = bmp.LockBits(BoundsRect, ImageLockMode.WriteOnly, bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = bmpData.Stride * bmp.Height;
                    Marshal.Copy(pixels, 0, ptr, bytes);
                    bmp.UnlockBits(bmpData);
                }

                PictureBox.Image = bmp;
                PictureBox.Width = w;
                PictureBox.Height = h;
                MipLevelTrackBar.Maximum = (int)texture.Levels;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure to display: " + texture.Name + " because: " + ex.Message);
            }
        }

        private void MipLevelTrackBar_Scroll(object sender, EventArgs e)
        {
            MipValueLabel.Text = MipLevelTrackBar.Value.ToString();
            if (CurrentTexture == null) return;
            ShowTexture(CurrentTexture, MipLevelTrackBar.Value);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTexture();
        }
    }
}
