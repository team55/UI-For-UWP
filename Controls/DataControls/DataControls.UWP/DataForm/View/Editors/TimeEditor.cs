﻿using System;
using System.Collections.Generic;
using System.Text;
using Telerik.UI.Xaml.Controls.Data.DataForm;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using Telerik.UI.Xaml.Controls.Primitives;

namespace Telerik.UI.Xaml.Controls.Data
{
    public class TimeEditor : RadTimePicker, ITypeEditor
    {
        public EditorIconDisplayMode IconDisplayMode
        {
            get { return (EditorIconDisplayMode)GetValue(IconDisplayModeProperty); }
            set { SetValue(IconDisplayModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconDisplayMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconDisplayModeProperty =
            DependencyProperty.Register(nameof(IconDisplayMode), typeof(EditorIconDisplayMode), typeof(TimeEditor), new PropertyMetadata(EditorIconDisplayMode.None));


        public Style ErrorIconStyle
        {
            get { return (Style)GetValue(ErrorIconStyleProperty); }
            set { SetValue(ErrorIconStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorIconStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorIconStyleProperty =
            DependencyProperty.Register(nameof(ErrorIconStyle), typeof(Style), typeof(TimeEditor), new PropertyMetadata(null));

        public bool HasErrors
        {
            get { return (bool)GetValue(HasErrorsProperty); }
            set { SetValue(HasErrorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasErrors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorsProperty =
            DependencyProperty.Register(nameof(HasErrors), typeof(bool), typeof(TimeEditor), new PropertyMetadata(false));

        public Style LabelIconStyle
        {
            get { return (Style)GetValue(LabelIconStyleProperty); }
            set { SetValue(LabelIconStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelIconStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelIconStyleProperty =
            DependencyProperty.Register(nameof(LabelIconStyle), typeof(Style), typeof(TimeEditor), new PropertyMetadata(null));
        
        public TimeEditor()
        {
            this.DefaultStyleKey = typeof(TimeEditor);
        }

        public void BindEditor()
        {
            Binding b = new Binding() { Mode = BindingMode.TwoWay };
            b.Path = new PropertyPath("PropertyValue");
            this.SetBinding(TimeEditor.ValueProperty, b);

            Binding b1 = new Binding();
            b1.Path = new PropertyPath("Errors.Count");
            b1.Converter = new EditorIconVisibilityConverter();
            b1.ConverterParameter = "HasErrors";
            this.SetBinding(TimeEditor.HasErrorsProperty, b1);

            Binding b2 = new Binding();
            b2.Path = new PropertyPath("Watermark");
            this.SetBinding(TimeEditor.EmptyContentProperty, b2);

            Binding b3 = new Binding();
            b3.Converter = new IsEnabledEditorConvetrer();
            b3.Path = new PropertyPath(string.Empty);
            this.SetBinding(TimeEditor.IsEnabledProperty, b3);
        }
    }
}
