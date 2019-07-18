using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using gMusic.Views.Controls;
using Xamarin.Forms;

namespace gMusic.Views {
	public class PanaramaView : AbsoluteLayout {
		List<Label> labels = new List<Label> ();
		List<View> views = new List<View> ();
		ScrollView scrollView;
        MyContentView content;

		Color titleColor;
		Font titleFont;
		Color selectedColor;
		public PanaramaView ()
		{
            AutomationId = "PanaramaView";
			selectedColor = Styles.Styles.CurrentStyle.AccentColor;
			titleColor = selectedColor.MultiplyAlpha (.25);
			titleFont = Styles.Styles.CurrentStyle.HeaderTextThinFont;
			
			Children.Add (scrollView = new PagingScrollView
            {
				Orientation = ScrollOrientation.Horizontal,
				Content = content = new MyContentView { Parent = this },
			});

			scrollView.Scrolled += ScrollView_Scrolled;

			AbsoluteLayout.SetLayoutFlags (scrollView, AbsoluteLayoutFlags.SizeProportional);
			AbsoluteLayout.SetLayoutBounds (scrollView, new Rectangle (0, 0, 1, 1));
		}

		void ScrollView_Scrolled (object sender, ScrolledEventArgs e)
		{
            content.SetTopScroll(false);
		}
		static double headerPadding = 20f;

		

		double headerHeight = 44;
		public double HeaderHeight {
			get { return headerHeight; }
			set {
				if (headerHeight == value)
					return;
				headerHeight = value;
                this.InvalidateLayout();
			}
		}
		public void AddPage (string title, View view)
		{
			var label = new Label {
				Text = title,
				Font = titleFont,
				TextColor = selectedColor,
                AutomationId = "SearchResultPageHeader"
			}.AddTapGesture (ScrollToLabel);

			labels.Add (label);
			content.Children.Add (label);

            view.AutomationId = "SearchResultView";
			views.Add (view);
			content.Children.Add (view);
            content.ForceLayout();
            scrollView.ForceLayout();
            this.ForceLayout();

        }
		
		void ScrollToLabel (Label label)
		{
			ScrollToIndex (labels.IndexOf (label));
		}

		async void ScrollToIndex (int index)
		{
			await scrollView.ScrollToAsync (index * scrollView.Width, 0, true);
		}

		public void Clear ()
		{
			Children.Clear ();
			content.Children.Clear ();
			Children.Add (scrollView);
			labels.Clear ();
			views.Clear ();
		}

		protected override void LayoutChildren (double x, double y, double width, double height)
        {
            content.WidthRequest = width * views.Count;
            base.LayoutChildren (x, y, width, height);
        }
 

        class MyContentView : AbsoluteLayout
        {
            public PanaramaView Parent { get; set; }

            protected override void LayoutChildren(double x, double y, double width, double height)
            {
                var bound = new Rectangle(0, Parent.HeaderHeight, Parent.Width, Parent.Height - Parent.HeaderHeight);
                base.LayoutChildren(x, y, width, height);
                for (var i = 0; i < Parent.views.Count; i++)
                {
                    var v = Parent.views[i];
                    bound.X = i * bound.Width;
                    v.Layout(bound);

                }
                SetTopScroll(true);
            }

            Label lastCurrentButton;
            public void SetTopScroll(bool forceCheck)
            {

                if (Parent.labels.Count == 0)
                    return;
                var scrollWidth = Parent.Width;
                var scrollOffset = Parent.scrollView.ScrollX;
                var index = scrollWidth == 0 ? 0 : (scrollOffset / scrollWidth);

                var intindex = (int)Math.Max(0, Math.Min(index, Parent.labels.Count - 1));
                var currentButton = Parent.labels[intindex];
                var didChanged = forceCheck || currentButton != lastCurrentButton;

                //Debug.WriteLine ($"Current tab did change: {didChanged}");
                lastCurrentButton = currentButton;
                //Figure out the exact middle of the screen inside the scrollview
                var half = scrollWidth / 2;
                var x = (scrollWidth * index) + half - (currentButton.Width / 2);


                //We need to calculate the distance we scroll based on the distance of the middles of the current label and the next label
                var nextIndex = intindex + 1;

                var currentWidth = currentButton.Width;
                if (nextIndex < Parent.labels.Count)
                    currentWidth = currentWidth / 2 + headerPadding + Parent.labels[nextIndex].Width / 2;

                //This is the start of the Current Label
                var leftX = x - (index - intindex) * currentWidth;

                var halfTop = Parent.HeaderHeight / 2f;
                var previousIndexes = Enumerable.Range(0, intindex).Reverse();
                var nextIndexes = Enumerable.Range(intindex + 1, Parent.labels.Count - intindex - 1);

                //Set the current page frame
                if (didChanged)
                {
                    currentButton.TextColor = Parent.selectedColor;
                }
                var frame = currentButton.Bounds;
                frame.X = leftX;
                frame.Y = halfTop - frame.Height / 2;
                currentButton.Layout(frame);

                var rightX = currentButton.Bounds.Right + headerPadding;
                //Set the frame of the labels in front of the current label ones
                foreach (var i in previousIndexes)
                {
                    var button = Parent.labels[i];

                    frame = button.Bounds;
                    leftX -= frame.Width + headerPadding;
                    frame.X = leftX;
                    frame.Y = halfTop - frame.Height / 2;
                    button.Layout(frame);
                    if (didChanged)
                    {
                        button.TextColor = Parent.titleColor;
                    }
                }

                //Set the frame of the next labels
                foreach (var i in nextIndexes)
                {
                    if (i < 0)
                        continue;
                    if (i > Parent.labels.Count - 1)
                        break;
                    var button = Parent.labels[i];
                    frame = button.Bounds;
                    frame.X = rightX;
                    frame.Y = halfTop - frame.Height / 2;
                    button.Layout(frame);
                    if (didChanged)
                    {
                        button.TextColor = Parent.titleColor;
                    }
                    rightX = frame.Right + headerPadding;
                }
            }
        }
	}
}
