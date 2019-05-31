using System;
using System.ComponentModel;
using System.Linq;
using UIKit;
using PointF = CoreGraphics.CGPoint;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using gMusic;
using gMusic.Forms;
using gMusic.Forms.iOS;
using gMusic.Views;

namespace gMusic.iOS.Renderers {
	public class BottomDrawer : UIViewController {
		BottomDrawerShell model;
		public BottomDrawerShell Model {
			get => model;
			set {
				model = value;
				UpdateMasterDetailContainers ();
			}
		}


		UIViewController _detailController;

		bool _disposed;
		EventTracker _events;

		UIViewController _masterController;

		UIPanGestureRecognizer _panGesture;

		public bool Presented {get;set;}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();


			LayoutChildren(false);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			PackContainers();
			UpdateMasterDetailContainers();

			UpdatePanGesture();
		}

		
		protected override void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				
				if (_events != null)
				{
					_events.Dispose();
					_events = null;
				}


				if (_panGesture != null)
				{
					if (View != null && View.GestureRecognizers.Contains(_panGesture))
						View.RemoveGestureRecognizer(_panGesture);
					_panGesture.Dispose();
				}

				EmptyContainers();

				_disposed = true;
			}

			base.Dispose(disposing);
		}

		void EmptyContainers()
		{
			if (_masterController == null)
				return;
			foreach (var child in _masterController.View.Subviews)
				child.RemoveFromSuperview();

			foreach (var vc in _masterController.ChildViewControllers)
				vc.RemoveFromParentViewController();
		}


		void LayoutChildren(bool animated)
		{
			var frame = View.Bounds;
			var target = frame;
			target.Y = 0;
			if (!Presented)
				target.Y = target.Height - this.Model.OverHang;

			if (animated)
			{
				UIView.BeginAnimations("Flyout");
				var view = _masterController.View;
				view.Frame = target;
				UIView.SetAnimationCurve(UIViewAnimationCurve.EaseOut);
				UIView.SetAnimationDuration(250);
				UIView.CommitAnimations();
			}
			else
				_masterController.View.Frame = target;


			(Model?.DrawerPage as Page)?.Layout (new Rectangle (0, 0, frame.Width, frame.Height));
			//MasterDetailPageController.MasterBounds = new Rectangle(0, 0, frame.Width, frame.Height);
			//MasterDetailPageController.DetailBounds = new Rectangle(0, 0, frame.Width, frame.Height);

		}

		void PackContainers()
		{
			if (_masterController != null)
				return;

			_masterController = new ChildViewController {
				View = {
					BackgroundColor = Color.Fuchsia.ToUIColor(),
				}
			};
			_detailController = new ChildViewController ();

			_detailController.View.BackgroundColor = new UIColor(1, 1, 1, 1);
			View.AddSubview(_detailController.View);
			View.AddSubview(_masterController.View);

			AddChildViewController(_masterController);
			AddChildViewController(_detailController);
		}

		void PageOnSizeChanged(object sender, EventArgs eventArgs)
		{
			LayoutChildren(false);
		}


		UIViewController contentViewController;
		public void SetContentViewController(UIViewController content)
		{
			this.contentViewController = content;
			SetDetail ();
		}

		void SetDetail()
		{
			foreach (var child in _detailController.View.Subviews)
				child.RemoveFromSuperview ();

			foreach (var vc in _detailController.ChildViewControllers)
				vc.RemoveFromParentViewController ();

			if (contentViewController == null)
				return;
			_detailController.View.Add (contentViewController.View);
			_detailController.AddChildViewController (contentViewController);

		}

		void UpdateMasterDetailContainers()
		{
			if (_masterController == null)
				return;
			EmptyContainers();

			if (Platform.GetRenderer(Model.DrawerPage as VisualElement) == null)
				Platform.SetRenderer(Model.DrawerPage as VisualElement, Platform.CreateRenderer(Model.DrawerPage as VisualElement));
			
			var masterRenderer = Platform.GetRenderer(Model.DrawerPage as VisualElement);
			

			//((MasterDetailPage)Element).Master.PropertyChanged += HandleMasterPropertyChanged;

			_masterController.View.AddSubview(masterRenderer.NativeView);
			_masterController.AddChildViewController(masterRenderer.ViewController);
			SetDetail ();
		}


		const float FlickVelocity = 1000f;
		void UpdatePanGesture()
		{

			if (_panGesture != null)
			{
				_masterController.View.AddGestureRecognizer(_panGesture);
				return;
			}

			UITouchEventArgs shouldRecieve = (g, touch) =>
			{
				bool isMovingCell =
							touch.View.ToString().IndexOf("UITableViewCellReorderControl", StringComparison.InvariantCultureIgnoreCase) >
							-1;
				if (isMovingCell || touch.View is UISlider)// || touch.View is MPVolumeView )
					return false;
				return true;
			};
			var center = new PointF();
			nfloat startY = 0;
			bool isPanning = false;
            _panGesture = new UIPanGestureRecognizer(g =>
            {
                var frame = _masterController.View.Frame;
                nfloat translation = g.TranslationInView(this.View).Y;
                switch (g.State)
                {
                    case UIGestureRecognizerState.Began:
                        isPanning = true;
                        startY = frame.Y;
                        center = g.LocationInView(g.View);
                        break;
                    case UIGestureRecognizerState.Changed:
                        frame.Y = translation + startY;
                        frame.Y = NMath.Min(frame.Height, NMath.Max(frame.Y, Model.OverHang * -1));
						this.Model.PercentVisible = (float)((frame.Height - frame.Y) / frame.Height);

						_masterController.View.Frame = frame;
                        break;
                    case UIGestureRecognizerState.Ended:
                        isPanning = false;
                        var velocity = g.VelocityInView(this.View).Y;
                        //					Console.WriteLine (velocity);
                        var show = (Math.Abs(velocity) > FlickVelocity)
                            ? (velocity < 0)
                            : (translation * -1 > 100);
                        float playbackBarHideTollerance = (float)Model.OverHang * 2 / 3;
						if (show) {
							Presented = true;
							Model.PercentVisible = 1;
						} else {
							Presented = false;
							Model.PercentVisible = 0;
						}
						LayoutChildren (true);
                        break;
                }
            })
            {
                ShouldReceiveTouch = shouldRecieve,
                MaximumNumberOfTouches = 2
            };
			_masterController.View.AddGestureRecognizer(_panGesture);
		}

		class ChildViewController : UIViewController
		{
			public override void ViewDidLayoutSubviews()
			{
				foreach (var vc in ChildViewControllers)
					vc.View.Frame = View.Bounds;
			}
		}

		
	}
}