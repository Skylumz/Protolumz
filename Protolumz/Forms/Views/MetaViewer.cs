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
    public partial class MetaViewer : UserControl, INodeView
    {
        public MetaViewer()
        {
            InitializeComponent();
        }

        public void LoadMeta(MetaData data)
        {
            var props = data.GetType().GetProperties();
            int y = 0;
            foreach(var prop in props)
            {
                Label l = new Label();
                l.Text = prop.Name;
                l.Location = new Point(10, y);
                y += 20;
                Controls.Add(l);
            }
        }

        public void LoadNode(P3DNode node)
        {
            var meta = (node as MetaObjectDataNode).GetMeta();
            LoadMeta(meta);
        }
    }
}
