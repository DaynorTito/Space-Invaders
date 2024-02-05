using Microsoft.UI.Xaml.Input;
using SpaceInvadersDaynorTito.Model;
using SpaceInvadersDaynorTito.ViewModel;

namespace SpaceInvadersDaynorTito;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        //MainViewModel vm = new MainViewModel(this);
        PlayerShip ship = PlayerShip.getInstance();
        ship.PositionX = 450;
        ship.PositionY = 360;
        DataContext = ship;

    }

    public void Grid_KeyLeft(object sender, KeyRoutedEventArgs e)
    {
        switch (e.Key)
        {
            case Windows.System.VirtualKey.Left:
                {
                    if (PlayerShip.getInstance().PositionX >= 20)
                    { 
                        e.Handled = true;
                        PlayerShip.getInstance().PositionX -= 10;
                    }
                    break;
                }
            case Windows.System.VirtualKey.Right:
                {
                    if (PlayerShip.getInstance().PositionX <= 810)
                    {
                        e.Handled = true;
                        PlayerShip.getInstance().PositionX += 10;
                    }
                    break;
                }
        }
    }
}
