using System;
using gMusic.Managers;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace gMusic.Views
{
    public class LevelView : SKCanvasView
    {
        public LevelView()
        {
            SetupNotification();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            UpdateRects(e.Info.Width, e.Info.Height);
            FillBackground(canvas, fillRect);
            DrawRect(canvas, leftRect);
            DrawRect(canvas, rightRect);
        }

        float[] audioLevelState;
        public float[] AudioLevelState
        {
            get { return audioLevelState; }
            set
            {
                audioLevelState = value;
                var availableHeight = (float)Bounds.Height - 10;
                if (audioLevelState.Length < 1)
                {
                    leftHeight = 0;
                    rightHeight = 0;
                }
                else if (PlaybackManager.Shared.Player.CurrentTimeSeconds() < 1)
                {
                    leftHeight = 0;
                    rightHeight = 0;
                }
                else
                {
                    leftHeight = audioLevelState[0] * availableHeight;
                    rightHeight = audioLevelState[1] * availableHeight;
                }
                this.InvalidateSurface();
            }
        }

        void SetupNotification()
        {
            NotificationManager.Shared.UpdateVisualizer += SharedOnUpdateVisualizer;
        }

        void SharedOnUpdateVisualizer(object sender, EventArgs eventArgs)
        {
            AudioLevelState = PlaybackManager.Shared.Player.AudioLevels;

        }

        public void RemoveNotification()
        {
            try
            {
                NotificationManager.Shared.UpdateVisualizer -= SharedOnUpdateVisualizer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        float leftHeight;
        float rightHeight;

        SKRect leftRect = new SKRect();
        SKRect rightRect = new SKRect();
        SKRect fillRect = new SKRect();
        void UpdateRects(float inWidth, float inHeight)
        {
            float padding = inWidth/14;
            var halfPadding = padding / 2;
            
            var bounds = new Rectangle(0, 0, inWidth, inHeight);

           // leftHeight = rightHeight = (float)bounds.Height - 20;

            bounds.Width /= 2;
            var mid = bounds.Width/2;
            var width = bounds.Width / 2;

            var frame = bounds;
            frame.X = padding + width;
            frame.Width = width - padding - halfPadding;
            frame.Height = leftHeight;
            frame.Y = bounds.Height - leftHeight - padding;
            leftRect = new SKRect((float)frame.X, (float)frame.Top, (float)frame.Right, (float)frame.Bottom);

            frame.X = mid + halfPadding + width;
            frame.Height = rightHeight;
            frame.Y = bounds.Height - rightHeight - padding;
            rightRect = new SKRect((float)frame.X, (float)frame.Top, (float)frame.Right, (float)frame.Bottom);
            fillRect = new SKRect(0, 0, inWidth, inHeight);
            this.InvalidateSurface();
        }
        void FillBackground(SKCanvas canvas, SKRect rect)
        {
            var RectangleStyleFillColor = new SKColor(230, 230, 230, 150);
            var RectangleStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = RectangleStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true
            };
            // Draw Rectangle shape
            canvas.DrawRect(rect, RectangleStyleFillPaint);
        }
        void DrawRect(SKCanvas canvas, SKRect rect)
        {
            var RectangleStyleFillColor = new SKColor(230, 230, 230, 255);
            // New Rectangle Style fill paint
            var RectangleStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = RectangleStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true
            };

            // Frame color for Rectangle Style
            var RectangleStyleFrameColor = new SKColor(0, 0, 0, 180);

            // New Rectangle Style frame paint
            var RectangleStyleFramePaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = RectangleStyleFrameColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true,
                StrokeWidth = 1f,
                StrokeMiter = 4f,
                StrokeJoin = SKStrokeJoin.Miter,
                StrokeCap = SKStrokeCap.Butt
            };
            // Draw Rectangle shape
            canvas.DrawRect(rect, RectangleStyleFillPaint);
            canvas.DrawRect(rect, RectangleStyleFramePaint);
        }
    }


    public class FormsLevelView : AbsoluteLayout
    {
        BoxView leftView;
        BoxView rightView;

        double leftHeight;
        double rightHeight;

        public FormsLevelView()
        {
            leftView = new BoxView
            {
                BackgroundColor = Color.White,
            };
            rightView = new BoxView();
            this.Children.Add(leftView);
            this.Children.Add(rightView);
            SetupNotification();
        }

        float[] audioLevelState;
        public float[] AudioLevelState
        {
            get { return audioLevelState; }
            set
            {
                audioLevelState = value;
                var availableHeight = Bounds.Height - 10;
                if (audioLevelState.Length < 1)
                {
                    leftHeight = 0;
                    rightHeight = 0;
                }
                else if (PlaybackManager.Shared.Player.CurrentTimeSeconds() < 1)
                {
                    leftHeight = 0;
                    rightHeight = 0;
                }
                else
                {
                    leftHeight = audioLevelState[0] * availableHeight;
                    rightHeight = audioLevelState[1] * availableHeight;
                }
                this.InvalidateLayout();
            }
        }



        protected override void LayoutChildren(double x, double y, double inWidth, double inHeight)
        {
            const float padding = 10f;
            const float halfPadding = padding / 2;

            var bounds = new Rectangle(0, 0, inWidth, inHeight);

            //leftHeight = rightHeight = (float)bounds.Height - 10;

            bounds.Width /= 2;
            var mid = bounds.Width / 2;
            var width = bounds.Width / 2;

            var frame = bounds;
            frame.X = padding + width;
            frame.Width = width - padding - halfPadding;
            frame.Height = leftHeight;
            frame.Y = bounds.Height - leftHeight - padding;
            leftView.Layout(frame);

            frame.X = mid + halfPadding + width;
            frame.Height = rightHeight;
            frame.Y = bounds.Height - rightHeight - padding;
            rightView.Layout(frame);

        }

        void SetupNotification()
        {
            NotificationManager.Shared.UpdateVisualizer += SharedOnUpdateVisualizer;
        }

        void SharedOnUpdateVisualizer(object sender, EventArgs eventArgs)
        {
            AudioLevelState = PlaybackManager.Shared.Player.AudioLevels;

        }

        void RemoveNotification()
        {
            try
            {
                NotificationManager.Shared.UpdateVisualizer -= SharedOnUpdateVisualizer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

}

