using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public interface IAudio
    {
        void PlayAudioFiles(string[] filePaths);
        void StopPlaying();
        void PauseAudioFile();
        void ContinueAudioFile();
    }
}
