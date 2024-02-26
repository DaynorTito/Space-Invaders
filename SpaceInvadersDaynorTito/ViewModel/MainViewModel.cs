using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Input;
using SpaceInvadersDaynorTito.Model;

namespace SpaceInvadersDaynorTito.ViewModel;
public class MainViewModel : ViewModelBase
{
    private PlayerShip ship;

    public PlayerShip Ship
    {
        get => ship;
        set => SetProperty(ref ship, value, nameof(Ship));
    }
}
