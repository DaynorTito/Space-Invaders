using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml.Input;
using SpaceInvadersDaynorTito.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace SpaceInvadersDaynorTito
{
    public partial class GameView : Page
    {
        private readonly Control _player;

        public GameView()
        {
            this.InitializeComponent();
            Loaded += GameViewLoaded;
            KeyDown += KeyDownHandler;
            var viewModel = DataContext as GameViewModel;
            if (viewModel != null)
            {
                viewModel.GameOverRequested += ViewModel_GameOverRequested;
            }
        }

        private void GameViewLoaded(object? sender, RoutedEventArgs e)
        {
            GameScreen.Focus(FocusState.Programmatic);
        }

        private void KeyDownHandler(object? sender, KeyRoutedEventArgs e)
        {
            var viewModel = DataContext as GameViewModel;
            const int moveStep = 10;

            if (sender != null)
            {
                switch (e.Key)
                {
                    case Windows.System.VirtualKey.Left:
                        viewModel.MovePlayer(-moveStep, Width);
                        //_soundEffect.PlaySound();
                        break;
                    case Windows.System.VirtualKey.Right:
                        viewModel.MovePlayer(moveStep, Width);
                        //_soundEffect.PlaySound();
                        break;
                    case Windows.System.VirtualKey.Space:
                        viewModel.Shot();
                        break;

                }
            }
        }
        private void ViewModel_GameOverRequested(object sender, double e)
        {
            Frame.Navigate(typeof(GameOverView), e);
        }
    }

}
