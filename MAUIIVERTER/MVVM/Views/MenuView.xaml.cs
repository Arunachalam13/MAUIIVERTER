using MAUIIVERTER.MVVM.ViewModels;

namespace MAUIIVERTER.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		this.BindingContext = new MenuViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var element = (Grid)sender;
		var option = ((Label)element.Children.LastOrDefault()).Text;
		var converter = new ConverterView
		{
			BindingContext = new ConverterViewModel(option)
		};
		Navigation.PushAsync(converter);
    }
}