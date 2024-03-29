﻿using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace Wireguard_FrontEnd
{
    /// <summary> Microsoft.NET.Sdk
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProfileDetector _addToItem = new(); 
        private readonly ArrayList ActiveScripts = new();

        public string? Sent { private get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ConfAddItems();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            foreach (string s in ActiveScripts)
                File.Delete(s);
            base.OnClosing(e);
        }

        private void ConfFileComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sent = ConfFileComboBox.Items[ConfFileComboBox.SelectedIndex].ToString();
            StartTunnel.IsEnabled = Sent != null;
            StopTunnel.IsEnabled = Sent != null;
        }

        private void ConfAddItems()
        {
            foreach (var t in _addToItem.FilesListed())
                ConfFileComboBox.Items.Add(t);
            ConfFileComboBox.SelectedIndex = 0;
        }

        private void Start_Tunnel_Click(object sender, RoutedEventArgs e)
        {
            if(Sent != null)
            {
                OnandOffWG wG = new(Sent);
                wG.CreateConnectScript();
                CommandLine.RunCMD("powershell -Command \"Start-Process powershell -Verb runAs -ArgumentList '-ExecutionPolicy','Bypass','-noexit','-file','" + wG.OnFile + "'\"");
                ActiveScripts.Add(wG.OnFile);
            }
        }

        private void StopTunnel_Click(object sender, RoutedEventArgs e)
        {
            if (Sent != null)
            {
                OnandOffWG wG = new(Sent);
                wG.CreateDisconnectScript();
                CommandLine.RunCMD("powershell -Command \"Start-Process powershell -Verb runAs -ArgumentList '-ExecutionPolicy', 'Bypass', '-noexit', '-file', ' " + wG.OffFile +  " '\"");
                ActiveScripts.Add(wG.OffFile);
            }
        }
    }
}