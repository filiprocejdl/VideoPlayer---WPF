using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer___test
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() 
{ 
    InitializeComponent(); 
    IsPlaying(false); 
} 
 
private void IsPlaying(bool flag) 
{ 
    btnPlay.IsEnabled = flag; 
    btnMoveBack.IsEnabled = flag; 
    btnMoveForward.IsEnabled = flag; 
} 
 
private void btnPlay_Click(object sender, RoutedEventArgs e) 
{ 
    IsPlaying(true); 
    if (btnPlay.Content.ToString() == "Play") 
    { 
        MediaPlayer.Play(); 
        btnPlay.Content = "Pause"; 
    } 
    else 
    { 
        MediaPlayer.Pause(); 
        btnPlay.Content = "Play"; 
    } 
}

 private void btnMute_Click(object sender, RoutedEventArgs e)
    {
        IsPlaying(true);
            if (btnPlay.Content.ToString() == "Mute")
            {
                MediaPlayer.IsMuted = false;
                btnPlay.Content = "Unmute";
            }
            else
            {
                MediaPlayer.IsMuted = true;
                btnPlay.Content = "Mute";
            }
            


    }

private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
{
            MediaPlayer.Volume = (double)volumeSlider.Value;
}



        private void btnMoveBack_Click(object sender, RoutedEventArgs e) 
{ 
    MediaPlayer.Position -= TimeSpan.FromSeconds(10); 
} 
 
private void btnMoveForward_Click(object sender, RoutedEventArgs e) 
{ 
    MediaPlayer.Position += TimeSpan.FromSeconds(10); 
} 
 
private void btnOpen_Click(object sender, RoutedEventArgs e) 
{ 
    // Configure open file dialog box 
    Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); 
    dialog.FileName = "Videos"; // Default file name 
    dialog.DefaultExt = ".WMV"; // Default file extension 
    dialog.Filter = "WMV file (.wm)|*.wmv"; // Filter files by extension  
 
    // Show open file dialog box 
    Nullable<bool> result = dialog.ShowDialog(); 
 
    // Process open file dialog box results  
    if (result == true) 
    { 
        // Open document  
        MediaPlayer.Source = new Uri(dialog.FileName); 
        btnPlay.IsEnabled = true; 
    } 
}
    }
}
