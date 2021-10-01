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


    }
}
