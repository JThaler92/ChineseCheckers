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
        public static async void PlayBackgroundSound(MediaPlayer player)
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            folder = await folder.GetFolderAsync(@"Sound");

            StorageFile backgroundsoundFile = await folder.GetFileAsync("frog.mp3");
            

            player.AutoPlay = true;
            player.Source = MediaSource.CreateFromStorageFile(backgroundsoundFile);
            player.Volume = 0.02; // 0-1  (0.05 current value)
            player.Play();

            
        }
        public static async void PlayCickbuttonSound(MediaPlayer buttonPlayer)
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            folder = await folder.GetFolderAsync(@"Sound");

            StorageFile clicksoundFile = await folder.GetFileAsync("icecube.mp3");

            buttonPlayer.AutoPlay = true;
            buttonPlayer.Source = MediaSource.CreateFromStorageFile(clicksoundFile);
            buttonPlayer.Volume = 0.05; // 0-1  (0.05 current value)
            buttonPlayer.Play();
        }
    }
}   
