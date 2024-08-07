﻿using RadicalCore.Gamefiles;
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
            if (Data.Length > 10000)
            {
                HexTextBox.Text = "File too large to show hex.";
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
            if (Data == null) return;
            HexTextBox.Text = HexUtilties.GetBytesString(Data, BytesPerLine);
            DecodedTextBox.Text = HexUtilties.GetDecodedTextString(Data, BytesPerLine);
        }

        public void UpdateOffsetsTextbox()
        {
            if (Data == null) return;
            OffsetsLabel.Text = HexUtilties.GetOffsetsString(BytesPerLine, NumberType);
            OffsetTextBox.Text = HexUtilties.GetOffsetString(Data.Length, BytesPerLine, NumberType);
        }

        private void UpdateSizes()
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

    public static class HexUtilties
    {
        public class ByteObject
        {
            public byte[] Bytes { get; set; }
            public string Binary { get { try { return Convert.ToString(Bytes[0], 2).PadLeft(8, '0'); } catch { return "Invalid"; } } }
            public string Int8 { get { try { return Bytes[0].ToString(); } catch { return "Invalid"; } } } //
            public string Uint8 { get { try { return Bytes[0].ToString(); } catch { return "Invalid"; } } } //idk if this is the correct way to do this for unsigned or signed
            public string Int16 { get { try { return BitConverter.ToInt16(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Uint16 { get { try { return BitConverter.ToUInt16(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Int32 { get { try { return BitConverter.ToInt32(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Uint32 { get { try { return BitConverter.ToUInt32(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Int64 { get { try { return BitConverter.ToInt64(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Uint64 { get { try { return BitConverter.ToUInt64(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Float { get { try { return BitConverter.ToSingle(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string Double { get { try { return BitConverter.ToDouble(Bytes, 0).ToString(); } catch { return "Invalid"; } } }
            public string ASCII { get { try { return GetDecodedTextString(Bytes) == string.Empty ? "Invalid" : GetDecodedTextString(Bytes); } catch { return "Invalid"; } } }
            public string Unicode { get { try { return Encoding.Unicode.GetString(Bytes) == string.Empty ? "Invalid" : Encoding.Unicode.GetString(Bytes); } catch { return "Invalid"; } } }

            public ByteObject(byte[] bs)
            {
                Bytes = bs;
            }
        }

        public static string GetIntNumber(NumberType type, int number)
        {
            switch (type)
            {
                case NumberType.Decimal:
                    return number.ToString();
                case NumberType.Hex:
                    return number.ToString("X2");
                case NumberType.Octal:
                    throw new NotImplementedException();
                default:
                    throw new Exception();
            }
        }

        public static string GetBytesString(byte[] data)
        {
            if (data == null) return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2") + " ");
            }
            return sb.ToString();
        }
        public static string GetBytesString(byte[] data, int bytePerLine)
        {
            if (data == null) return "";

            StringBuilder sb = new StringBuilder();
            StringBuilder hexStr = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i % bytePerLine == 0)
                {
                    if (i != 0) { sb.AppendLine(hexStr.ToString().Trim()); }
                    hexStr.Clear();
                }
                hexStr.Append(data[i].ToString("X2") + " ");
                if (i == data.Length - 1)
                {
                    sb.AppendLine(hexStr.ToString().Trim());
                }
            }

            return sb.ToString();
        }
        public static string GetOffsetsString(int bytesPerLine, NumberType type)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytesPerLine; i++)
            {
                switch (type)
                {
                    case NumberType.Decimal:
                        sb.Append(i.ToString().PadLeft(2, '0') + " ");
                        break;
                    case NumberType.Hex:
                        sb.Append(i.ToString("X2") + " ");
                        break;
                    case NumberType.Octal:
                        throw new NotImplementedException();
                    default:
                        throw new Exception();
                }
            }
            return sb.ToString().Trim();
        }
        public static string GetOffsetString(int count, int bytesPerLine, NumberType type)
        {
            if (count <= 0 || bytesPerLine <= 0) return "";

            StringBuilder sb = new StringBuilder();
       
            float linecount = count / bytesPerLine;
            if (!(linecount == Math.Floor(linecount)))
            {
                linecount = (int)linecount + 1;
            }

            for (int i = 0; i <= linecount; i++)
            {
                switch (type)
                {
                    case NumberType.Decimal:
                        sb.AppendLine(i.ToString().PadLeft(8, '0'));
                        break;
                    case NumberType.Hex:
                        sb.AppendLine(i.ToString("X8"));
                        break;
                    case NumberType.Octal:
                        throw new NotImplementedException();
                    default:
                        throw new Exception();
                }
            }
            return sb.ToString();
        }
        public static string GetDecodedTextString(byte[] data)
        {
            if (data == null) return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                var cRes = Convert.ToChar(data[i]);
                if (char.IsWhiteSpace(cRes)) { cRes = '.'; }
                sb.Append(cRes);
            }
            return sb.ToString();
        }
        public static string GetDecodedTextString(byte[] data, int bytesPerLine)
        {
            if (data == null) return "";

            StringBuilder sb = new StringBuilder();
            StringBuilder texStr = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i % bytesPerLine == 0)
                {
                    if (i != 0) { sb.AppendLine(texStr.ToString()); }
                    texStr.Clear();
                }
                if (data[i] == 0)
                {
                    texStr.Append(".");
                }
                else
                {
                    var cRes = Convert.ToChar(data[i]);
                    if (char.IsWhiteSpace(cRes)) { cRes = '.'; }
                    texStr.Append(cRes);
                }
                if (i == data.Length - 1)
                {
                    sb.AppendLine(texStr.ToString().Trim());
                }
            }
            return sb.ToString();
        }

        //stolen: https://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array/321404
        public static byte[] ConvertHexStringToByteArray(string inputString)
        {
            var hexString = inputString.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            try
            {
                byte[] retval = new byte[hexString.Length / 2];
                for (int i = 0; i < hexString.Length; i += 2)
                    retval[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
                return retval;
            }
            catch
            {
                return new byte[0];
            }
        }
    }
}
