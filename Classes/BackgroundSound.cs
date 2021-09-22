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
    class BackgroundSound
    {
        public static async void PlayBackgroundSound(MediaPlayer player)
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            folder = await folder.GetFolderAsync(@"Sound");

            StorageFile file = await folder.GetFileAsync("frog.mp3");

            player.AutoPlay = true;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Volume = 0.015; // 0-1  (0.015 current value)
            player.Play();
        }
    }
}    
