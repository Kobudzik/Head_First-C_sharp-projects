using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.Foundation;
using DispatcherTimer = Windows.UI.Xaml.DispatcherTimer;
using FrameworkElement = Windows.UI.Xaml.FrameworkElement;
using InvadersGame.View;
using InvadersGame.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace InvadersGame.ViewModel
{
    class InvadersViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<FrameworkElement> _sprites = new ObservableCollection<FrameworkElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        public bool GameOver { get { return _model.GameOver; } }

        private readonly ObservableCollection<object> _lives = new ObservableCollection<object>();
        public INotifyCollectionChanged Lives { get { return _lives; } }

        public bool Paused { get; set; }
        private bool _lastPaused = true;
        public static double Scale { get; private set; }
        public int Score { get; private set; }

        public Size PlayAreaSize
        {
            set
            {
                Scale = value.Width / 405;
                _model.UpdateAllShipsAndStars();//sprawdzic czy dziala bez tego
                RecreateScanLines();
            }
        }

        private readonly InvadersModel _model = new InvadersModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private FrameworkElement _playerControl = null;
        private bool _playerFlashing = false;
        private readonly Dictionary<Invader, FrameworkElement> _invaders = new Dictionary<Invader, FrameworkElement>();
        private readonly Dictionary<FrameworkElement, DateTime> _shotInvaders = new Dictionary<FrameworkElement, DateTime>();
        private readonly Dictionary<Shot, FrameworkElement> _shots = new Dictionary<Shot, FrameworkElement>();
        private readonly Dictionary<Point, FrameworkElement> _stars = new Dictionary<Point, FrameworkElement>();
        private readonly List<FrameworkElement> _scanLines = new List<FrameworkElement>();





        private DateTime? _leftAction = null;
        private DateTime? _rightAction = null;

        internal void KeyDown(Windows.System.VirtualKey virtualKey)
        {
            if (virtualKey == Windows.System.VirtualKey.Space) 
                _model.FireShot();

            if (virtualKey == Windows.System.VirtualKey.Left)
                _leftAction = DateTime.Now;

            if (virtualKey == Windows.System.VirtualKey.Right)
                _rightAction = DateTime.Now;
        }

        internal void KeyUp(Windows.System.VirtualKey virtualKey)
        {
            if (virtualKey == Windows.System.VirtualKey.Left)
                _leftAction = null;

            if (virtualKey == Windows.System.VirtualKey.Right) 
                _rightAction = null;
        }

        internal void LeftGestureStarted()
        {
            _leftAction = DateTime.Now;
        }

        internal void LeftGestureCompleted()
        {
            _leftAction = null;
        }

        internal void RightGestureStarted()
        {
            _rightAction = DateTime.Now;
        }

        internal void RightGestureCompleted()
        {
            _rightAction = null;
        }

        internal void Tapped()
        {
            _model.FireShot();
        }

        public InvadersViewModel()
        {
            Scale = 1;
            _model.ShipChanged += ModelShipChangedEventHandler;
            _model.ShotMoved += ModelShotMovedEventHandler;
            _model.StarChanged += ModelStarChangedEventHandler;
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTickEventHandler;
            EndGame();
        }

        public void EndGame()
        {
            _model.EndGame();
        }

        public void StartGame()
        {
            Paused = false;

            foreach (var invader in _invaders.Values)
                _sprites.Remove(invader);

            foreach (var shot in _shots.Values)
                _sprites.Remove(shot);

            _model.StartGame();
            OnPropertyChanged("GameOver");
            _timer.Start();
        }

        private void RecreateScanLines()
        {
            foreach (FrameworkElement scanLine in _scanLines)
                if (_sprites.Contains(scanLine))
                    _sprites.Remove(scanLine);

            _scanLines.Clear();

            for (int y = 0; y < 300; y += 2)
            {
                FrameworkElement scanLine = InvadersHelper.ScanLineFactory(y, 400, Scale);
                _scanLines.Add(scanLine);
                _sprites.Add(scanLine);
            }
        }


        void TimerTickEventHandler(object sender, object e)
        {
            if (_lastPaused != Paused)
            {
                //Use the _lastPaused field to fire a PropertyChanged event any time  the Paused property changes.   
                _lastPaused = Paused;
                OnPropertyChanged("Paused");
            }

            if (!Paused)
            {
                if (_leftAction != null && _rightAction != null)
                {
                    // Use the most recent action to decide which direction to move.
                    if (DateTime.Compare((DateTime)_leftAction, (DateTime)_rightAction) > 0)
                        _model.MovePlayer(Direction.Left);
                    else
                        _model.MovePlayer(Direction.Right);
                }
                else
                {
                    if (_leftAction.HasValue)
                        _model.MovePlayer(Direction.Left);
                    else if (_rightAction.HasValue)
                        _model.MovePlayer(Direction.Right);
                }
            }
            //If both the _leftAction and _rightAction fields have a value, that means there are either two keys being mashed or a key and a swipe at the same time
            //—use the one with the later time to choose a direction to move the player.If not, choose the one with a value and use that to pass to _model.MovePlayer().  
        


            //Tellthe InvadersModel to update itself.Then check the Score property. If it   doesn't match _model.Score, update it and fire a PropertyChanged event.

            //Update the Lives so that it matches _model.Lives by either removing an   object or adding a new object ().
            _model.Update();
            if (_model.Score != Score)
            {
                Score = _model.Score;
                OnPropertyChanged("Score");
            }

            if (_model.Lives >= 0)
            {
                while (_model.Lives > _lives.Count)
                    _lives.Add(new object());
                while (_model.Lives < _lives.Count)
                    _lives.RemoveAt(0);
            }



            //Each key in the _shotInvaders Dictionary is an AnimatedImage control,  
            //and its value is the time that it died.It takes half a second for the invader  
            //fade-out animation to complete, so any invader who died more than half a second ago
            //should be removed from both _sprites and _shotInvaders. 
            /*If the game is over, fire a PropertyChanged event and stop the timer.*/

            foreach (FrameworkElement control in _shotInvaders.Keys.ToList())
            {
                if (DateTime.Now - _shotInvaders[control] > TimeSpan.FromSeconds(0.3))
                {
                    _sprites.Remove(control);
                    _shotInvaders.Remove(control);
                }
            }

            if (_model.GameOver)
            {
                _timer.Stop();
                OnPropertyChanged("GameOver");
            }
        }




        private void ModelShipChangedEventHandler(object sender, ShipChangedEventArgs e)
        {
            if (!e.Killed)  //JEŚLI ŻYJĄ
            {
                if (e.ShipUpdated is Invader)
                {
                    Invader invader = e.ShipUpdated as Invader;
                    if (!_invaders.ContainsKey(invader))//jeśli taki NIE istnieje w liście _invaders
                    {
                        FrameworkElement invaderControl = InvadersHelper.ShipControlFactory(invader, Scale);
                        _invaders[invader] = invaderControl;
                        _sprites.Add(invaderControl);
                    }
                    else
                    {
                        FrameworkElement invaderControl = _invaders[invader];
                        InvadersHelper.MoveElementOnCanvas(invaderControl, invader.Location.X * Scale, invader.Location.Y * Scale);
                        InvadersHelper.ResizeElement(invaderControl, invader.Size.Width * Scale, invader.Size.Height * Scale);
                    }
                }

                else if (e.ShipUpdated is Player)
                {
                    if (_playerFlashing)
                    {
                        AnimatedImage playerImage = _playerControl as AnimatedImage;
                        playerImage.StopFlashing();
                        _playerFlashing = false;
                    }
                    if (_playerControl == null)
                    {
                        _playerControl = InvadersHelper.ShipControlFactory(e.ShipUpdated as Player, Scale);
                        _sprites.Add(_playerControl);
                    }
                    else
                    {
                        InvadersHelper.MoveElementOnCanvas(_playerControl, e.ShipUpdated.Location.X * Scale, e.ShipUpdated.Location.Y * Scale);
                        InvadersHelper.ResizeElement(_playerControl, e.ShipUpdated.Size.Width * Scale, e.ShipUpdated.Size.Height * Scale);
                    }
                }
            }
            //JEŚLI NIE ŻYJĄ
            else if (e.ShipUpdated is Invader)//Jeśli to invader
            {
                Invader deadInvader = e.ShipUpdated as Invader;

                if (!_invaders.ContainsKey(deadInvader))
                    return;

                AnimatedImage deadInvaderControl = _invaders[deadInvader] as AnimatedImage;

                if (deadInvaderControl != null)
                {
                    deadInvaderControl.InvaderShot();
                    
                    _shotInvaders[deadInvaderControl] = DateTime.Now;
                    _invaders.Remove(deadInvader);

                }
            }
            else if (e.ShipUpdated is Player)
            {
                AnimatedImage playerImage = _playerControl as AnimatedImage;
                if (playerImage != null)
                    playerImage.StartFlashing();
                _playerFlashing = true;
            }
        }

        private void ModelShotMovedEventHandler(object sender, ShotMovedEventArgs e)
        {
            if (!e.Disappeared) //JEŚLI NIE ZNIKNIĘTY
            {
                if (!_shots.ContainsKey(e.Shot)) //JEŚLI _shots NIE ZAWIERA
                {
                    FrameworkElement shotControl = InvadersHelper.ShotControlFactory(e.Shot, Scale);
                    _shots[e.Shot] = shotControl;
                    _sprites.Add(shotControl);
                }
                else
                {
                    InvadersHelper.MoveElementOnCanvas(_shots[e.Shot], e.Shot.Location.X * Scale, e.Shot.Location.Y * Scale);
                }
            }
            else//JEŚLI ZNIKNIETY
            {
                if (_shots.ContainsKey(e.Shot))
                {
                    _sprites.Remove(_shots[e.Shot]);
                    _shots.Remove(e.Shot);
                }
            }
        }

        private void ModelStarChangedEventHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Disappeared && _stars.ContainsKey(e.Point))
            {
                FrameworkElement starToRemove = _stars[e.Point];
                _sprites.Remove(starToRemove);
            }
            else
            {
                if (!_stars.ContainsKey(e.Point))
                {
                    FrameworkElement newStar = InvadersHelper.StarControlFactory(e.Point, Scale);
                    _stars[e.Point] = newStar;
                    _sprites.Add(newStar);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //event

        private void OnPropertyChanged(string propertyName) //funkcja do wywolania
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}