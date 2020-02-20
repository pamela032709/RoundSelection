using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace wrap.Controls
{
    public abstract class TagButton : Button
    {
        public static readonly BindableProperty SelectionCommandProperty =
            BindableProperty.Create(nameof(SelectionCommand), typeof(ICommand), typeof(TagButton), null);

        public static readonly BindableProperty SelectionCommandParameterProperty =
            BindableProperty.Create(nameof(SelectionCommandParameter), typeof(object), typeof(TagButton), null);

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TagButton), false, propertyChanged: IsSelectedPropertyChanged);

        private static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((TagButton)bindable).ChangeButtonStyle();
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public ICommand SelectionCommand
        {
            get { return (ICommand)GetValue(SelectionCommandProperty); }
            set { SetValue(SelectionCommandProperty, value); }
        }

        public object SelectionCommandParameter
        {
            get { return GetValue(SelectionCommandParameterProperty); }
            set { SetValue(SelectionCommandParameterProperty, value); }
        }

        private readonly Color blueColor = (Color)Application.Current.Resources["NsuSpacesBlue"];

        public TagButton()
        {
            InitializeControls();
        }

        protected void InitializeControls()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            HeightRequest = 30;
            CornerRadius = 15;
            FontSize = 11;
            BorderWidth = 1;
            BorderColor = blueColor;
            TextColor = blueColor;
            BackgroundColor = Color.Transparent;
            Command = new Command(OnItemTapped);

            ChangeButtonStyle();
        }

        protected virtual void OnItemTapped()
        {
            IsSelected = !IsSelected;

            ChangeButtonStyle();

            SelectionCommand?.Execute(SelectionCommandParameter);
        }

        protected virtual void ChangeButtonStyle()
        {
            if (IsSelected)
            {
                BackgroundColor = blueColor;
                TextColor = Color.White;
            }
            else
            {
                BackgroundColor = Color.Transparent;
                TextColor = blueColor;
            }
        }
    }
}
