using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RussianRouletteAssessment
{
    public partial class frm_Game : Form
    {
        //private variables
        //private Assembly assembly;
        //private Stream ImageStream;
        private Bitmap buffer;
        private Graphics GameGraphics;
        private enum GameStates
        {
            Intro = 0,
            LoadBullet,//starts with bullet out, transition starts when user places bullet, ends when animation of bullet is done
            SpinChamber,//starts with Chamber out, transition is when user starts to close chamber and spins it, ends when Chamber is spun
            Fire,//starts with finger on trigger, transitions when player activates the trigger, ends when firing animation is done
            Death,//starts with gun fired but whether or not player survived is indeterminate, transition is automatic after 1.5 seconds
                    //ends with players death, players relief, relief cause of act of god
            Survive,//starts with gun fired but whether or not player survived is indeterminate, transition is automatic after 1.5 seconds
                    //ends with players relief
            DeusExMachina//starts with gun fired but whether or not player survived is indeterminate, transition is automatic after 1.5 seconds
                         //ends with relief because of an act of god
        }
        GameStates StateOfTheGame = GameStates.Intro;
        //Animations
        Animations GameAnimations = new Animations();
        Animation Anim_Intro = new Animation();
        Animation Anim_LoadBullet = new Animation();
        Animation Anim_SpinChamber = new Animation();
        Animation Anim_Fire = new Animation();
        Animation Anim_Death = new Animation();
        Animation Anim_Survive = new Animation();
        Animation Anim_DeusExMachina = new Animation();


        //private methods
        private void PaintCanvas()
        {
            GameGraphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pnl_canvas.Width, pnl_canvas.Height));
            DrawGameObjects(GameGraphics);
            pnl_canvas.CreateGraphics().DrawImageUnscaled(buffer, 0, 0);
        }

        private void DrawGameObjects(Graphics gameGraphics)
        {
            switch (StateOfTheGame)
            {
                case GameStates.Intro:
                    gameGraphics.DrawImage(Anim_Intro.NextImage(), 0, 0);
                    break;
                case GameStates.LoadBullet:
                    gameGraphics.DrawImage(Anim_LoadBullet.NextImage(), 0, 0);
                    break;
                case GameStates.SpinChamber:
                    gameGraphics.DrawImage(Anim_SpinChamber.NextImage(), 0, 0);
                    break;
                case GameStates.Fire:
                    gameGraphics.DrawImage(Anim_Fire.NextImage(), 0, 0);
                    break;
                case GameStates.Death:
                    gameGraphics.DrawImage(Anim_Death.NextImage(), 0, 0);
                    break;
                case GameStates.Survive:
                    gameGraphics.DrawImage(Anim_Survive.NextImage(), 0, 0);
                    break;
                case GameStates.DeusExMachina:
                    gameGraphics.DrawImage(Anim_DeusExMachina.NextImage(), 0, 0);
                    break;
                default:
                    break;
            }
        }

        public frm_Game()
        {
            try
            {
                //assembly = Assembly.GetExecutingAssembly();
                InitializeComponent();
                //apparently this sets up the form to do painting in the most simplest way
                //I understand OptimizedDoubleBuffer as I have used buffers before when creating animations in software
                //Not 100% sure about UserPaint and AllPaintinInWmPaint need to look these up
                //Although WmPaint sounds like the Windows Message event in C++ win32 painting
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

                buffer = new Bitmap(pnl_canvas.Width, pnl_canvas.Height);
                GameGraphics = Graphics.FromImage(buffer);

                //load in TestImages
                //GameAnimations.AddAnimation(Anim_Intro, new string[] { "RussianRouletteAssessment.TestImages.Intro.png" });
                GameAnimations.AddAnimation(Anim_LoadBullet, new string[] { "RussianRouletteAssessment.TestImages.LoadBullet.png" });
                GameAnimations.AddAnimation(Anim_SpinChamber, new string[] { "RussianRouletteAssessment.TestImages.SpinChamber.png" });
                GameAnimations.AddAnimation(Anim_Fire, new string[] { "RussianRouletteAssessment.TestImages.Fire.png" });
                GameAnimations.AddAnimation(Anim_Death, new string[] { "RussianRouletteAssessment.TestImages.Died.png" });
                GameAnimations.AddAnimation(Anim_Survive, new string[] { "RussianRouletteAssessment.TestImages.Survived.png" });
                GameAnimations.AddAnimation(Anim_DeusExMachina, new string[] { "RussianRouletteAssessment.TestImages.SurvivedDeusExMachina.png" });
                //load in Real Images
                GameAnimations.AddAnimation(Anim_Intro, new string[] {  "RussianRouletteAssessment.IntroAnimation.Intro_1-01.png",
                                                                        "RussianRouletteAssessment.IntroAnimation.Intro_1-02.png",
                                                                        "RussianRouletteAssessment.IntroAnimation.Intro_1-03.png",
                                                                        "RussianRouletteAssessment.IntroAnimation.Intro_1-04.png",
                                                                        "RussianRouletteAssessment.IntroAnimation.Intro_1-05.png",
                                                                        "RussianRouletteAssessment.IntroAnimation.Intro_1-06.png" });
                GameAnimations.SetAllLoop(false);
                GameAnimations.SetAllPaused(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void frm_Game_Load(object sender, EventArgs e)
        {
            this.Text = "Russian Roulette - Welcome " + frm_PlayerProfile.profileName;
            AnimTimer.Start();
            IntroTimer.Start();
            Anim_Intro.Loop = true;
            Anim_Intro.Paused = false;

            StateOfTheGame = GameStates.Intro;
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            UpdateGame();
            PaintCanvas();
        }

        private void UpdateGame()
        {
            switch (StateOfTheGame)
            {
                case GameStates.Intro:
                    if (!IntroTimer.Enabled)
                    {
                        IntroTimer.Start();
                    }
                    break;
                case GameStates.LoadBullet:
                    break;
                case GameStates.SpinChamber:
                    break;
                case GameStates.Fire:
                    break;
                case GameStates.Death:
                    break;
                case GameStates.Survive:
                    break;
                case GameStates.DeusExMachina:
                    break;
                default:
                    break;
            }
        }

        private void IntroTimer_Tick(object sender, EventArgs e)
        {
            StateOfTheGame = GameStates.LoadBullet;
            IntroTimer.Stop();
        }

        private void pnl_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (StateOfTheGame)
            {
                case GameStates.Intro:
                    StateOfTheGame = GameStates.LoadBullet;
                    IntroTimer.Stop();
                    break;
                case GameStates.LoadBullet:
                    break;
                case GameStates.SpinChamber:
                    break;
                case GameStates.Fire:
                    break;
                case GameStates.Death:
                    break;
                case GameStates.Survive:
                    break;
                case GameStates.DeusExMachina:
                    break;
                default:
                    break;
            }
        }
    }
    class Animation
    {
        private Assembly assembly;
        private Stream ImageStream;
        //private
        private int CurrentImage;
        private Image[] _ImageSet;
        private bool paused = false;
        private bool loop = false;

        public Animation()
        {
            assembly = Assembly.GetExecutingAssembly();
            _ImageSet = null;
        }
        public Animation(Image[] newImageSet)
        {
            assembly = Assembly.GetExecutingAssembly();
            _ImageSet = newImageSet;
            CurrentImage = 0;
        }
        public Animation(Image[] newImageSet, int newCurrentImage)
        {
            assembly = Assembly.GetExecutingAssembly();
            _ImageSet = newImageSet;
            CurrentImage = newCurrentImage;
        }

        public void AddImage(Image newImage)
        {

            if (_ImageSet != null)
            {
                List<Image> tmpImages = new List<Image>();
                foreach (Image _image in _ImageSet)
                {
                    tmpImages.Add(_image);
                }
                tmpImages.Add(newImage);
                _ImageSet = tmpImages.ToArray();
            }
            else
            {
                _ImageSet = new Image[] { newImage };
            }
        }
        public void AddImage(string newImage)
        {

            if (_ImageSet != null)
            {
                List<Image> tmpImages = new List<Image>();
                foreach (Image _image in _ImageSet)
                {
                    tmpImages.Add(_image);
                }
                ImageStream = assembly.GetManifestResourceStream(newImage);
                tmpImages.Add(new Bitmap(ImageStream));
                _ImageSet = tmpImages.ToArray();
            }
            else
            {
                ImageStream = assembly.GetManifestResourceStream(newImage);
                _ImageSet = new Image[] { new Bitmap(ImageStream) };
            }
        }

        public Image NextImage()
        {
            if (_ImageSet == null || _ImageSet.Length < 1)
            {
                return null;
            }
            if (!paused)//Only change CurrentImage if game is not paused
            {
                if (CurrentImage == _ImageSet.Length - 1)
                {
                    if (loop)//Only reset CurrentImage if loop
                    {
                        CurrentImage = 0;
                    }
                }
                else
                {
                    CurrentImage++;
                }
            }
            return _ImageSet[CurrentImage];
        }

        public void Reset()
        {
            CurrentImage = 0;
        }

        public Image[] ImageSet
        {
            get
            {
                return _ImageSet;
            }

            set
            {
                _ImageSet = value;
            }
        }

        public int Index
        {
            get
            {
                return CurrentImage;
            }

            set
            {
                CurrentImage = value;
            }
        }

        public bool Paused
        {
            get
            {
                return paused;
            }

            set
            {
                paused = value;
            }
        }

        public bool Loop
        {
            get
            {
                return loop;
            }

            set
            {
                loop = value;
            }
        }
    }
    class Animations
    {
        //private
        private Animation[] AnimationSet;

        public Animations()
        {
            AnimationSet = null;
        }
        public Animations(Animation[] newAnimationSet)
        {
            AnimationSet = newAnimationSet;
        }

        public void AddAnimation(Animation newAnimation)
        {

            if (AnimationSet != null)
            {
                List<Animation> tmpAnimation = new List<Animation>();
                foreach (Animation anim in AnimationSet)
                {
                    tmpAnimation.Add(anim);
                }
                tmpAnimation.Add(newAnimation);
                AnimationSet = tmpAnimation.ToArray();
            }
            else
            {
                AnimationSet = new Animation[] { newAnimation };
            }
        }
        public void AddAnimation(Animation newAnimation, string[] ImageSet)
        {
            foreach (string Image in ImageSet)//fill the animation with images
            {
                newAnimation.AddImage(Image);
            }
            if (AnimationSet != null)
            {
                List<Animation> tmpAnimation = new List<Animation>();
                foreach (Animation anim in AnimationSet)
                {
                    tmpAnimation.Add(anim);
                }
                tmpAnimation.Add(newAnimation);
                AnimationSet = tmpAnimation.ToArray();
            }
            else
            {
                AnimationSet = new Animation[] { newAnimation };
            }
        }

        public void SetAllLoop(bool _loop)
        {
            foreach (Animation anim in AnimationSet)
            {
                anim.Loop = _loop;
            }
        }

        public void SetAllPaused(bool _pause)
        {
            foreach (Animation anim in AnimationSet)
            {
                anim.Paused = _pause;
            }
        }

        public Animation[] GetAnimationSet
        {
            get
            {
                return AnimationSet;
            }

            set
            {
                AnimationSet = value;
            }
        }
    }
}
