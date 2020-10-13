using System;
using System.Windows.Forms;

namespace FirstSimpleExtension
{
    public partial class BleepaUsingsSortControl : UserControl
    {
        internal BleepaSortUsingsOnSaveOption BleepaSortUsingsOnSaveOptionPage;
        public BleepaUsingsSortControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            SortUsingsCheckbox.Checked = BleepaSortUsingsOnSaveOptionPage.SortUsingsOnSave;
        }

        private void BleepaUsingsSortControl_Load(object sender, EventArgs e)
        {

        }

        private void SortUsings_Leave(object sender, EventArgs e)
        {
            
        }

        private void BleepaUsingsSortControl_Leave(object sender, EventArgs e)
        {
            BleepaSortUsingsOnSaveOptionPage.SortUsingsOnSave = SortUsingsCheckbox.Checked;
        }

        private void SortUsingsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            BleepaSortUsingsOnSaveOptionPage.SortUsingsOnSave = SortUsingsCheckbox.Checked;
        }
    }
}
