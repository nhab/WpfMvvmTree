using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmTree
{

    public class TreeModel
    {
        public string Name { get; set; }
        public ObservableCollection<TreeModel> Children { get; set; } 
        
        public TreeModel(string name="") {
            Children = new ObservableCollection<TreeModel>();
            if (!string.IsNullOrEmpty(name))
                Name = name;
        }

    }
}