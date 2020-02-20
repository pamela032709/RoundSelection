using System;
namespace wrap.Controls
{
    public class BookableTypeTag : TagButton
    {
        protected override void OnItemTapped()
        {
            SelectionCommand?.Execute(SelectionCommandParameter);
        }
    }
}
