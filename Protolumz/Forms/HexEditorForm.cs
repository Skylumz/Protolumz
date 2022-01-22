﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO
//color disabled textbox text for offset stuff
//fix UpdateTextSelection()

namespace Protolumz
{
    public partial class HexEditorForm : Form
    {
        private string FilePath { get; set; }
        private string FileName 
        { 
            //some filenames may be invalid due to p3d hex form
            get 
            {
                var split = FilePath.Split('\\');
                return split[split.Length - 1];
            } 
        }
        private byte[] Data { get; set; }

        private byte[] SelectedBytes { get; set; }
        private NumberType NumberType = NumberType.Decimal;
        
        private int bytesperline;
        private int BytesPerLine
        {
            get { return bytesperline; }
            set
            {
                bytesperline = value;
                //Task.Run(() =>
                //{
                    UpdateOffsetsTextBox();
                    UpdateHexTextBox();
                //});
            }
        }

        public HexEditorForm(Form owner, string fp, byte[] data)
        {
            InitializeComponent();

            Owner = owner;
            FilePath = fp;
            Data = data;

            InitForm();
        }

        private void InitForm()
        {
            Icon = Owner.Icon;
            Text = "Hex Editor - Skylumz - " + FileName;
            OffsetLabel.Font = new Font(FontFamily.GenericMonospace, OffsetLabel.Font.Size); //makes everything aligned 
            OffsetsLabel.Font = new Font(FontFamily.GenericMonospace, OffsetsLabel.Font.Size); //makes everything aligned 
            DecodedTextLabel.Font = new Font(FontFamily.GenericMonospace, OffsetTextBox.Font.Size); //makes everything aligned 
            
            HexTextBox.Font = new Font(FontFamily.GenericMonospace, HexTextBox.Font.Size); //makes everything aligned 
            DecodedTextBox.Font = new Font(FontFamily.GenericMonospace, DecodedTextBox.Font.Size); //makes everything aligned 
            OffsetTextBox.LinkedTextBoxes = new Control[2] { HexTextBox, DecodedTextBox };
            HexTextBox.LinkedTextBoxes = new Control[2] { OffsetTextBox, DecodedTextBox };
            DecodedTextBox.LinkedTextBoxes = new Control[2] { OffsetTextBox, HexTextBox };

            NumberTypeComboBox.SelectedIndex = 0;
            SearchModeComboBox.SelectedIndex = 0;
            BytesPerLine = 16; //this will trigger loading the data
        }

        private void UpdateHexTextBox()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateHexTextBox()));
            }
            else
            {
                if (Data == null) { return; }

                HexTextBox.Text = HexUtilties.GetBytesString(Data, BytesPerLine);
                DecodedTextBox.Text = HexUtilties.GetDecodedTextString(Data, BytesPerLine);

                var htbSize = TextRenderer.MeasureText(HexTextBox.Text, HexTextBox.Font);
                var dtbSize = TextRenderer.MeasureText(DecodedTextBox.Text, DecodedTextBox.Font);
                HexTextBox.Width = htbSize.Width + 5;
                DecodedTextLabel.Width = dtbSize.Width + 15;
                DecodedTextBox.Width = dtbSize.Width + 15;
                var hexwidth = OffsetTextBox.Width + HexTextBox.Width + DecodedTextBox.Width;
                MainSplitContainer.SplitterDistance = hexwidth;
                var totalwidth = hexwidth + MainSplitContainer.Panel2.Width + 20;
                this.Width = totalwidth;
            }
        }
        private void UpdateOffsetsTextBox()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateOffsetsTextBox()));
            }
            else
            {
                OffsetsLabel.Text = HexUtilties.GetOffsetsString(BytesPerLine, NumberType);
                OffsetTextBox.Text = HexUtilties.GetOffsetString(Data.Length, BytesPerLine, NumberType);
                var otbSize = TextRenderer.MeasureText(OffsetTextBox.Text, OffsetTextBox.Font);
                var oltbSize = TextRenderer.MeasureText(OffsetsLabel.Text, OffsetsLabel.Font);
                OffsetLabel.Width = otbSize.Width + 5;
                OffsetTextBox.Width = otbSize.Width + 5;
                OffsetsLabel.Width = oltbSize.Width + 5;
            }
        }
        private void UpdateUI()
        {
            if (SelectedBytes == null) return;
            LengthStatusLabel.Text = "Length: " + HexUtilties.GetIntNumber(NumberType, SelectedBytes.Length);
            OffsetStatusLabel.Text = "Offset: " + HexUtilties.GetIntNumber(NumberType, GetOffset());
            var hb = new HexUtilties.ByteObject(SelectedBytes);
            SelectionPropertyGrid.SelectedObject = hb;
        }
        private void UpdateBytesPerLine()
        {
            int bpl = 0;
            int.TryParse(BytePerLineComboBox.Text, out bpl);
            if (bpl <= 15)
            {
                if (BytesPerLine == 16) { }
                else { BytesPerLine = 16; }
            }
            else if (bpl != BytesPerLine)
            {
                BytesPerLine = bpl;
            }
            else { }
        }
        private void UpdateNumberType()
        {
            switch (NumberTypeComboBox.Text)
            {
                case "Decimal":
                    NumberType = NumberType.Decimal;
                    break;
                case "Hex":
                    NumberType = NumberType.Hex;
                    break;
                default:
                    MessageBox.Show("TODO");
                    return;
            }

            UpdateOffsetsTextBox();
            UpdateUI();
        }

        private void UpdateHexSelection()
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
        private void UpdateTextSelection()
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
        private void FixHexSelection()
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
            sel = HexTextBox.Text.Substring(HexTextBox.SelectionStart + HexTextBox.SelectionLength, 2);
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

        private int GetOffset()
        {
            var selidx = HexTextBox.SelectionStart;
            if (selidx + 3 > HexTextBox.Text.Length)
            {
                return Data.Length;
            }
            var sel = HexTextBox.Text.Substring(0, selidx).Replace(" ", "").Replace("\n", "").Replace("\r", ""); ;
            return sel.Length / 2;
        }
        private int GetDecodedTextOffset()
        {
            var offset = GetOffset();
            var count = offset / BytesPerLine;
            count = count * 2;
            return offset + count;
        }
        private int GetDecodedTextByteOffset()
        {
            var selidx = DecodedTextBox.SelectionStart;
            var sel = DecodedTextBox.Text.Substring(0, selidx).Replace(" ", "").Replace("\n", "").Replace("\r", "");
            return sel.Length * 3;
        }
        private void GoToOffset(int offset, int selectionlength = 1)
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
            UpdateUI();
        }

        private void Search()
        {
            List<SearchByte> items = null;
            switch (SearchModeComboBox.Text)
            {
                case "byte":
                    items = SearchByte(SearchTextBox.Text);
                    break;
                case "int16":
                    items = SearchInt16(SearchTextBox.Text);
                    break;
                case "uint16":
                    items = SearchUint16(SearchTextBox.Text);
                    break;
                case "int32":
                    items = SearchInt32(SearchTextBox.Text);
                    break;
                case "uint32":
                    items = SearchUint32(SearchTextBox.Text);
                    break;
                case "int64":
                    items = SearchInt64(SearchTextBox.Text);
                    break;
                case "uint64":
                    items = SearchUint64(SearchTextBox.Text);
                    break;
                case "float":
                    items = SearchFloat(SearchTextBox.Text);
                    break;
            }

            if (items == null)
            {
                MessageBox.Show("Failure to convert searched term to: " + SearchModeComboBox.Text);
            }
            else
            {
                UpdateSearchResults(items);
            }
        }
        private void UpdateSearchResults(List<SearchByte> items)
        {
            SearchResultsPanel.Controls.Clear();
            var countlbl = new Label();
            countlbl.Text = "Results: " + items.Count.ToString() + " found";
            countlbl.Location = new Point(0, 0);
            SearchResultsPanel.Controls.Add(countlbl);
            SearchToolPanel.Height = 100;

            if (items.Count == 0) return;

            var srpanels = new List<Panel>();
            foreach(var item in items)
            {
                Panel sr = new Panel();
                Button btn = new Button();
                btn.Tag = item;
                btn.Text = "GoTo";
                btn.Dock = DockStyle.Fill;
                btn.Click += GoTo_ButtonClick;
                sr.Controls.Add(btn);
                Label lbl = new Label();
                lbl.Text = item.ToString();
                lbl.Dock = DockStyle.Left;
                sr.Controls.Add(lbl);
                sr.Dock = DockStyle.Bottom;
                sr.Height = 25;
                srpanels.Add(sr);
            }

            int locy = 25;
            foreach (var panel in srpanels)
            {
                panel.Location = new Point(5, locy);
                SearchResultsPanel.Controls.Add(panel);
                SearchToolPanel.Height += panel.Height;
                locy += panel.Height;
            }
        }
        private List<SearchByte> SearchByte(string term)
        {
            byte value;
            if (!byte.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == value)
                {
                    items.Add(new SearchByte(Data[i], i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchInt16(string term)
        {
            short value;
            if (!short.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 2 > Data.Length) continue;

                var res = BitConverter.ToInt16(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchUint16(string term)
        {
            ushort value;
            if(!ushort.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 2 > Data.Length) continue;

                var res = BitConverter.ToUInt16(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchInt32(string term)
        {
            int value;
            if (!int.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 4 > Data.Length) continue;

                var res = BitConverter.ToInt32(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchUint32(string term)
        {
            uint value;
            if (!uint.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 4 > Data.Length) continue;

                var res = BitConverter.ToUInt32(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchInt64(string term)
        {
            long value;
            if (!long.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 8 > Data.Length) continue;

                var res = BitConverter.ToInt64(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchUint64(string term)
        {
            ulong value;
            if (!ulong.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 8 > Data.Length) continue;

                var res = BitConverter.ToUInt64(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }
        private List<SearchByte> SearchFloat(string term)
        {
            float value;
            if (!float.TryParse(term, out value))
            {
                return null;
            }

            var items = new List<SearchByte>();

            for (int i = 0; i < Data.Length; i++)
            {
                if (i + 4 > Data.Length) continue;

                var res = BitConverter.ToSingle(Data, i);
                if (res == value)
                {
                    items.Add(new SearchByte(res, i));
                }
            }

            return items;
        }

        private void GoTo_ButtonClick(object sender, EventArgs e)
        {
            var sb = ((Button)sender).Tag as SearchByte;
            GoToOffset(sb.Offset, sb.GetDataLength());
        }

        private void SaveAs()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = FileName + ".data";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var path = sfd.FileName;
                    File.WriteAllBytes(path, Data);
                }
            }
        }

        private void HexTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            FixHexSelection();
            SelectedBytes = HexUtilties.ConvertHexStringToByteArray(HexTextBox.SelectedText);
            UpdateHexSelection();
            UpdateUI();
        }
        private void HexTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateUI();
        }
        private void DecodedTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTextSelection();
            SelectedBytes = HexUtilties.ConvertHexStringToByteArray(HexTextBox.SelectedText);
            UpdateUI();
        }

        private void BytePerLineComboBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateBytesPerLine();
        }
        private void BytePerLineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBytesPerLine();
        }
        private void BytePerLineComboBox_TextUpdate(object sender, EventArgs e)
        {
            UpdateBytesPerLine();
        }
        private void NumberTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNumberType();
        }
    
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
    }

    public enum NumberType
    {
        [Description("h")]
        Hex,
        [Description("d")]
        Decimal,
        [Description("o")]
        Octal
    }
    public class SearchByte
    {
        public object Data;
        public int Offset;

        public SearchByte(object data, int offset)
        {
            Data = data;
            Offset = offset;
        }

        public int GetDataLength()
        {
            if (Data is short || Data is ushort)
            {
                return 2;
            }
            else if (Data is int || Data is uint || Data is float)
            {
                return 4;
            }
            else if (Data is long || Data is ulong)
            {
                return 8;
            }
            else //byte
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return string.Format("Offset {0}", Offset);
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
