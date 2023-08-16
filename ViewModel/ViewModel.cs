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
        private CollectionViewSource cvs;
        private ObservableCollection<TreeModel> col;

        public ICollectionView View { get => cvs.View; }

        public ViewModel()
        {
            cvs = new CollectionViewSource();
            col = new ObservableCollection<TreeModel>();
            //string path = @"c:\temp";
            //foreach (var dir in Directory.GetDirectories(path)) 
            //    LoadFolder(dir, col);
            TreeModel root1 = new TreeModel("Root 1");
            
            TreeModel child1=new TreeModel("Child 1");
            TreeModel child2 = new TreeModel("Child 2");
            root1.Children.Add(child1) ;
            root1.Children.Add(child2);
            col.Add(root1);
            
            cvs.Source = col;
        }

        //private void LoadFolder(string path, ObservableCollection<TreeModel> col)
        //{
        //    TreeModel tree = new TreeModel() 
        //    { 
        //        Name = IO.Path.GetFileNameWithoutExtension(path) 
        //    };
        //    col.Add(tree);
        //    foreach (var dir in Directory.GetDirectories(path)) 
        //        LoadFolder(dir, tree.Children);
        //}
       
    }
}