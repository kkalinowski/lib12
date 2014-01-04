using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lib12.Serialization
{
    public class Serializer
    {
        #region Fields
        private readonly BinaryFormatter formatter;
        #endregion

        #region ctor
        public Serializer()
        {
            formatter = new BinaryFormatter();
        } 
        #endregion

        #region Logic
        public void Save(string path, object toSerialize)
        {
            using (var file = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(file, toSerialize);
            }
        }

        public object Load(string path)
        {
            if (!File.Exists(path))
                return null;

            object deserialized = null;
            FileStream file = null;
            try
            {
                file = new FileStream(path, FileMode.Open);
                deserialized = formatter.Deserialize(file);
            }
            catch
            {
                if (file != null)
                    file.Close();
                File.Delete(path);
            }

            return deserialized;
        } 
        #endregion
    }
}
