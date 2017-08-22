using System;
using System.Collections.Generic;
using lib12.Collections;
using lib12.Extensions;

namespace lib12.Serialization
{
    [Serializable]
    public class SerializationHelper
    {
        #region Events
        [field: NonSerialized]
        public event EventHandler<SerializationStartedEventArgs> SerializationStarted;
        #endregion

        #region Fields
        private Serializer serializer;
        #endregion

        #region Props
        private static SerializationHelper current;
        public static SerializationHelper Current
        {
            get
            {
                return current ?? (current = new SerializationHelper());
            }
        }

        public bool DataLoaded { get; private set; }
        public Dictionary<string, object> Data { get; set; }
        #endregion

        #region Start
        private SerializationHelper()
        {
            serializer = new Serializer();
            Data = new Dictionary<string, object>();
            DataLoaded = false;
        }
        #endregion

        #region Save
        public void Save(string path)
        {
            var eventArgs = new SerializationStartedEventArgs();
            SerializationStarted.Raise<SerializationStartedEventArgs>(this, eventArgs);
            serializer.Save(path, eventArgs.Data);
        }
        #endregion

        #region Load
        public void Load(string path)
        {
            Data = (Dictionary<string, object>)serializer.Load(path);
            DataLoaded = true;
        }
        #endregion

        #region Get
        public object Get(string key)
        {
            if (!DataLoaded)
                return null;

            return Data.GetValueOrDefault(key);
        }

        public T Get<T>(string key)
        {
            if (!DataLoaded)
                return default(T);

            return (T)Data.GetValueOrDefault(key);
        }
        #endregion
    }
}
