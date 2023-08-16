using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WpfMvvmTree.Base;
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
      
            TreeModel root1 = new TreeModel("Root 1");
       
            root1.Children.Add(new TreeModel("Child 1")) ;
            root1.Children.Add(new TreeModel("Child 2"));
            col.Add(root1);
            
            cvs.Source = col;
           
        }

        RelayCommand addParentCommand;

        public ICommand AddParentCommand
        {
            get
            {
                if (addParentCommand == null)
                    addParentCommand = new RelayCommand(AddParent);
                return addParentCommand;
            }

        }
        private void AddParent(object parameter)
        {
            col.Add(new TreeModel { Name = "New Parent", Children = new ObservableCollection<TreeModel>() });
        }
    }
}