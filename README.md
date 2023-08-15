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
1- Add Treeview to Xaml and bind it:
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
1- Create ViewModel and Fill the Tree in ViewModel
```
 public class ViewModel
    {
        public ViewModel()
        {
            string path = @"c:\temp";
            foreach (var dir in Directory.GetDirectories(path)) LoadFolder(dir, col);
            cvs.Source = col;
        }

        private void LoadFolder(string path, ObservableCollection<TreeModel> col)
        {
            TreeModel folder = new TreeModel() { Name = IO.Path.GetFileNameWithoutExtension(path) };
            col.Add(folder);
            foreach (var dir in Directory.GetDirectories(path)) LoadFolder(dir, folder.Children);
        }
        public ICollectionView View { get => cvs.View; }
        private CollectionViewSource cvs = new CollectionViewSource();
        private ObservableCollection<TreeModel> col = new ObservableCollection<TreeModel>();
    }
```
