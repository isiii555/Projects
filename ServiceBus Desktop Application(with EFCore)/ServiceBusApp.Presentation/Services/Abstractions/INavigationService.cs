using GalaSoft.MvvmLight;


namespace ServiceBusApp.Presentation.Services.Abstractions;

public interface INavigationService
{
    void NavigateTo<T>() where T : ViewModelBase;
}