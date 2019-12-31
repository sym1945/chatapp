using System;
using System.Windows;

namespace chatapp
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value"
                , typeof(Property)
                , typeof(BaseAttachedProperty<Parent, Property>)
                , new UIPropertyMetadata(
                    default(Property)
                    , new PropertyChangedCallback(OnValuePropertyChanged)
                    , new CoerceValueCallback(OnValuePropertyUpdated)
                )
            );

        /// <summary>
        /// <see cref="ValueProperty"/>가 변경됐을 때 콜백되는 이벤트
        /// </summary>
        /// <param name="d">Value Property를 갖고있는 UI 엘레먼트</param>
        /// <param name="e">이벤트 아규먼트</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Parent function 호출
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            // 이벤트 리스터 호출
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Parent function 호출
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            // 이벤트 리스터 호출
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);


        #endregion

        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }

}
