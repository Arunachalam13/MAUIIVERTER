using MAUIIVERTER.MVVM.ViewModels;

namespace MAUIIVERTER.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		//this.BindingContext = new ConverterViewModel();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
    }
}