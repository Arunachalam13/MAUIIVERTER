using MAUIIVERTER.MVVM.Views;

namespace MAUIIVERTER;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();
        //MainPage = new MenuView();
        //MainPage = new ConverterView();
        MainPage = new NavigationPage(new MenuView());

    }
}
