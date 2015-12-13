namespace _S_ServiceProjectName_S_.Module
{
    partial class _S_ShortProductName_S_WindowsService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._serviceController = new System.ServiceProcess.ServiceController();
            // 
            // _serviceController
            // 
            this._serviceController.ServiceName = "_S_ShortProductName_S_WindowsService";
            // 
            // _S_ShortProductName_S_WindowsService
            // 
            this.ServiceName = "_S_ShortProductName_S_WindowsService";

        }

        #endregion

        private System.ServiceProcess.ServiceController _serviceController;
    }
}
