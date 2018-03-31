using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace LearnToday.Resources.menu
{
    class RecyclesViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<RecyclesViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<RecyclesViewAdapterClickEventArgs> ItemLongClick;
        string[] items;

        public RecyclesViewAdapter(string[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new RecyclesViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as RecyclesViewAdapterViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;

        void OnClick(RecyclesViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(RecyclesViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class RecyclesViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public RecyclesViewAdapterViewHolder(View itemView, Action<RecyclesViewAdapterClickEventArgs> clickListener,
                            Action<RecyclesViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new RecyclesViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RecyclesViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class RecyclesViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}