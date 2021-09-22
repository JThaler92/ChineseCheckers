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
    class ButtonclickSounds
    {
        public static async void PlayButtonClickSounds(MediaPlayer buttonPlayer)
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            folder = await folder.GetFolderAsync(@"Sound");

            StorageFile file = await folder.GetFileAsync("icecube.mp3");

            buttonPlayer.AutoPlay = true;
            buttonPlayer.Source = MediaSource.CreateFromStorageFile(file);
            buttonPlayer.Volume = 0.010; // 0-1  (0.05 current value)
            buttonPlayer.Play();
        }

    }
}
