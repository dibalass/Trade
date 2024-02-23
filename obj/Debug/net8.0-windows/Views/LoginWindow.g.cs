﻿#pragma checksum "..\..\..\..\Views\LoginWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C3B3D695349325C014B35D9045F128C8043858D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Trade;


namespace Trade {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginInput;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordInput;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordInputHidden;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showPasswordCheckbox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock passwordInputVisible;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel captchaContainer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock captchaFirstBlock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock captchaSecondBlock;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox captchaInput;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button guestButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Trade;component/views/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\LoginWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.passwordInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordInputHidden = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.showPasswordCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 36 "..\..\..\..\Views\LoginWindow.xaml"
            this.showPasswordCheckbox.Checked += new System.Windows.RoutedEventHandler(this.ShowPassword_Checked);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\Views\LoginWindow.xaml"
            this.showPasswordCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.ShowPassword_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passwordInputVisible = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.captchaContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.captchaFirstBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.captchaSecondBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.captchaInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Views\LoginWindow.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.loginButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.guestButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Views\LoginWindow.xaml"
            this.guestButton.Click += new System.Windows.RoutedEventHandler(this.guestButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

