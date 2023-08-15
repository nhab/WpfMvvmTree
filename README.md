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
