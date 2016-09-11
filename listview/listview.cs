using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace listview
{
	public class ListItem 
	{ 
		public string Title { get; set; }
		public Color Color { get; set; }
	}


	public class App : Application
	{
		public App()
		{
			var items = new List<ListItem>() { 
				new ListItem { Title = "Item 1", Color = Color.Accent },
				new ListItem { Title = "Item 2", Color = Color.Aqua },
				new ListItem { Title = "Item 3", Color = Color.Red },
			};

			var list = new ListView();
			list.ItemsSource = items;
			list.ItemTemplate = new DataTemplate(() => {
				var layout = new StackLayout();
				layout.SetBinding(VisualElement.BackgroundColorProperty, "Color");

				var label = new Label();
				label.SetBinding(Label.TextProperty, "Title");
				layout.Children.Add(label);

				return new ViewCell { 
					View = layout
				};
			});

			var content = new ContentPage { 
				Title = "List View",
				Content = list
			};

			MainPage = new NavigationPage(content);
		}

	}
}

