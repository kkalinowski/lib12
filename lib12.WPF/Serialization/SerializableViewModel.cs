using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lib12.Collections;
using lib12.Extensions;
using lib12.Serialization;
using lib12.WPF.Core;

namespace lib12.WPF.Serialization
{
    public abstract class SerializableViewModel : NotifyingObject
    {
        #region Fields
        private readonly string serializationKey;
        #endregion

        #region ctor
        public SerializableViewModel()
        {
            serializationKey = GetType().Name;
            SerializationHelper.Current.SerializationStarted += SerializationHelper_SerializationStarted;
            Deserialize();
        }
        #endregion

        #region Serialize
        private void SerializationHelper_SerializationStarted(object sender, SerializationStartedEventArgs e)
        {
            var dict = GetProperties().ToDictionary(x => x.Name, x => x.GetValue(this, null));
            e.Data.Add(serializationKey, dict);
        }
        #endregion

        #region Deserialize
        public void Deserialize()
        {
            var props = GetProperties();
            var data = SerializationHelper.Current.Get<Dictionary<string, object>>(serializationKey);
            if (data == null)
            {
                props.ForEach(x => AssingDefaultValue(x));
                return;
            }

            foreach (var prop in props)
            {
                var value = data.GetValueOrDefault(prop.Name);
                if (value != null)
                {
                    try
                    {
                        prop.SetValue(this, value, null);
                    }
                    catch
                    {
                        AssingDefaultValue(prop);
                    }
                }
                else
                {
                    AssingDefaultValue(prop);
                }
            }
        }
        #endregion

        #region Logic
        private PropertyInfo[] GetProperties()
        {
            return GetType().GetProperties()
                    .Where(x => x.GetAttribute<SerializePropertyAttribute>() != null)
                    .ToArray();
        }

        public void AssingDefaultValue(PropertyInfo prop)
        {
            var attrib = prop.GetAttribute<SerializePropertyAttribute>();
            if (attrib.CreateNewAsDefaultValue)
                prop.SetValue(this, Activator.CreateInstance(prop.PropertyType), null);
            else if (attrib.DefaultValue != null)
                prop.SetValue(this, attrib.DefaultValue, null);
        }
        #endregion
    }
}
