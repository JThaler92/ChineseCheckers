using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;

namespace ChineseCheckers.Classes
{
    class Sound
    {
        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="player"></param>
        /// <param name="source">sound to play</param>
        /// <param name="volume">volume of sound (0-1)</param>
        /// <param name="loop">if sound should loop or not</param>
        public static async void PlaySound(MediaPlayer player, string source, float volume, bool loop)
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            folder = await folder.GetFolderAsync(@"Sound");

            StorageFile sound = await folder.GetFileAsync(source);

            player.AutoPlay = true;
            player.Source = MediaSource.CreateFromStorageFile(sound);
            player.IsLoopingEnabled = loop;
            player.Volume = volume; // 0-1  (0.05 current value)
            player.Play();
        }

        public static void StopSound(MediaPlayer player)
        {
            player.Pause();
        }

        /// <summary>
        /// Plays sound in new thread
        /// </summary>
        /// <param name="source">sound to play</param>
        /// <param name="volume">volume of sound (0-1)</param>
        /// <param name="loop">if sound should loop or not</param>
        public static void TaskSound(string source, float volume, bool loop)
        {
            MediaPlayer Click = new MediaPlayer();

            Task sound = Task.Run(() =>
            {
                Sound.PlaySound(Click, source, volume, loop);
            });
        }

    }
}
