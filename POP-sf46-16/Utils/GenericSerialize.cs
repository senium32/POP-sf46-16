using POP_sf46_16_GUI.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_sf46_16_GUI.Utils
{
    public class GenericSerialize
    {
        public static ObservableCollection<T> Deserialize<T>(string fileName) where T : class
        {

            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var sr = new StreamReader($@"../../Data/{ fileName}"))
                {
                    return (ObservableCollection<T>)serializer.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Greska prilikom uitavanja datoteke: {fileName}");
            }
           
        }

        public static void Serialize<T>(string fileName, ObservableCollection<T> listToSerialize) where T : class
        {

            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var sr = new StreamWriter($@"../../Data/{ fileName}"))
                {
                   serializer.Serialize(sr, listToSerialize);
                }


            }
            catch (Exception ex)
            {

                throw new Exception($"Greska prilikom upisa datoteke: {fileName}");
            }
        }
    }
}