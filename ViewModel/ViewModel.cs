using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        RelayCommand addParentCommand;

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
            
            if (parameter is TreeModel selectedItm)
            {
                TreeModel newNode = new TreeModel
                {
                    Name = "New Parent",
                    Children = new ObservableCollection<TreeModel>()
                };

                foreach (TreeModel child in col)
                {
                    if (child.id == selectedItm.id)
                    {
                        child.Children.Add(newNode);
                    }else
                    {
                        if(child.Children.Count>0)
                            foreach (TreeModel grandchild in child.Children)
                            {
                                if (grandchild.id == selectedItm.id)
                                {
                                    grandchild.Children.Add(newNode);
                                }
                            }
                    }
                }

              
            }
        }


    }
}