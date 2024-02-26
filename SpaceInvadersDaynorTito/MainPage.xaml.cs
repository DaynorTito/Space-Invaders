using Microsoft.UI.Xaml.Input;
using SpaceInvadersDaynorTito.Model;
using SpaceInvadersDaynorTito.ViewModel;

namespace SpaceInvadersDaynorTito;

public partial class MainPage : Page
{
    private ICommand _irAOtraPaginaCommand;

    public MainPage()
    {
        this.InitializeComponent();
        //MainViewModel vm = new MainViewModel(this);
       
    }
    private void Go_TopScores(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(TopScores));
    }
 
    private void StartGame_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(GameView));
    }
}
