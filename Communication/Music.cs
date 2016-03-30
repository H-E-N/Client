using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
    public partial class Music : CCSkinMain
    {
        VoiceCapture vc;
        public Music()
        {
            InitializeComponent();
        }

        private void Music_Load(object sender, EventArgs e)
        {
            vc = new VoiceCapture();
            vc.InitVoice();
            try
            {
                vc.StartVoiceCapture();
            }
            catch (Exception ex) { }
        }
    }
}
