using System.Windows;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SimpleInjector;

using Ardalis.GuardClauses;

using GalaSoft.MvvmLight.Messaging;

using ServiceBusApp.Presentation.ViewModels;
using ServiceBusApp.Presentation.Views;
using ServiceBusApp.Presentation.Services;
using ServiceBusApp.Presentation.Services.Abstractions;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Data.Repositories.Abstractions;
using ServiceBusApp.Data.Repositories;
using ServiceBusApp.Data;


namespace ServiceBusApp.Presentation;

public partial class App : Application
{
    public static IClassRepository _classRepository { get; set; }
    public static IStudentRepository _studentRepository { get; set; }
    public static ICarRepository _carRepository { get; set; }
    public static IDriverRepository _driverRepository { get; set; }
    public static IParentRepository _parentRepository { get; set; }
    public static IRideRepository _rideRepository { get; set; }
    public static ApplicationDbContext _dbContext { get; set; }
    public static Container _container { get; set; }

    void Register()
    {
        _container = new Container();

        _container.Register<ApplicationDbContext>(() => new ApplicationDbContext(), Lifestyle.Singleton);

        _container.Register<INavigationService, NavigationService>(Lifestyle.Singleton);
        _container.Register<IMessenger, Messenger>(Lifestyle.Singleton);

        _container.Register<IClassRepository, ClassRepository>(Lifestyle.Singleton);
        _container.Register<IStudentRepository, StudentRepository>(Lifestyle.Singleton);
        _container.Register<IParentRepository, ParentRepository>(Lifestyle.Singleton);
        _container.Register<ICarRepository, CarRepository>(Lifestyle.Singleton);
        _container.Register<IRideRepository , RideRepository>(Lifestyle.Singleton);
        _container.Register<IDriverRepository, DriverRepository>(Lifestyle.Singleton);

        _container.RegisterSingleton<MainWindow>();
        _container.RegisterSingleton<StudentsView>();
        _container.RegisterSingleton<ClassesView>();
        _container.RegisterSingleton<ParentsView>();
        _container.RegisterSingleton<DriversView>();
        _container.RegisterSingleton<CarsView>();
        _container.RegisterSingleton<RidesView>();
        _container.RegisterSingleton<RidesView2>();
        _container.RegisterSingleton<AddClassView>();
        _container.RegisterSingleton<AddParentView>();
        _container.RegisterSingleton<AddCarView>();
        _container.RegisterSingleton<AddDriverView>();
        _container.RegisterSingleton<AddStudentView>();
        _container.RegisterSingleton<EditStudentView>();
        _container.RegisterSingleton<EditParentView>();
        _container.RegisterSingleton<EditCarView>();
        _container.RegisterSingleton<EditClassView>();
        _container.RegisterSingleton<EditRideView>();

        _container.Register<MainViewModel>();
        _container.Register<StudentViewModel>();
        _container.Register<ClassViewModel>();
        _container.Register<RidesViewModel>();
        _container.Register<ParentViewModel>();
        _container.Register<DriverViewModel>();
        _container.Register<RideViewModel>();
        _container.Register<CarViewModel>();
        _container.Register<AddClassViewModel>();
        _container.Register<AddStudentViewModel>();
        _container.Register<AddParentViewModel>();
        _container.Register<AddCarViewModel>();
        _container.Register<AddDriverViewModel>();
        _container.RegisterSingleton<EditStudentViewModel>();
        _container.RegisterSingleton<EditClassViewModel>();
        _container.RegisterSingleton<EditParentViewModel>();
        _container.RegisterSingleton<EditCarViewModel>();
        _container.RegisterSingleton<EditDriverViewModel>();
        _container.RegisterSingleton<EditRideViewModel>();

        _container.Verify();
    }

    protected sealed override void OnStartup(StartupEventArgs e)
    {
        Register();

        _dbContext = _container.GetInstance<ApplicationDbContext>();

        _classRepository = _container.GetInstance<IClassRepository>();
        _studentRepository = _container.GetInstance<IStudentRepository>();
        _carRepository = _container.GetInstance<ICarRepository>();
        _driverRepository = _container.GetInstance<IDriverRepository>();
        _parentRepository = _container.GetInstance<IParentRepository>();
        _rideRepository = _container.GetInstance<IRideRepository>();

        var window = Guard.Against.Null(_container.GetInstance<MainWindow>());

        window.WindowState = WindowState.Maximized;
        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        window.DataContext = _container.GetInstance<MainViewModel>();
        window.ShowDialog();

        Current.Shutdown();
    }
}