using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

class SyncTextBox : TextBox
{
    public Control[] LinkedTextBoxes { get; set; }

    private static bool scrolling;   // In case buddy tries to scroll us
    int WM_MOUSEWHEEL = 0x20a; // or 522
    int WM_VSCROLL = 0x115; // or 277
    
    public SyncTextBox()
    {
        Multiline = true;
        //SetStyle(ControlStyles.UserPaint, true);
    }

    //protected override void OnPaint(PaintEventArgs e)
    //{
    //    SolidBrush drawBrush = new SolidBrush(ForeColor); //Use the ForeColor property
    //    e.Graphics.DrawString(this.Text, this.Font, drawBrush, 0f, 0f); //Use the Font property
    //}

    protected override void WndProc(ref Message m)
    {
        //Trap WM_VSCROLL and WM_MOUSEWHEEL message and pass to buddy
        if (LinkedTextBoxes != null)
        {
            if (m.Msg == WM_MOUSEWHEEL)  //mouse wheel 
            {

                if ((int)m.WParam < 0)  //mouse wheel scrolls down
                    SendMessage(Handle, (int)0x0115, new IntPtr(1), new IntPtr(0)); //WParam: 1- scroll down, 0- scroll up
                else if ((int)m.WParam > 0)
                    SendMessage(Handle, (int)0x0115, new IntPtr(0), new IntPtr(0));
                return; //prevent base.WndProc() from messing synchronization up 
            }
            else if (m.Msg == WM_VSCROLL)
            {
                foreach (Control ctr in LinkedTextBoxes)
                {
                    if (ctr != this && !scrolling && ctr != null && ctr.IsHandleCreated)
                    {
                        scrolling = true;
                        SendMessage(ctr.Handle, m.Msg, m.WParam, m.LParam);
                        scrolling = false;
                    }
                }
            }
        }
        base.WndProc(ref m);
    }
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
}