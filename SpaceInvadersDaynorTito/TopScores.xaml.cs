using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SpaceInvadersDaynorTito.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Formats.Asn1.AsnWriter;
using SpaceInvadersDaynorTito.Services;


namespace SpaceInvadersDaynorTito;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class TopScores : Page
{
    private ScoreFileManager scoreFileManager;

    public ObservableCollection<Score> Scores { get; set; }

    public TopScores()
    {
        this.InitializeComponent();
        Scores = new ObservableCollection<Score>();
        scoreFileManager = new ScoreFileManager();

        LoadScoresFromFile();
    }

    private void LoadScoresFromFile()
    {
        var scores = scoreFileManager.LoadScores();
        foreach (Score score in scores)
        {
            Scores.Add(score);
        }
    }
    public void Back_Menu(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }

}
