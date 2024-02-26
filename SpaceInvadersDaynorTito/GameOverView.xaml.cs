using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SpaceInvadersDaynorTito.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace SpaceInvadersDaynorTito;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class GameOverView : Page
{
    private int points;
    private String namePlayer;
    private ScoreFileManager fileManager;
    public GameOverView()
    {
        this.InitializeComponent();
        points = 0;
        namePlayer = "Empty field";
        fileManager = new ScoreFileManager();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        int puntaje;
        if (e.Parameter != null)
        {
            puntaje = Convert.ToInt32(e.Parameter);
            points = puntaje;
            TitleScore.Text = $"Tu puntaje fue: {puntaje}";
        }
    }
  
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
        fileManager.AddScore(txtName.Text, points);
    }
}
