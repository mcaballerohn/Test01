﻿#pragma checksum "C:\Users\rcastellanos\Documents\Visual Studio 2012\Projects\ProyectoN-Capas\Silverlight.BoundedContext\Templates\PlantaTemplate.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "259F5E568362372B40F7E3D91D364204"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Silverlight.BoundedContext.Templates {
    
    
    public partial class PlantaTemplate : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock PlantaId;
        
        internal System.Windows.Controls.TextBlock NombrePlanta;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Silverlight.BoundedContext;component/Templates/PlantaTemplate.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PlantaId = ((System.Windows.Controls.TextBlock)(this.FindName("PlantaId")));
            this.NombrePlanta = ((System.Windows.Controls.TextBlock)(this.FindName("NombrePlanta")));
        }
    }
}
