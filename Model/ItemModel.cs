using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmTree
{

    public class ItemModel
    {
        public string Name { get; set; }
        public ObservableCollection<ItemModel> Children { get; set; } = new ObservableCollection<ItemModel>();
    }
}