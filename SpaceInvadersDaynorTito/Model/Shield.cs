using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace SpaceInvadersDaynorTito.Model;
public class Shield : INotifyPropertyChanged
{
    private int _life;
    private bool _alive;
    private Image _sprite;
    private Image[] _spritesSequence;
    private int _spriteIndex;

    public Shield(Image[] spritesSequence, Rectangle hitBox)
    {
        _spritesSequence = spritesSequence;
        Sprite = spritesSequence[0];
        _life = spritesSequence.Length * 2;
        _alive = true;
        _spriteIndex = 0;
        HitBox = hitBox;
    }

    public Rectangle HitBox { get; }

    public Image Sprite
    {
        get => _sprite;
        set
        {
            if (_sprite != value)
            {
                _sprite = value;
                OnPropertyChanged(nameof(Sprite));
            }
        }
    }

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

    public event PropertyChangedEventHandler? PropertyChanged;

    public void TakeDamage()
    {
        if (!Alive) { return; }

        --_life;

        if (_life == 0)
        {
            Alive = false;
        }
        else if (_life % 2 == 0)
        {
            Sprite = _spritesSequence[++_spriteIndex];
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
