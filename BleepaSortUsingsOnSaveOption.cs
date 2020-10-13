using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace FirstSimpleExtension
{
    [Guid("00000000-0000-0000-0000-000000000000")]
    class BleepaSortUsingsOnSaveOption : DialogPage
    {
        [Category()]
        [DisplayName("Sort Bleepa project usings on save")]
        [Description("Sorts Bleepa project usings on document save")]
        public bool SortUsingsOnSave { get; set; } = true;

        protected override IWin32Window Window
        {
            get
            {
                BleepaUsingsSortControl page = new BleepaUsingsSortControl();
                page.BleepaSortUsingsOnSaveOptionPage = this;
                page.Initialize();
                return page;
            }
        }
    }
}
