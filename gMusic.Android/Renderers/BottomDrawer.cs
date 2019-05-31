using System;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using gMusic.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;

namespace gMusic.Droid.Renderers {
	public class BottomDrawer : CoordinatorLayout {

		int _currentLockMode = -1;
		bool _isPresentingFromCore;
		bool _presented;


		public bool Presented {
			get { return _presented; }
			set {
				if (value == _presented)
					return;
				//UpdateSplitViewLayout ();
				_presented = value;
			}
		}

		public BottomDrawer (Context context) : base (context)
		{
			Context = context;
		}

		MasterDetailContainer bottomView;
		AView contentView;

		public Context Context { get; }

		AnchorBottomSheetBehavior behaviour;
		internal void Setup (BottomDrawerShell bottomDrawerShell, AView child)
		{



			child.LayoutParameters = new LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			AddView (child);

			var parameters = new CoordinatorLayout.LayoutParams (new LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent) { Gravity = (int)GravityFlags.Start });
			parameters.Behavior = new AnchorBottomSheetBehavior ();





			var drawerPage = bottomDrawerShell.DrawerPage as VisualElement;
			bottomView = new MasterDetailContainer (Context) {
				ChildView = drawerPage,
				LayoutParameters = parameters,
			};
			AddView (bottomView);


			behaviour = AnchorBottomSheetBehavior.From (bottomView);

			behaviour.PeekHeight = 200;


		}
		public void OnDrawerClosed (AView drawerView)
		{
		}

		public void OnDrawerOpened (AView drawerView)
		{
		}

		public void OnDrawerSlide (AView drawerView, float slideOffset)
		{
		}

		public void OnDrawerStateChanged (int newState)
		{
			//TODO:
			//_presented = IsDrawerVisible(_masterLayout);
			UpdateIsPresented ();
		}
		void UpdateIsPresented ()
		{
			if (_isPresentingFromCore)
				return;
			//if (Presented != _page.IsPresented)
			//	((IElementController)_page).SetValueFromRenderer (MasterDetailPage.IsPresentedProperty, Presented);
		}


		class MasterDetailContainer : ViewGroup {
			const int DefaultMasterSize = 320;
			const int DefaultSmallMasterSize = 240;
			private readonly Context context;

			public MasterDetailContainer (Context context) : base (context)
			{
				this.context = context;
			}

			public MasterDetailContainer (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) { }
			VisualElement _childView;
			public VisualElement ChildView {
				get { return _childView; }
				set {
					if (_childView == value)
						return;

					RemoveAllViews ();
					if (_childView != null)
						DisposeChildRenderers ();

					_childView = value;

					if (_childView == null)
						return;

					AddChildView (_childView);
				}
			}

			protected virtual void AddChildView (VisualElement childView)
			{
				IVisualElementRenderer renderer = Platform.GetRenderer (childView);
				if (renderer == null)
					Platform.SetRenderer (childView, renderer = Platform.CreateRendererWithContext (childView, context));

				if (renderer.View.Parent != this) {
					if (renderer.View.Parent != null)
						renderer.View.RemoveFromParent ();
					SetDefaultBackgroundColor (renderer);
					AddView (renderer.View);
					renderer.UpdateLayout ();
				}
			}

			public int TopPadding { get; set; }

			double DefaultWidthMaster {
				get {
					double w = Context.FromPixels (Resources.DisplayMetrics.WidthPixels);
					return w < DefaultSmallMasterSize ? w : (w < DefaultMasterSize ? DefaultSmallMasterSize : DefaultMasterSize);
				}
			}

			

			protected override void Dispose (bool disposing)
			{
				if (disposing) {
					RemoveAllViews ();
					DisposeChildRenderers ();
				}
				base.Dispose (disposing);
			}

			protected override void OnLayout (bool changed, int l, int t, int r, int b)
			{
				if (_childView == null)
					return;

				Rectangle bounds = GetBounds (l, t, r, b);
				_childView.Layout (bounds);

				IVisualElementRenderer renderer = Platform.GetRenderer (_childView);
				renderer?.UpdateLayout ();
			}

			void DisposeChildRenderers ()
			{
				IVisualElementRenderer childRenderer = Platform.GetRenderer (_childView);
				if (childRenderer != null)
					childRenderer.Dispose ();
				//_childView.ClearValue(Platform.RendererProperty);
			}

			Rectangle GetBounds (int left, int top, int right, int bottom)
			{
				double width = Context.FromPixels (right - left);
				double height = Context.FromPixels (bottom - top);
				double xPos = 0;

				double padding = 0;
				return new Rectangle (xPos, padding, width, height - padding);
			}

			protected void SetDefaultBackgroundColor (IVisualElementRenderer renderer)
			{
				if (ChildView.BackgroundColor == Color.Default) {
					TypedArray colors = Context.Theme.ObtainStyledAttributes (new [] { global::Android.Resource.Attribute.ColorBackground });
					renderer.View.SetBackgroundColor (new global::Android.Graphics.Color (colors.GetColor (0, 0)));
				}
			}
		}

	}
}