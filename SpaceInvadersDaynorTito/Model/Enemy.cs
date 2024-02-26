using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace SpaceInvadersDaynorTito.Model;
public enum Direction
{
    Left,
    Right
}
public class Enemy : INotifyPropertyChanged
{
    private bool _alive;
    private Direction _direction;

    public Enemy(Image sprite, Rectangle hitBox, Direction direction)
    {
        Sprite = sprite;
        HitBox = hitBox;
        Alive = true;
        Direction = direction;
    }

    public Image Sprite { get; }
    public Rectangle HitBox { get; set; }

    public bool Alive
    {
        get => _alive;
        set
        {
            if (_alive != value)
            {
                _alive = value;
                OnPropertyChanged(nameof(Alive));
            }
        }
    }

    public Direction Direction
    {
        get => _direction;
        set
        {
            if (_direction != value)
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Move(int speed)
    {
        int displacement = Direction == Direction.Right ? speed : -speed;
        HitBox = new Rectangle(HitBox.X + displacement, HitBox.Y, HitBox.Width, HitBox.Height);
    }
}
