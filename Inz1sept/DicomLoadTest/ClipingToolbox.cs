﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace MainWindow
{
   
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [Designer(typeof(UserControlDesigner))]
    public partial class ClipingToolbox : GroupBox
    {
        public delegate void EventHandler(object sender, ClipingEventArgs e);
        public EventHandler<ClipingEventArgs> ClipingOperationEventHandlerDelegate;

        private TableLayoutPanel _panel;
        public ClipingToolbox() : base()
        {
            _panel = new TableLayoutPanel();
            _panel.AutoSize = true;
            _panel.Dock = DockStyle.Top;


            this.Controls.Add(_panel);

            InitializeComponent();

           
                        _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
                        _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42));
                        _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42));

                        _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
                        _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
                        _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));

                        _panel.Controls.Add(xLabel);
                        _panel.SetCellPosition(xLabel,new TableLayoutPanelCellPosition(0,0));
                        xLabel.AutoSize = true;
                        _panel.Controls.Add(XClipingTrackBar1);
                        _panel.SetCellPosition(XClipingTrackBar1, new TableLayoutPanelCellPosition( 1,0));
                        _panel.Controls.Add(XClipingTrackBar2);
                        _panel.SetCellPosition(XClipingTrackBar2, new TableLayoutPanelCellPosition(2,0));

                        _panel.Controls.Add(yLabel);
                        _panel.SetCellPosition(yLabel, new TableLayoutPanelCellPosition(0, 1));
                        zLabel.AutoSize = true;
                        _panel.Controls.Add(YClipingTrackBar1);
                        _panel.SetCellPosition(YClipingTrackBar1, new TableLayoutPanelCellPosition(1, 1));
                        _panel.Controls.Add(YClipingTrackBar2);
                        _panel.SetCellPosition(YClipingTrackBar2, new TableLayoutPanelCellPosition(2, 1));

                        _panel.Controls.Add(zLabel);
                        _panel.SetCellPosition(zLabel, new TableLayoutPanelCellPosition(0, 2));
                        zLabel.AutoSize = true;
                        _panel.Controls.Add(ZClipingTrackBar1);
                        _panel.SetCellPosition(ZClipingTrackBar1, new TableLayoutPanelCellPosition(1, 2));
                        _panel.Controls.Add(ZClipingTrackBar2);
                        _panel.SetCellPosition(ZClipingTrackBar2, new TableLayoutPanelCellPosition(2, 2));
        }

        public void InitialiseClipingToolbox(IList<double> sizeList)
        {
            if (sizeList.Count != 3)
                throw new ArgumentException("Invalid size List length. Expected: 3 for all dimensions.");
            XClipingTrackBar1.Maximum = (int)(sizeList[0] / 2);
            XClipingTrackBar2.Maximum = (int)(sizeList[0] / 2);

            YClipingTrackBar1.Maximum = (int)(sizeList[1] / 2);
            YClipingTrackBar2.Maximum = (int)(sizeList[1] / 2);

            ZClipingTrackBar1.Maximum = (int)(sizeList[2] / 2);
            ZClipingTrackBar2.Maximum = (int)(sizeList[2] / 2);
        }

        private void InvokeOnHandler(EClipingModuleOperationType type, int value)
        {
            if (this.ClipingOperationEventHandlerDelegate != null)
            {
                EventArgs e2 = new ClipingEventArgs()
                {
                    Type = type,
                    Position = value,
                };
                object[] args = new object[] { null, e2 };
                foreach (Delegate handler in this.ClipingOperationEventHandlerDelegate.GetInvocationList())
                {
                    handler.DynamicInvoke(args);
                }
            }
        }

        private void XClipingTrackBar1_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.X1, XClipingTrackBar1.Value);
        }
     
        private void XClipingTrackBar2_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.X2, XClipingTrackBar2.Value);
        }

        private void YClipingTrackBar1_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.Y1, YClipingTrackBar1.Value);
        }

        private void YClipingTrackBar2_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.Y2, YClipingTrackBar2.Value);
        }

        private void ZClipingTrackBar1_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.Z1, ZClipingTrackBar1.Value);
        }

        private void ZClipingTrackBar2_Scroll(object sender, EventArgs e)
        {
            InvokeOnHandler(EClipingModuleOperationType.Z2, ZClipingTrackBar2.Value);
        }
  
    }

    // my designer
    public class UserControlDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (this.Control is ClipingToolbox)
            {
                this.EnableDesignMode((ClipingToolbox)(this.Control), "clipingToolbox");
            }
        }
    }

}
