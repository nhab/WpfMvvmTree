# Wpf Mvvm Tree view
A hello world, getting started project to show a WPF TreeView Binding into a hierarchical data of a ViewModel
##Steps
1- Add Tree Model:
```
  public class TreeModel
    {
        public string Name { get; set; }
        public ObservableCollection<TreeModel> Children 
        { get; set; } = new ObservableCollection<TreeModel>();
    }
```
2- Create a ViewModel and Fill the Tree in ViewModel
```
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
```
3- Add Treeview to Xaml and bind it:
```
  <TreeView ItemsSource="{Binding View}">
      <TreeView.Resources>
          <HierarchicalDataTemplate
              DataType="{x:Type wpfmvvmtree:TreeModel}" 
              ItemsSource="{Binding Children}">
              <TextBlock Text="{Binding Name}"/>
          </HierarchicalDataTemplate>
      </TreeView.Resources>
  </TreeView>
```
