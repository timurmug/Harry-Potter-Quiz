using System;
using Xamarin.Forms;
using Android.Media;
using Android.Content.Res;
using System.Threading;
using Quiz.Droid;

[assembly: Dependency(typeof(AudioDroid))]
namespace Quiz.Droid
{
    class AudioDroid : IAudio
    {
        MediaPlayer player = new MediaPlayer();

        public AudioDroid()
        {

        }

        public void StopPlaying()
        {
            player.Reset();
        }

        public void PauseAudioFile()
        {
            player.Pause();
        }

        public void PlayAudioFiles(string[] filePaths)
        {
            int index = 0;
            player.Reset();
            
            var fd = global::Android.App.Application.Context.Assets.OpenFd(filePaths[index]);
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();

            player.Completion += (s, e) =>
            {
                player.Reset();
                index++;
                if (index>=filePaths.Length)
                {
                    index = 0;
                }

                var fd2 = global::Android.App.Application.Context.Assets.OpenFd(filePaths[index]);
                player.SetDataSource(fd2.FileDescriptor, fd2.StartOffset, fd2.Length);
                player.Prepare();
                player.Start();
            };
            player.Start();
        }

        public void ContinueAudioFile()
        {
            player.Start();
        }
    }
}