﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HidWizards.UCR.Core.Models;

namespace HidWizards.UCR.Views.Controls
{
    public partial class PluginView : UserControl
    {

        public PluginView()
        {
            InitializeComponent();
        }

        private void RemovePlugin_OnClick(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            var plugin = button.DataContext as Plugin;
            plugin?.Remove();
            var containingListbox = FindAncestor<ListBox>(sender as DependencyObject);
            containingListbox.Items.Refresh();
        }

        public static T FindAncestor<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }
    }
}
