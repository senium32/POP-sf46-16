﻿#pragma checksum "..\..\..\GUI\DodajDodatakWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BE258BC03B3704109C79A638BA63D62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_sf46_16_GUI.GUI;
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


namespace POP_sf46_16_GUI.GUI {
    
    
    /// <summary>
    /// DodajDodatakWindow
    /// </summary>
    public partial class DodajDodatakWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNaziv;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCena;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCena;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\GUI\DodajDodatakWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzlaz;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-sf46-16-GUI;component/gui/dodajdodatakwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\DodajDodatakWindow.xaml"
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
            this.lblNaziv = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblCena = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbCena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\GUI\DodajDodatakWindow.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\GUI\DodajDodatakWindow.xaml"
            this.btnIzlaz.Click += new System.Windows.RoutedEventHandler(this.btnIzlaz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

