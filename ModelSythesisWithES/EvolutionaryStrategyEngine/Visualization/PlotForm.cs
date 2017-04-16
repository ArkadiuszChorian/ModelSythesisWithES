using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace EvolutionaryStrategyEngine.Visualization
{
    public class PlotForm : Form
    {
        public PlotForm()
        {
            this.InitializeComponent();
            var myModel = new PlotModel { Title = "Example 1" };
            PlotModel s = new PlotModel();
            s.Series.Add(new FunctionSeries());
            myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this._plot1.Model = myModel;
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._plot1 = new OxyPlot.WindowsForms.PlotView {Dock = System.Windows.Forms.DockStyle.Fill};
            this.SuspendLayout();
            // 
            // plot1
            // 
            this._plot1.Location = new System.Drawing.Point(0, 0);
            this._plot1.Name = "_plot1";
            this._plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this._plot1.Size = new System.Drawing.Size(484, 312);
            this._plot1.TabIndex = 0;
            this._plot1.Text = "plot1";
            this._plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this._plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this._plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this._plot1);
            this.Name = "Form1";
            this.Text = "Example 1 (WindowsForms)";
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView _plot1;
    }
}
