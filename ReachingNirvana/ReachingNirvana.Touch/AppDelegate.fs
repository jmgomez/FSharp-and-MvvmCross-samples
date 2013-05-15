namespace ReachingNirvana.Touch

open System
open MonoTouch.UIKit
open MonoTouch.Foundation
open Cirrious.MvvmCross.Touch.Platform
open Cirrious.MvvmCross.Touch.Views.Presenters
open Cirrious.MvvmCross.ViewModels
open Cirrious.CrossCore
open ReachingNirvana.Core

type Setup (applicationDelegate:MvxApplicationDelegate, presenter: IMvxTouchViewPresenter) = 
    inherit MvxTouchSetup(applicationDelegate,presenter )
    override u.CreateApp() = 
        new App():> IMvxApplication

    

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit MvxApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        let presenter = new MvxTouchViewPresenter(this,window)
        let setup = new Setup(this,presenter)
        setup.Initialize()
        let startup = Mvx.Resolve<IMvxAppStart>()
        startup.Start()
        
        window.MakeKeyAndVisible ()
        true

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

