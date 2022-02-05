using System;
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
    public partial class HexEditorForm : Form, IHexViewer
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
        public byte[] Data { get; set; }

        private NumberType NumberType = NumberType.Decimal;

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

            NumberTypeComboBox.SelectedIndex = 0;
            SearchModeComboBox.SelectedIndex = 0;
            HexViewer.Owner = this;
            HexViewer.LoadData(Data);
        }

        public void UpdateUI()
        {
            if (HexViewer.SelectedBytes == null) return;
            LengthStatusLabel.Text = "Length: " + HexUtilties.GetIntNumber(NumberType, HexViewer.SelectedBytes.Length);
            OffsetStatusLabel.Text = "Offset: " + HexUtilties.GetIntNumber(NumberType, HexViewer.CurrentOffset);
            var hb = new HexUtilties.ByteObject(HexViewer.SelectedBytes);
            SelectionPropertyGrid.SelectedObject = hb;
        }
        private void UpdateBytesPerLine()
        {
            int bpl = 0;
            int.TryParse(BytePerLineComboBox.Text, out bpl);
            if (bpl <= 15)
            {
                if (HexViewer.BytesPerLine == 16) { }
                else { HexViewer.BytesPerLine = 16; }
            }
            else if (bpl != HexViewer.BytesPerLine)
            {
                HexViewer.BytesPerLine = bpl;
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

            HexViewer.NumberType = NumberType;
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
            //HexViewer.GoToOffset(sb.Offset, sb.GetDataLength());
            UpdateUI();
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

        private void classParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HexClassCreatorForm hcc = new HexClassCreatorForm(this);
            hcc.Show(this);
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
    

}
