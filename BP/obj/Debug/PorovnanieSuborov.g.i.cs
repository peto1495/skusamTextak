﻿#pragma checksum "..\..\PorovnanieSuborov.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D4F2F3B8EDF1E1BE4EC79450E3B508A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace BP {
    
    
    /// <summary>
    /// PorovnanieSuborov
    /// </summary>
    public partial class PorovnanieSuborov : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Sub1TextBox;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Sub2TextBox;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sub1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sub2;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NacitajSubory;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerujDocXButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PorovnanieSuborov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock bla;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BP;component/porovnaniesuborov.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PorovnanieSuborov.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\PorovnanieSuborov.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.nastavButton);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Sub1TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Sub2TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Sub1 = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\PorovnanieSuborov.xaml"
            this.Sub1.Click += new System.Windows.RoutedEventHandler(this.DajNazov_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Sub2 = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PorovnanieSuborov.xaml"
            this.Sub2.Click += new System.Windows.RoutedEventHandler(this.DajNazov_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NacitajSubory = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\PorovnanieSuborov.xaml"
            this.NacitajSubory.Click += new System.Windows.RoutedEventHandler(this.NacitajSubory_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GenerujDocXButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\PorovnanieSuborov.xaml"
            this.GenerujDocXButton.Click += new System.Windows.RoutedEventHandler(this.GenerujDocXButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bla = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

