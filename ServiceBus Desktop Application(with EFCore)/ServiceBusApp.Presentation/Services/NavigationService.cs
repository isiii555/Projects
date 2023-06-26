using Ardalis.GuardClauses;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using ServiceBusApp.Presentation.Messages;
using ServiceBusApp.Presentation.Services.Abstractions;


namespace ServiceBusApp.Presentation.Services;

public class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;


    public NavigationService(IMessenger messenger)
    {
        _messenger = Guard.Against.Null(messenger);
    }


    public void NavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T)});   
    }
}