using System;
using System.ComponentModel;
using System.Windows.Forms;
using ControlModul.Handlers.Loger;
using ControlModul.Tools;

namespace ControlModul.ProcessControl
{
    /// <summary>
    /// Allows to show and working with data table or list
    /// </summary>
    public partial class DataGridViewerControl : UserControl
    {
        [Category("Data")]
        public object DataSource 
        {
            get 
            {
                return bindingNavigator.BindingSource.DataSource;
            }
            set 
            {
                bindingNavigator.BindingSource.DataSource = value;
            }
        }

        [Category("Hide")]
        public Func<object, bool> OpenItemDelegate { get; set; }
        [Category("Hide")]
        public Func<object, bool> DeleteItemDelegate { get; set; }

        [Category("Hide")]
        public Func<bool> SaveChangesDelegate { get; set; }

        [Category("Hide")]
        public Action<object> PrintItemDelegate { get; set; }


        [DisplayName("HidenCollums"), Category("Data")]
        public string[] HidenCollums { get; set; }


        [DisplayName("AllowNew"), Category("Behavior")]
        public bool AllowNew { get; set; } = true;

        [DisplayName("AllowDelete"), Category("Behavior")]
        public bool AllowDelete { get; set; } = true;

        [DisplayName("AllowModify"), Category("Behavior")]
        public bool AllowModify { get; set; } = false;

        [DisplayName("AllowOpen"), Category("Behavior")]
        public bool AllowOpen { get; set; } = true;

        [DisplayName("AllowPreview"), Category("Behavior")]
        public bool AllowPreview { get; set; } = false;

        [DisplayName("AllowManualSourceSelect"), Category("Behavior")]
        public bool AllowManualSourceSelect { get; set; } = false;

        [Category("Hide")]
        public object SelectedItem { get; private set; }

        private Func<object> BindActionDelegate;

        public DataGridViewerControl()
        {
            InitializeComponent();
        }

        private void DataGridViewerControl_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        public void InitControl()
        {
            SetEvents();
            SetControl();
        }

        #region Base_Methods
        private void SetControl()
        {
            //New
            bindingNavigatorAddNewItem.Enabled = AllowNew;
            //Delete
            bindingNavigatorDeleteItem.Enabled = AllowDelete;
            dataGridViewObjects.AllowUserToDeleteRows = AllowDelete;
            //Modify
            dataGridViewObjects.EditMode = AllowModify ? DataGridViewEditMode.EditOnEnter : DataGridViewEditMode.EditProgrammatically;
            //Open
            bindingNavigatorEditItem.Enabled = AllowOpen = OpenItemDelegate != null;
            //Prewiev
            propertyGrid.Enabled = propertyGrid.Visible = AllowPreview;
            //Manual source select
            openSourceToolStripButton.Enabled = AllowManualSourceSelect;
            //Save
            saveToolStripButton.Enabled = SaveChangesDelegate != null;
            //Print
            printToolStripButton.Enabled = PrintItemDelegate != null;
            //Help
            //TODO
            helpToolStripButton.Enabled = false;

            //Refresh control
            this.Refresh();
        }

        private void SetEvents()
        {
            return;
        }

        /// <summary>
        /// Method for binding source by delegate method.
        /// </summary>
        /// <param name="bindActionDelegate">
        /// MUST return bindable data, support list, table or other data sources.
        /// </param>
        public void BindSources(Func<object> bindActionDelegate)
        {
            try
            {
                BindActionDelegate = bindActionDelegate;
                processWorker.RunWorker(BindMethod_GetData);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        /// <summary>
        /// Method for binding file as source .
        /// </summary>
        /// <param name="filePath">
        /// Path to source file, suppport Excel, text and other common file formats.
        /// </param>
        public void BindSources(string filePath)
        {
            try
            {
                //TODO
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        #endregion

        #region Main_Methods
        public void ResetBingindSources(params BindingSource[] bindingSources)
        {
            foreach (var source in bindingSources)
            {
                source.ResetBindings(true);
            }
        }

        private void bindingSource_Data_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewObjects.DataSource = bindingNavigator.BindingSource;
            dataGridViewObjects.Refresh();
            //Hide columns by name
            HideColumns(HidenCollums);
        }

        private void bindingSource_Data_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = bindingNavigator.BindingSource.Current;
            PreviewItem(SelectedItem);
        }

        public void FillData(object data)
        {
            bindingNavigator.BindingSource.DataSource = data;
            dataGridViewObjects.DataSource = bindingNavigator.BindingSource;

            bindingNavigator.BindingSource.ResetBindings(true);
        }

        private void AddItem(object item)
        {
            if (item == null)
            {
                return;
            }

            try
            {
                Loger.Info($"Adding {item}...");

                bindingNavigator.BindingSource.Add(item);
            }
            catch (Exception ex)
            {
                Loger.Log(ex);
            }
        }

        private void ShowItem(object item)
        {
            if (item == null)
            {
                return;
            }

            if (!OpenItemDelegate?.Invoke(item) ?? true)
            {
                Loger.Error("Chyba otevírání položky...", true);
            }
        }

        private void PreviewItem(object item)
        {
            if (item == null || !AllowPreview)
            {
                return;
            }

            propertyGrid.SelectedObject = item;
        }

        private void DeleteItem(object item, bool overdrive = false)
        {
            try
            {
                Loger.Info($"Deleting {item}...");

                if (overdrive)
                {
                    bindingNavigator.BindingSource.Remove(item);
                    DeleteItemDelegate?.Invoke(item);
                }
                else if (UserTryDeleteItem(item))
                {
                    bindingNavigator.BindingSource.Remove(item);
                    DeleteItemDelegate?.Invoke(item);
                }
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public bool UserTryDeleteItem(object item)
        {
            if (item == null) 
                return false;

            string txt = $"Opravdu smazat {item} ? Tato akce je nevratná!";
            return (MessageBox.Show(txt, "Smazat", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes);
        }
        #endregion

        #region Items_Events
        public void OpenCurrentItem_Event(object sender, EventArgs e)
        {
            try
            {
                var item = bindingNavigator.BindingSource.Current;
                ShowItem(item);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public void DeleteCurrent_Event(object sender, EventArgs e)
        {
            try
            {
                var item = bindingNavigator.BindingSource.Current;
                DeleteItem(item);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        public void RefreshItems_Event(object sender, EventArgs e)
        {
            this.ResetBingindSources(bindingNavigator.BindingSource);
        }
        #endregion

        #region DataGrid_Events
        //DataGridEvents
        private void dataGridView_OpenItemEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenCurrentItem_Event(sender, e);
        }

        private void dataGridView_UserDeletingRowEvent(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var item = bindingNavigator.BindingSource.Current;
                e.Cancel = !this.UserTryDeleteItem(item);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
        #endregion

        #region Navigator_Events
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveChangesDelegate?.Invoke();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintItemDelegate?.Invoke(SelectedItem);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            var item = bindingNavigator.BindingSource.Current;

            Manipulator.CopyObject(item);
            DeleteItem(item, true);
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            var item = bindingNavigator.BindingSource.Current;

            Manipulator.CopyObject(item);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            var item = Manipulator.PasteObject<object>();

            AddItem(item);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            return;
        }

        private void openSourceToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BindSources(openFileDialog.FileName);
            }
        }
        #endregion

        #region SearchAndFilters

        public void HideColumns(string [] collumnsNames)
        {
            if (collumnsNames == null)
                return;

            //TODO
            return;
        }

        public void Search(string searchText, string collumnName)
        {
            bindingNavigator.BindingSource.Filter = $"{collumnName} LIKE %{searchText}%";
        }

        private void toolStripTextBox_Search_TextChanged(object sender, EventArgs e)
        {
            this.Search(toolStripLabel_Search.Text, "*");
        }
        #endregion

        #region Worker_events
        private void BindMethod_GetData(DoWorkEventArgs e)
        {
            try
            {
                //Get data from method
                e.Result = BindActionDelegate?.Invoke();
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex); ;
                e.Cancel = true;
            }

        }

        private void GetWorkerResult(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.FillData(e.Result);
            }
            catch (Exception ex)
            {
                Loger.LogAndVisualize(ex);
            }
        }
        #endregion
    }
}
