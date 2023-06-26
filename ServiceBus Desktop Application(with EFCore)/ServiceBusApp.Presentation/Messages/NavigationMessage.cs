using System;


namespace ServiceBusApp.Presentation.Messages;

public class NavigationMessage
{
    public Type? ViewModelType { get; set; }
}