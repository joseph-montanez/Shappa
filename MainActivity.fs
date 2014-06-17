namespace Shappa

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "Shappa", MainLauncher = true)>]
type MainActivity () =
    inherit ListActivity ()

    let mutable count = 1
    let items = [| "Orders"; "Materials" |]


    override this.OnCreate (bundle) =

        base.OnCreate (bundle)
        this.SetContentView (Resource_Layout.Main)

        // Add array to list view
        this.ListAdapter <- new HomeScreenAdapter(this, items)

        // Add click event to the button
        let button = this.FindViewById<Button>(Resource_Id.myButton)
        button.Click.Add (fun args -> 
            button.Text <- sprintf "%d clicks!" count
            count <- count + 1
        )

    override this.OnListItemClick (listView, view, position, id) = 
        let item = items.[position]
        let toast = Toast.MakeText(this, item, ToastLength.Short)
        toast.Show()