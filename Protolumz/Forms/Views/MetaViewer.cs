using Protolumz.Forms.Views;
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
            MetaData data = viewNode.GetMeta();

            Control control = null;

            if(data is PropRestoreArray)
            {
                var pv = new PropsView(data as PropRestoreArray);
                control = pv;
            }
            else
            {
                Label l = new Label();
                l.Text = "Uknown Meta";
                control = l;
            }

            control.Dock = DockStyle.Fill;
            Controls.Add(control);
        }

        public void LoadNode(P3DNode node)
        {
            viewNode = (node as MetaObjectDataNode);
            LoadMeta();
        }
    }
}
