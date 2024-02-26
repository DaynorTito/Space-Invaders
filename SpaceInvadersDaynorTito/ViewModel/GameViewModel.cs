using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;
using SpaceInvadersDaynorTito.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace SpaceInvadersDaynorTito.ViewModel;
public class GameViewModel : ViewModelBase
{
    private DispatcherTimer gameLoopTimer = new DispatcherTimer();
    private Rectangle _playerHitBox = new Rectangle(500, 600, 50, 50);
    private Rectangle _playerShotHitBox = new Rectangle(520, 650, 5, 15);
    private bool _shotVisible;
    private double _score = 0;
    private ObservableCollection<Enemy> _enemies;
    private ObservableCollection<Shield> _shields;

    public GameViewModel()
    {
        CreateShields();
        CreateEnemies();
        gameLoopTimer.Tick += GameLoopTimer_Tick;
        gameLoopTimer.Interval = TimeSpan.FromMilliseconds(10);
        gameLoopTimer.Start();


    }

    private void GameLoopTimer_Tick(object sender, object e)
    {
        const int enemySpeed = 7;
        bool moveDown = false;
        ObservableCollection<Enemy> ene = new ObservableCollection<Enemy>();

        foreach (Enemy enemy in _enemies)
        {
            if (enemy.Direction == Direction.Right)
            {
                if (enemy.HitBox.X + enemySpeed + enemy.HitBox.Width >= 800)
                {
                    moveDown = true;
                    break;
                }
            }
            else
            {
                if (enemy.HitBox.X - enemySpeed <= 0)
                {
                    moveDown = true;
                    break;
                }
            }
        }
        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemy enem = Enemies[i];
            if (moveDown)
            {
                
                var rectan = new Rectangle(enem.HitBox.X, enem.HitBox.Y + 20, enem.HitBox.Width, enem.HitBox.Height);
                enem.HitBox = rectan;
                var dire = enem.Direction == Direction.Right ? Direction.Left : Direction.Right;
                enem.Direction = dire;
            }
            else
            {
                int displacement = enem.Direction == Direction.Right ? enemySpeed : -enemySpeed;
                var recta = new Rectangle(enem.HitBox.X + displacement, enem.HitBox.Y, enem.HitBox.Width, enem.HitBox.Height);
                enem.HitBox = recta;
            }
            ene.Add(enem);
        }
        Enemies = ene;
    }

    private void CreateShields()
    {
        Image[] spriteSequence = new Image[4];

        Image image0 = new Image();
        image0.Source = new BitmapImage(new Uri("ms-appx:///Assets/Shield0.png"));
        spriteSequence[0] = image0;
        Image image1 = new Image();
        image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Shield1.png"));
        spriteSequence[1] = image1;
        Image image2 = new Image();
        image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Shield2.png"));
        spriteSequence[2] = image2;
        Image image3 = new Image();
        image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Shield3.png"));
        spriteSequence[3] = image3;

        ObservableCollection<Shield> shields = new ObservableCollection<Shield>();

        for (int i = 0; i < 4; i++)
        {
            Rectangle rect = new Rectangle(150 + (180 * i), 500, 80, 50);

            shields.Add(new Shield(spriteSequence, rect));
        }

        _shields = shields;
    }
    public ObservableCollection<Shield> Shields
    {
        get { return _shields; }
        set { SetProperty(ref _shields, value, nameof(Shields)); }
    }
    private void CreateEnemies()
    {
        ObservableCollection<Enemy> enemies = new ObservableCollection<Enemy>();

        Image image1 = new Image();
        image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Enemy1.png"));
        Image image2 = new Image();
        image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Enemy2.png"));
        Image image3 = new Image();
        image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Enemy3.png"));

        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                Rectangle rect = new Rectangle(275 + (50 * i), 100 + (50 * j), 40, 40);
                Console.WriteLine(i+" "+j);
                Image image = new Image();
                switch (j)
                {
                    case 0:
                        image = image3;
                        break;
                    case 1:
                    case 2:
                        image = image2;
                        break;
                    case 3:
                    case 4:
                        image = image1;
                        break;
                }

                enemies.Add(new Enemy(image, rect, Direction.Right));
            }
        }

        _enemies = enemies;
    }

    public ObservableCollection<Enemy> Enemies
    {
        get { return _enemies; }
        set { SetProperty(ref _enemies, value, nameof(Enemies)); }
    }

    public Rectangle PlayerHitBox
    {
        get { return _playerHitBox; }
        set { SetProperty(ref _playerHitBox, value, nameof(PlayerHitBox)); }
    }

    public Rectangle PlayerShotHitBox
    {
        get { return _playerShotHitBox; }
        set { SetProperty(ref _playerShotHitBox, value, nameof(PlayerShotHitBox)); }
    }

    public bool ShotVisible
    {
        get { return _shotVisible; }
        set { SetProperty(ref _shotVisible, value,nameof(ShotVisible)); }
    }

    public double Score
    {
        get { return _score; }
        set { SetProperty(ref _score, value, nameof(Score)); }
    }

    public void MovePlayer(int displacement, double screenWidth)
    {
        if (PlayerHitBox.Width + PlayerHitBox.X + displacement > screenWidth || PlayerHitBox.X + displacement < 0)
        {
            return;
        }

        var newRect = new Rectangle(PlayerHitBox.X + displacement, PlayerHitBox.Y, PlayerHitBox.Width, PlayerHitBox.Height);
        PlayerHitBox = newRect;
    }

    public async void Shot()
    {
        if (!PlayerShotHitBox.Y.Equals(650))
        {
            return;
        }

        //  _shotSfx.PlaySound();

        double playerPositionX = PlayerHitBox.X + 20;
        double shotY = PlayerShotHitBox.Y;
        bool shotHit = false;
        const int speed = 50;
        ShotVisible = true;

        while (shotY > 0 && !shotHit)
        {
            shotY -= speed;

            var newPosition = new Rectangle((int)playerPositionX, (int)shotY, PlayerShotHitBox.Width, PlayerShotHitBox.Height);
            PlayerShotHitBox = newPosition;

            foreach (var shield in _shields)
            {
                if (PlayerShotHitBox.IntersectsWith(shield.HitBox) && shield.Alive)
                {
                    // _shieldSfx.PlaySound();
                    shield.TakeDamage();
                    shotHit = true;
                    break;
                }
            }

            if (!shotHit)
            {
                foreach (var enemy in _enemies)
                {
                    if (PlayerShotHitBox.IntersectsWith(enemy.HitBox) && enemy.Alive)
                    {
                        //  _enemyHitSfx.PlaySound();
                        enemy.Alive = false;
                        Score += 20;
                        if (Score >= 50)
                        {
                            GoGameOver(Score);
                            return;
                        }
                        shotHit = true;
                        break;
                    }
                }
            }

            await Task.Delay(16);
        }

        var restorePosition = new Rectangle(PlayerShotHitBox.X, 650, PlayerShotHitBox.Width, PlayerShotHitBox.Height);
        PlayerShotHitBox = restorePosition;
        ShotVisible = false;
    }

    public event EventHandler<double> GameOverRequested;
    private void GoGameOver(double score)
    {
        GameOverRequested?.Invoke(this, score);
    }
}
