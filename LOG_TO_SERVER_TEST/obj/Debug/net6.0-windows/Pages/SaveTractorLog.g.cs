﻿#pragma checksum "..\..\..\..\Pages\SaveTractorLog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B3F0B1E9917E9F87107B21920BE22104139A044"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LOG_TO_SERVER_TEST.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LOG_TO_SERVER_TEST.Pages {
    
    
    /// <summary>
    /// SaveTractorLog
    /// </summary>
    public partial class SaveTractorLog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Pages\SaveTractorLog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverHostInput;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\SaveTractorLog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox statusConnectionTbx;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\SaveTractorLog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button disconnectWsBtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\SaveTractorLog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendLogsBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LOG_TO_SERVER_TEST;component/pages/savetractorlog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SaveTractorLog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.serverHostInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\..\Pages\SaveTractorLog.xaml"
            this.serverHostInput.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.serverHostInput_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\..\Pages\SaveTractorLog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.statusConnectionTbx = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Pages\SaveTractorLog.xaml"
            this.statusConnectionTbx.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.statusConnectionTbx_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.disconnectWsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Pages\SaveTractorLog.xaml"
            this.disconnectWsBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sendLogsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Pages\SaveTractorLog.xaml"
            this.sendLogsBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 17 "..\..\..\..\Pages\SaveTractorLog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

