﻿#pragma checksum "..\..\Enregistrement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CE2CAF5A3358100C0A88725B5BC1BB866F10D779"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using WpfApplication1;
using WpfApplication1.ViewModel;


namespace WpfApplication1 {
    
    
    /// <summary>
    /// Enregistrement
    /// </summary>
    public partial class Enregistrement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_vol;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox depart;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox destination;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock id_vol;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock desti;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock arriver;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date_depart;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date_arriver;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enregistrer;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel avion_secours;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\Enregistrement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel avion_dispo;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/enregistrement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Enregistrement.xaml"
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
            
            #line 11 "..\..\Enregistrement.xaml"
            ((WpfApplication1.Enregistrement)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Afficher_avion);
            
            #line default
            #line hidden
            return;
            case 2:
            this.date_vol = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            
            #line 51 "..\..\Enregistrement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.rechercher_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.depart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.destination = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.id_vol = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.desti = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.arriver = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.date_depart = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.date_arriver = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 150 "..\..\Enregistrement.xaml"
            ((System.Windows.Controls.Canvas)(target)).Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            return;
            case 12:
            this.enregistrer = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\Enregistrement.xaml"
            this.enregistrer.Click += new System.Windows.RoutedEventHandler(this.Enregistrer_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.avion_secours = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.avion_dispo = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

