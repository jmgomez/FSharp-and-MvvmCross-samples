
namespace ReachingNirvana.Core
open System
open Cirrious.CrossCore.IoC
open Cirrious.MvvmCross.ViewModels

type FirstViewModel() = 
    inherit MvxViewModel()
    let mutable hello : string = "Hello MvvmCross"
    member this.Hello
        with get () = hello
        and set (value) =         
            hello <- value 
            this.RaisePropertyChanged("Hello")
type App ()  = 
    inherit Cirrious.MvvmCross.ViewModels.MvxApplication()
    override u.Initialize() = 
        u.RegisterAppStart<FirstViewModel>()

