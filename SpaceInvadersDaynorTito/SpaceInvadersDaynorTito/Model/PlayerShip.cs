using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersDaynorTito.Model;
public class PlayerShip : INotifyPropertyChanged 
{
    private int Positionx;
    private int Positiony;
    private int Speed;
    public static volatile PlayerShip instance;

    
    public int PositionX
    {
        get { return Positionx; }
        set
        {
            Positionx = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PositionX)));
        }
    }

    public int PositionY
    {
        get { return Positiony; }
        set
        {
            Positiony = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PositionY)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public static PlayerShip getInstance()
    {
        if (instance is null)
        {
            instance = new PlayerShip();
        }
        return instance;
    }
}
