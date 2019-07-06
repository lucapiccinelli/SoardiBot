namespace SoardiBotService
{
    partial class ProjectInstaller
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
            this.SoardiBotProjectInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SoardiBotServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SoardiBotProjectInstaller
            // 
            this.SoardiBotProjectInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.SoardiBotProjectInstaller.Password = null;
            this.SoardiBotProjectInstaller.Username = null;
            // 
            // SoardiBotServiceInstaller
            // 
            this.SoardiBotServiceInstaller.ServiceName = "SoardiBotService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SoardiBotProjectInstaller,
            this.SoardiBotServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SoardiBotProjectInstaller;
        private System.ServiceProcess.ServiceInstaller SoardiBotServiceInstaller;
    }
}