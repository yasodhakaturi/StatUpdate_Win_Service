namespace StatsUpdate_win_Service
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
            this.StatsUpdate_win_Service = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_StatsUpdate_win_Service = new System.ServiceProcess.ServiceInstaller();
            // 
            // StatsUpdate_win_Service
            // 
            this.StatsUpdate_win_Service.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.StatsUpdate_win_Service.Password = null;
            this.StatsUpdate_win_Service.Username = null;
            this.StatsUpdate_win_Service.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller_StatsUpdate_win_Service_AfterInstall);
            // 
            // serviceInstaller_StatsUpdate_win_Service
            // 
            this.serviceInstaller_StatsUpdate_win_Service.DisplayName = "MySqlStatsUpdate_win_Service";
            this.serviceInstaller_StatsUpdate_win_Service.ServiceName = "MySqlStatsUpdate_win_Service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.StatsUpdate_win_Service,
            this.serviceInstaller_StatsUpdate_win_Service});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller StatsUpdate_win_Service;
        private System.ServiceProcess.ServiceInstaller serviceInstaller_StatsUpdate_win_Service;
    }
}