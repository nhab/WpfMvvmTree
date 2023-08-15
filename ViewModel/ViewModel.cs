using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using IO = System.IO;

namespace WpfMvvmTree
{
   public class ViewModel
    { 
        private CollectionViewSource cvs = new CollectionViewSource();
        private ObservableCollection<TreeModel> col = new ObservableCollection<TreeModel>();

        public ICollectionView View { get => cvs.View; }

        public ViewModel()
        {
            string path = @"c:\temp";
            foreach (var dir in Directory.GetDirectories(path)) 
                LoadFolder(dir, col);
            cvs.Source = col;
        }

        private void LoadFolder(string path, ObservableCollection<TreeModel> col)
        {
            TreeModel tree = new TreeModel() 
            { 
                Name = IO.Path.GetFileNameWithoutExtension(path) 
            };
            col.Add(tree);
            foreach (var dir in Directory.GetDirectories(path)) 
                LoadFolder(dir, tree.Children);
        }
       
    }
}