using RadicalCore.Gamefiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protolumz
{
    public interface IHexViewer
    {
        void UpdateUI();
    }

    public partial class HexViewer : UserControl, INodeView
    {
        public IHexViewer Owner;

        public byte[] Data = null;
        private NumberType numbertype = NumberType.Decimal;
        public NumberType NumberType
        {
            get
            {
                return numbertype;
            }
            set
            {
                numbertype = value;
                UpdateOffsetsTextbox();
            }
        }
        private int bytesperline = 16;
        public int BytesPerLine
        {
            get
            {
                return bytesperline;
            }
            set 
            {
                bytesperline = value;
                UpdateHexTextbox();
                UpdateOffsetsTextbox();
            }
        }
        public byte[] SelectedBytes = null;
        public int CurrentOffset { get { return GetOffset(); } }

        public HexViewer()
        {
            InitializeComponent();

            OffsetLabel.Font = new Font(FontFamily.GenericMonospace, OffsetLabel.Font.Size); //makes everything aligned 
            OffsetsLabel.Font = new Font(FontFamily.GenericMonospace, OffsetsLabel.Font.Size); //makes everything aligned 
            DecodedTextLabel.Font = new Font(FontFamily.GenericMonospace, OffsetTextBox.Font.Size); //makes everything aligned 

            HexTextBox.Font = new Font(FontFamily.GenericMonospace, HexTextBox.Font.Size); //makes everything aligned 
            DecodedTextBox.Font = new Font(FontFamily.GenericMonospace, DecodedTextBox.Font.Size); //makes everything aligned 
            OffsetTextBox.LinkedTextBoxes = new Control[2] { HexTextBox, DecodedTextBox };
            HexTextBox.LinkedTextBoxes = new Control[2] { OffsetTextBox, DecodedTextBox };
            DecodedTextBox.LinkedTextBoxes = new Control[2] { OffsetTextBox, HexTextBox };
        }

        public void LoadData(byte[] data)
        {
            Data = data;
            if (Data.Length > 1500)
            {
                HexTextBox.Text = "Unable to diplay files over 1500bytes";
                return;
            }
            UpdateHexTextbox();
            UpdateOffsetsTextbox();
        }
        public void LoadNode(P3DNode node)
        {
            LoadData(node.Data);
        }

        public void UpdateHexTextbox()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateHexTextbox()));
            }
            else
            {
                if (Data == null) return;
                HexTextBox.Text = HexUtilties.GetBytesString(Data, BytesPerLine);
                DecodedTextBox.Text = HexUtilties.GetDecodedTextString(Data, BytesPerLine);
            }
        }

        public void UpdateOffsetsTextbox()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateOffsetsTextbox()));
            }
            else
            {
                if (Data == null) return;
                OffsetsLabel.Text = HexUtilties.GetOffsetsString(BytesPerLine, NumberType);
                OffsetTextBox.Text = HexUtilties.GetOffsetString(Data.Length, BytesPerLine, NumberType);
            }
        }

        private void UpdateSizes()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateSizes()));
            }
            else
            {
                var htbSize = TextRenderer.MeasureText(HexTextBox.Text, HexTextBox.Font);
                var dtbSize = TextRenderer.MeasureText(DecodedTextBox.Text, DecodedTextBox.Font);
                HexTextBox.Width = htbSize.Width + 5;
                DecodedTextLabel.Width = dtbSize.Width + 15;
                DecodedTextBox.Width = dtbSize.Width + 15;
                var otbSize = TextRenderer.MeasureText(OffsetTextBox.Text, OffsetTextBox.Font);
                var oltbSize = TextRenderer.MeasureText(OffsetsLabel.Text, OffsetsLabel.Font);
                OffsetLabel.Width = otbSize.Width + 5;
                OffsetTextBox.Width = otbSize.Width + 5;
                OffsetsLabel.Width = oltbSize.Width + 5;
            }
        }

        public void UpdateHexSelection()
        {
            if (HexTextBox.SelectionLength > 0)
            {
                var offset = GetDecodedTextOffset();
                var length = SelectedBytes.Length;
                if (length > BytesPerLine)
                {
                    var lct = (length / BytesPerLine) * 2;
                    length += lct;
                }
                DecodedTextBox.Select(offset, length);
            }
            else
            {
                DecodedTextBox.Select(GetDecodedTextOffset(), 0);
            }
        }
        public void UpdateTextSelection()
        {
            if (DecodedTextBox.SelectionLength > 0)
            {
                var offset = GetDecodedTextByteOffset();
                var text = DecodedTextBox.SelectedText;
                var count = text.Replace(" ", "").Replace("\n", "").Replace("\r", "").Length;
                var length = count * 3;
                if (length > BytesPerLine)
                {
                    var lct = (length / BytesPerLine);
                    length += lct;
                }
                HexTextBox.Select(offset, length);
            }
            else
            {
                HexTextBox.Select(GetDecodedTextByteOffset(), 0);
            }
        }

        //fixes user selecting in between a byte
        public void FixHexSelection()
        {
            if (HexTextBox.SelectionLength == 0) return;
            var selidx = HexTextBox.SelectionStart;
            var sellength = HexTextBox.SelectionLength;

            bool movedback = false;
            var sel = HexTextBox.Text.Substring(selidx, 2);
            if (sel.EndsWith(" "))
            {
                selidx -= 1;
                movedback = true;
            }
            var length = HexTextBox.SelectionStart + HexTextBox.SelectionLength;
            if (length >= HexTextBox.Text.Length) return;
            sel = HexTextBox.Text.Substring(length, 2);
            if (sel.EndsWith(" "))
            {
                sellength += 1;
            }
            if (movedback) //account for -1 
            {
                sellength += 1;
            }

            HexTextBox.Select(selidx, sellength);
        }

        public int GetOffset()
        {
            var selidx = HexTextBox.SelectionStart;
            if (selidx + 3 > HexTextBox.Text.Length)
            {
                return Data.Length;
            }
            var sel = HexTextBox.Text.Substring(0, selidx).Replace(" ", "").Replace("\n", "").Replace("\r", ""); ;
            return sel.Length / 2;
        }
        public int GetDecodedTextOffset()
        {
            var offset = GetOffset();
            var count = offset / BytesPerLine;
            count = count * 2;
            return offset + count;
        }
        public int GetDecodedTextByteOffset()
        {
            var selidx = DecodedTextBox.SelectionStart;
            var sel = DecodedTextBox.Text.Substring(0, selidx).Replace(" ", "").Replace("\n", "").Replace("\r", "");
            return sel.Length * 3;
        }
        public void GoToOffset(int offset, int selectionlength = 1)
        {
            var c = HexTextBox.Text.Substring(0, (offset * 3)).Split('\r').Length;
            c = (c != 1) ? c - 1 : 0;
            offset = (offset * 3) + c;
            var length = selectionlength * 3;
            HexTextBox.Select(offset, length);
            FixHexSelection();
            UpdateHexSelection();
            DecodedTextBox.ScrollToCaret();
            HexTextBox.ScrollToCaret();
            OffsetTextBox.ScrollToCaret();
            SelectedBytes = HexUtilties.ConvertHexStringToByteArray(HexTextBox.SelectedText);
        }

        private void HexTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            FixHexSelection();
            SelectedBytes = HexUtilties.ConvertHexStringToByteArray(HexTextBox.SelectedText);
            UpdateHexSelection();
            if (Owner != null)
            {
                Owner.UpdateUI();
            }
        }

        private void DecodedTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTextSelection();
            SelectedBytes = HexUtilties.ConvertHexStringToByteArray(HexTextBox.SelectedText);
            if (Owner != null)
            {
                Owner.UpdateUI();
            }
        }

        private void HexTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSizes();
        }
    }
}
