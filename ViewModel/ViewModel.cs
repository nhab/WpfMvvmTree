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
        public ViewModel()
        {
            string path = @"c:\temp";
            foreach (var dir in Directory.GetDirectories(path)) LoadFolder(dir, col);
            cvs.Source = col;
        }

        private void LoadFolder(string path, ObservableCollection<ItemModel> col)
        {
            ItemModel folder = new ItemModel() { Name = IO.Path.GetFileNameWithoutExtension(path) };
            col.Add(folder);
            foreach (var dir in Directory.GetDirectories(path)) LoadFolder(dir, folder.Children);
        }
        public ICollectionView View { get => cvs.View; }
        private CollectionViewSource cvs = new CollectionViewSource();
        private ObservableCollection<ItemModel> col = new ObservableCollection<ItemModel>();
    }
}