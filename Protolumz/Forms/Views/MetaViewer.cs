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
        private MetaObjectDataNode viewNode;

        public MetaViewer()
        {
            InitializeComponent();
        }

        public void LoadMeta()
        {
            var data = viewNode.GetMeta();

            if (data == null)
            {
                Label l = new Label();
                l.Text = "Uknown Meta";
                l.Location = new Point(10, 0);
                Controls.Add(l);
                return;
            }

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
            viewNode = (node as MetaObjectDataNode);
            LoadMeta();
        }
    }
}
