using System;
using System.IO;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ControlModul.Handlers.Loger;
using System.Xml;
using System.Xml.Serialization;

namespace ControlModul.FileControl
{
    /// <summary>
    /// Static class that represented simple file serializer 
    /// </summary>
    /// <remarks>
    /// Serialize and Deserialize files by different methods
    /// 
    /// - Possiblity to use binary or XML formating, JSON will be added soon
    /// </remarks>
    public static class FileSerializer
    {
        [SecurityPermissionAttribute(SecurityAction.PermitOnly, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public static void AllowSerializationPermission(){
            Loger.Info("Serialization Permission: PermitOnly!");
            TestPermission(new SecurityPermission(SecurityPermissionFlag.SerializationFormatter));
        }

        public static void TestPermission(SecurityPermission permission){
            try
            {
                //If demand fail, then throw Exception
                permission.Demand();
                Loger.Info($"Permission {permission.ToString()} demand status: OK!");
            }
            catch (Exception e) {
                Loger.LogAndVisualize(e);
            }
        }
        //Using simples class with IFormatter interface
        public static void SerializeItemAsBinaryFile<T>(T serializableObject, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    formatter.Serialize(fs, serializableObject);
                }
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
            }
        }
        public static string SerializeItemAsXML<T>(T serializableObject)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);

                    return xmlDocument.OuterXml;
                }
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
                return null;
            }
        }

        public static T DeserializeItemFromBinaryFile<T>(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();

            //Set T t to default value of type
            T t = default(T);

            try
            {
                using (FileStream s = new FileStream(fileName, FileMode.Open))
                {
                    t = (T)formatter.Deserialize(s);
                }
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
            }
            return t;
        }

        public static T DeserializeItemAsXML<T>(string xmlString)
        {
            T objectOut = default(T);
            try
            {
                using (StringReader read = new StringReader(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception e)
            {
                Loger.LogAndVisualize(e);
            }
            return objectOut;
        }
    }
    }
