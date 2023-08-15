using System.Collections.ObjectModel;

namespace WpfMvvmTree
{
    public class ItemHeadModel
    {
        public ObservableCollection<ItemChildModel> ItemChilds { get; set; }
        public string Name { get; set; }
        public ItemHeadModel()
        {
            ItemChilds = new ObservableCollection<ItemChildModel>(
                new[]
                {
                    new ItemChildModel{Name="dfsdf"},
                     new ItemChildModel{Name="sdfsdf"},
                      new ItemChildModel{Name="rtrrrdf"},
                }
                );
        }
    }
}