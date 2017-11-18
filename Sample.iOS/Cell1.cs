using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Sample.iOS
{
    public class Cell1:CellTableViewCell
    {
        public Cell1(Cell cell):base(UIKit.UITableViewCellStyle.Default, cell.GetType().FullName)
        {
        }
    }
}
