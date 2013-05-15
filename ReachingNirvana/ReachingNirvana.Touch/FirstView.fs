namespace ReachingNirvana.Touch

open System
open System.Drawing
open MonoTouch.UIKit
open MonoTouch.Foundation
open ReachingNirvana.Core
open Cirrious.MvvmCross.Binding
open Cirrious.MvvmCross.Binding.BindingContext
open Cirrious.MvvmCross.Touch.Views


[<Register ("FirstView")>]
type FirstView () =
    inherit MvxViewController ()
   
    let  label = new UILabel()
    let textBox = new UITextField() 
    
    // Release any cached data, images, etc that aren't in use.
    override this.DidReceiveMemoryWarning () =
        base.DidReceiveMemoryWarning ()

    // Perform any additional setup after loading the view, typically from a nib.
    override this.ViewDidLoad () =
        base.ViewDidLoad ()
        this.View.BackgroundColor <- UIColor.White
        label.Frame <- new RectangleF((float32)0,(float32)0,(float32)320,(float32)50)
        this.Add(label)
        textBox.Frame <- new RectangleF((float32)0,(float32)70,(float32)320,(float32)50)
        this.Add(textBox)
        
        let set  =  MvxBindingContextOwnerExtensions.CreateBindingSet<FirstView,FirstViewModel>(this)
        set.Bind(label).To("Hello") |> ignore
        set.Bind(textBox).To("Hello") |> ignore
        set.Apply()
        
        
    // Return true for supported orientations
    override this.ShouldAutorotateToInterfaceOrientation (orientation) =
        orientation <> UIInterfaceOrientation.PortraitUpsideDown

