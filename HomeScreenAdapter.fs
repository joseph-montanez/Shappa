
namespace Shappa
open System
open System.Collections
open System.Collections.Generic
open System.Collections.ObjectModel
open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget



type HomeScreenAdapter(context : Activity, items : array<string>) = 
    inherit BaseAdapter ()
    let context = context

    override this.Count with get () = items.Length
    override this.GetItem(position) = new Java.Lang.String(items.[position].ToCharArray()) :> Java.Lang.Object
    override this.GetItemId(position) = int64 position
    override this.GetView(position, convertView, parent) =
        let view = match convertView with
                    | null -> context.LayoutInflater.Inflate(Resource_Layout.SimpleListItem1, null)
                    | _ -> convertView
        view.FindViewById<TextView>(Resource_Id.txtview).Text <- items.[position].ToString()
        view