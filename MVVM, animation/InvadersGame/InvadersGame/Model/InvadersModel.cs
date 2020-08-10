using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;


namespace InvadersGame.Model
{
    class InvadersModel
    {
        public readonly static Size PlayAreaSize = new Size(400, 300);
        private readonly Random _random = new Random();

        public const int MaximumPlayerShots = 3;
        public const int InitialStarCount = 50;

        private DateTime? _playerDied = null;
        private Player _player;
        private Direction _invaderDirection = Direction.Left;
        private bool _justMovedDown = false;
        private DateTime _lastUpdated = DateTime.MinValue;


        public int Score { get; private set; }
        public int Wave { get; private set; }
        public int Lives { get; private set; }
        public bool GameOver { get; private set; }
        public bool PlayerDying { get { return _playerDied.HasValue; } }

 

        private readonly List<Invader> _invaders = new List<Invader>();
        private readonly List<Shot> _playerShots = new List<Shot>();
        private readonly List<Shot> _invaderShots = new List<Shot>();
        private readonly List<Point> _stars = new List<Point>();

        private readonly Dictionary<InvaderType, int> _invaderScores = new Dictionary<InvaderType, int>()
        {
            { InvaderType.Star, 10 },
            { InvaderType.Satellite, 20 },
            { InvaderType.Saucer, 30 },
            { InvaderType.Bug, 40 },
            { InvaderType.Spaceship, 50 },
        };



        public InvadersModel()//KONSTRUKTOR
        {
            EndGame();
        }

        public void EndGame()
        {
            GameOver = true;
        }

        public void StartGame()
        {
            GameOver = false;

            //USUWANIE
            List<Invader> _invadersList = _invaders.ToList();

            foreach (Invader invader in _invadersList)
            {
                //call shipchanged EVENT
                OnShipChanged(invader, true);
                _invaders.Remove(invader);
            }

            //USUWANIE
            List<Shot> _playerShotsList = _playerShots.ToList();
            foreach (Shot playerShot in _playerShotsList)
            {
                //call shotMoved EVENT
                OnShotMoved(playerShot, true);
                _playerShots.Remove(playerShot);
            }

            //USUWANIE
            List<Shot> _invaderShotsList = _invaderShots.ToList();
            foreach (Shot invaderShot in _invaderShotsList)
            {
                //call shotMoved EVENT
                OnShotMoved(invaderShot, true);

                _playerShots.Remove(invaderShot);
            }

            //clear the stars (firing the StarChanged event for each star)
            foreach (Point star in _stars)
                OnStarChanged(star, true);
            _stars.Clear();

            // Create new stars
            for (int i = 0; i < InitialStarCount; i++)
                AddStar();

            //create a new Player object (firing a ShipChanged event), sets Lives to 2, Wave to 0, and adds the first wave.
            _player = new Player();
           
           Lives = 2;
           Wave = 0;
           Score = 0;
            
           OnShipChanged(_player, false);

            NextWave();
        }



        public void FireShot() //player fires a shot
        {
            if (GameOver || PlayerDying) //|| _lastUpdated == DateTime.MinValue)
                return;

            if (_playerShots.Count() < MaximumPlayerShots)
            {
                Shot shotFired = new Shot(
                    new Point(_player.Location.X + (_player.Size.Width / 2) - 1, _player.Location.Y), 
                    Direction.Up);
                _playerShots.Add(shotFired);

                // fire the ShotMoved event               
                OnShotMoved(shotFired, false);
            }
        }


        public void MovePlayer(Direction direction)
        {
            if (!_playerDied.HasValue)
            {
                _player.Move(direction);
                OnShipChanged(_player, false);
            }           
        }

        //This method flips a coin and either adds or removes a star, firing the StarChanged event. 
        //There are always fewer than 50% more and greater than 15% fewer than the initial number of stars.

        public void Twinkle()
        {
            if (_random.Next(2) == 0)
                if (_stars.Count < (1.5 * InitialStarCount) - 1)
                    AddStar();
                else
                if (_stars.Count > (0.85 * InitialStarCount) + 1)
                    RemoveStar();
        }

        public void AddStar()
        {
            Point newStar = new Point((double)_random.Next((int)PlayAreaSize.Width - 10), (double)_random.Next((int)PlayAreaSize.Height - 10));
            _stars.Add(newStar);            
        }

        public void RemoveStar()//removes random star
        {
            Point starToRemove = _stars[_random.Next(_stars.Count)]; //pick random star
            _stars.Remove(starToRemove);
            OnStarChanged(starToRemove, true);
        }

        public void Update()
        {
          //  if (!_paused)
            {
                if (_invaders.Count() == 0)
                {
                    //generate new wave
                    NextWave();
                }

                if (!PlayerDying)
                {
                    MoveInvaders();
                    MoveShots();
                    ReturnFire();
                   // RemoveAllShots();
                    CheckForInvaderCollisions();
                    FindLowestInvader();
                    CheckForPlayerCollisions();
                }
                if (PlayerDying && TimeSpan.FromSeconds(2.5) < DateTime.Now - _playerDied)
                {
                    _playerDied = null;
                    OnShipChanged(_player, false);
                }
            }
            Twinkle();
        }

        private void MoveShots()
        {
            if (_invaderShots.Count() > 0 || _playerShots.Count() > 0) //jeśli są jakieś strzały
            {
                //PLAYER SHOTS
                List<Shot> _playerShotsList = _playerShots.ToList();
                foreach (Shot playerShot in _playerShotsList)
                {
                    playerShot.Move();
                    OnShotMoved(playerShot, false);

                    if (playerShot.Location.Y < 0)//jeśli wyleciał za ekran
                    {
                        _playerShots.Remove(playerShot);
                        OnShotMoved(playerShot, true);
                    }
                }

                //INVADER SHOTS
                List<Shot> _invaderShotsList = _invaderShots.ToList();
                foreach (Shot invaderShot in _invaderShotsList)
                {
                    invaderShot.Move();
                    OnShotMoved(invaderShot, false);

                    if (invaderShot.Location.Y > PlayAreaSize.Height)//jeśli wyleciał za ekran
                    {
                        _invaderShots.Remove(invaderShot);
                        OnShotMoved(invaderShot, true);
                    }
                }
            }
        }

        private void RemoveAllShots()
        {
            List<Shot> invaderShots = _invaderShots.ToList();
            List<Shot> playerShots = _playerShots.ToList();

            foreach (Shot shot in invaderShots)
                OnShotMoved(shot, true);

            foreach (Shot shot in playerShots)
                OnShotMoved(shot, true);

            _invaderShots.Clear();
            _playerShots.Clear();
        }

        private void NextWave()
        // create all of the Invader objects, giving each of them a Location field with the correct coordinates.
        //  they’re spaced 1.4 invader lengths apart horizontally, and 1.4 invader heights vertically. 
        // _invaders.Add(new Invader());
        {
            Wave++;
            _invaders.Clear();
            RemoveAllShots();
            _invaderDirection = Direction.Left;

            InvaderType invaderType;
            for (int row = 0; row < 6; row++)
            {
                switch (row)
                {
                    case 0:
                        invaderType = InvaderType.Spaceship;
                        break;
                    case 1:
                        invaderType = InvaderType.Bug;
                        break;
                    case 2:
                        invaderType = InvaderType.Saucer;
                        break;
                    case 3:
                        invaderType = InvaderType.Satellite;
                        break;
                    default:
                        invaderType = InvaderType.Star;
                        break;
                }

                for (int column = 0; column < 11; column++)
                {
                    Point location = new Point(column * Invader.InvaderSize.Width * 1.4, row * Invader.InvaderSize.Height * 1.4);
                    _invaders.Add(new Invader(invaderType, location, _invaderScores[invaderType]));
                    OnShipChanged(_invaders[_invaders.Count - 1], false);
                }
            }         
        }



        private void MoveInvaders()
        {

            //do nothing if not enough time has passed
            //check and update the private framesSkipped 

            TimeSpan timeSinceLastMove = DateTime.Now - _lastUpdated;
            double msBetweenMoves = Math.Max(7 - Wave, 1) * (2 * _invaders.Count());

            if (timeSinceLastMove >= TimeSpan.FromMilliseconds(msBetweenMoves))
            {

                //If the invaders are moving to the right
                if (_invaderDirection == Direction.Right)
                {
                    var invadersMovingRight =
                        from invader in _invaders
                        where invader.Area.Right > PlayAreaSize.Width - Invader.HorizontalPixelsPerMove * 2
                        // SPRAWDZIC POTEM JAKBY TO: where invader.Location.X + 10 > PlayAreaSize.Width
                        select invader;

                    if (invadersMovingRight.Count() > 0) // jeśli są znajdujący się przy prawej
                    {
                        _invaderDirection = Direction.Down;
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(_invaderDirection);
                            OnShipChanged(invader, false);                   
                        }
                        _justMovedDown = true;
                        _invaderDirection = Direction.Left;
                    }
                    else
                    {
                        _justMovedDown = false;
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(_invaderDirection);
                            OnShipChanged(invader, false);
                        }
                    }
                }

                if (_invaderDirection == Direction.Left)
                {
                    var invadersMovingLeft =
                        from invader in _invaders
                        where invader.Area.Left < Invader.HorizontalPixelsPerMove * 2
                        select invader;


                    if (invadersMovingLeft.Count() > 0)
                    {
                        _invaderDirection = Direction.Down;
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(_invaderDirection);
                            OnShipChanged(invader, false);
                        }
                        _justMovedDown = true;
                        _invaderDirection = Direction.Right;
                    }
                    else
                    {
                        _justMovedDown = false;
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(_invaderDirection);
                            OnShipChanged(invader, false);
                        }
                    }
                }
            }
        }




        private void ReturnFire()
        {
            if (_invaderShots.Count() > Wave + 1 && _random.Next(10) < 10 - Wave)     //max strzalow wroga to poziom+1
            {
                return;
            }

            //to fire random, not all the time- losowa liczba 0-10 musi być mniejsza niż 10- wave- im mniejszy poziom tym wieksza szansa ze nie strzeli


            var shootingInvader =      //pogrupowanie alienów by X i wybranie najniższego z każdej grupy
                from invader in _invaders
                group invader by invader.Location.X into shootingInvadersGroups
                orderby shootingInvadersGroups.Key ascending
                select shootingInvadersGroups.Last();

            Invader shooter= shootingInvader.ElementAt(_random.Next(0, shootingInvader.Count()));

            //add a shot to _invaderShots list just below the middle of the invader (use the invader’s Area to find the shot’s location).
            Point shotLocation = new Point(shooter.Area.X + (shooter.Size.Width / 2) - 1, shooter.Area.Bottom);
            Shot invaderShot = new Shot(shotLocation, Direction.Down);
            _invaderShots.Add(invaderShot);
            OnShotMoved(invaderShot, false);
        }


        public void CheckForInvaderCollisions() 
            //sprawdza czy trafiono invaedra
            //SPRAWDZIĆ CZY TA METODA DZIAŁA PODOBNIE JAK RectsOverleap
        {
            List<Shot> _playerShotsList = _playerShots.ToList();
            List<Invader> _invadersList = _invaders.ToList();

            foreach (Shot shot in _playerShotsList)
            {
                foreach (Invader invader in _invadersList)
                {
                    if(invader.Area.Contains(shot.Location))
                    {
                        _invaders.Remove(invader);
                        _playerShots.Remove(shot);
                        OnShotMoved(shot, true);
                        OnShipChanged(invader, true);
                    }
                }
            }         
        }
        //_invaderShots.Remove(shot);
        //                OnShotMoved(shot, true);
        //_playerDied = DateTime.Now;
        //                OnShipChanged(_player, true);
        //RemoveAllShots();
        //Lives--;


        private static bool RectsOverlap(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if (r1.Width > 0 || r1.Height > 0)
                return true;
            return false;
        }

        private void CheckForPlayerCollisions()
        {
            List<Shot> invaderShots = _invaderShots.ToList();

            foreach (Shot shot in invaderShots)
            {
                Rect shotRect = new Rect(shot.Location.X, shot.Location.Y, Shot.ShotSize.Width, Shot.ShotSize.Height);

                if (RectsOverlap(_player.Area, shotRect))
                {
                    if (Lives == 0)
                        EndGame();
                    else
                    {
                        _invaderShots.Remove(shot);
                        OnShotMoved(shot, true);
                        _playerDied = DateTime.Now;
                        OnShipChanged(_player, true);
                        RemoveAllShots();
                        Lives--;
                    }
                }
            }
        }

            //figure out if any invaders reached the bottom of the battlefield—if so, end the game.
            public void FindLowestInvader()
            {
                var lowestInvader =      //TO SPRAWDZIC CZY DOBRZE
                from invader in _invaders
                orderby invader.Location.X ascending
                select invader;

                Invader low = lowestInvader.First();

                if(PlayAreaSize.Height- low.Location.X<50)  //TODO korekta
                {
                    EndGame();
                }
            }


        public event EventHandler<ShotMovedEventArgs> ShotMoved;
        public event EventHandler<ShipChangedEventArgs> ShipChanged;
        public event EventHandler<StarChangedEventArgs> StarChanged;


        private void OnShotMoved(Shot shot, bool disappeared) //funkcja do wywolania
        {
            EventHandler<ShotMovedEventArgs> shotMoved = ShotMoved;
            if (shotMoved != null)
            {
                shotMoved(this, new ShotMovedEventArgs(shot, disappeared));
            }
        }

        private void OnShipChanged(Ship shipUpdated, bool killed) //funkcja do wywolania
        {
            EventHandler<ShipChangedEventArgs> shipChanged = ShipChanged;
            if (shipChanged != null)
            {
                shipChanged(this, new ShipChangedEventArgs(shipUpdated, killed));
            }
        }


        private void OnStarChanged(Point point, bool disappeared) //funkcja do wywolania
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
            {
                starChanged(this, new StarChangedEventArgs(point, disappeared));
            }
        }

        public void UpdateAllShipsAndStars()
        {
            foreach (Shot shot in _playerShots)
                OnShotMoved(shot, false);
            foreach (Invader ship in _invaders)
                OnShipChanged(ship, false);
            OnShipChanged(_player, false);
            foreach (Point point in _stars)
                OnStarChanged(point, false);
        }
    }
}