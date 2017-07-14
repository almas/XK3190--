using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace XmWeightForm.log
{
    public class VoiceHelper
    {
        public static void PlayVoice()
        {

            try
            {
                string filePath = Application.StartupPath + @"\voice\提示.wav";
                if (File.Exists(filePath))
                {
                    SoundPlayer simpleSound = new SoundPlayer(filePath);
                    simpleSound.Play();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex.Message);
            }
        }
    }
}
