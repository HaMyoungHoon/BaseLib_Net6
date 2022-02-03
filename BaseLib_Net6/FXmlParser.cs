using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BaseLib_Net6
{
    /// <summary>xml parser class</summary>
    public class FXmlParser : IFParser
    {
        private string _filePath;
        /// <summary>current file path</summary>
        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        /// <summary>construct</summary>
        /// <param name="filePath">Default File Path</param>
        public FXmlParser(string filePath)
        {
            _filePath = filePath;
        }
        private bool CheckFilePath(string filePath = "")
        {
            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return false;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            FileInfo fi = new FileInfo(filePath);
            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
            if (di.Exists == false)
            {
                di.Create();
            }

            return fi.Exists;
        }
        /// <summary>create xml file</summary>
        /// <param name="cmd">node,node,node...</param>
        /// <param name="value">literally</param>
        /// <param name="filePath">null : construct path</param>
        /// <returns>false : fail</returns>
        bool IFParser.CreateFile(string cmd, string value, string filePath)
        {
            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return false;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            var node = cmd.Split(',');
            int nodeSize = node.Length;
            if (nodeSize < 1)
            {
                return false;
            }
            try
            {
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    for (int i = 0; i < nodeSize - 1; i++)
                    {
                        writer.WriteStartElement(node[i]);
                    }
                    if (nodeSize == 1)
                    {
                        writer.WriteStartElement(node[0]);
                    }
                    else
                    {
                        writer.WriteElementString(node[nodeSize - 1], value);
                    }

                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        void IFParser.SetFilePath(string filePath)
        {
            _filePath = filePath;
        }
        string IFParser.GetString(string cmd, string defValue, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return defValue;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return defValue;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return defValue;
            }

            string parseValue = "";

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return defValue;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node == null)
                    {
                        return defValue;
                    }
                    else
                    {
                        nodes = node;
                    }
                }
                parseValue = nodes.InnerText;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return defValue;
            }

            return parseValue;
        }
        int IFParser.GetInt(string cmd, int defValue, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return defValue;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return defValue;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return defValue;
            }

            string parseValue = "";

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return defValue;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node == null)
                    {
                        return defValue;
                    }
                    else
                    {
                        nodes = node;
                    }
                }
                parseValue = nodes.InnerText;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return defValue;
            }

            int.TryParse(parseValue, out int ret);
            return ret;
        }
        double IFParser.GetDouble(string cmd, double defValue, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return defValue;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return defValue;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return defValue;
            }

            string parseValue = "";

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return defValue;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node == null)
                    {
                        return defValue;
                    }
                    else
                    {
                        nodes = node;
                    }
                }
                parseValue = nodes.InnerText;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return defValue;
            }

            double.TryParse(parseValue, out double ret);
            return ret;
        }
        bool IFParser.SetString(string cmd, string value, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return false;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return false;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return false;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node != null)
                    {
                        nodes = node;
                    }
                    else
                    {
                        XmlElement elem = xmlDoc.CreateElement(temp[i]);
                        nodes.AppendChild(elem);
                        nodes = nodes[temp[i]];
                    }
                }
                nodes.InnerText = value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return false;
            }
            xmlDoc.Save(filePath);

            return true;
        }
        bool IFParser.SetInt(string cmd, int value, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return false;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return false;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return false;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node != null)
                    {
                        nodes = node;
                    }
                    else
                    {
                        XmlElement elem = xmlDoc.CreateElement(temp[i]);
                        nodes.AppendChild(elem);
                        nodes = nodes[temp[i]];
                    }
                }
                nodes.InnerText = value.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return false;
            }
            xmlDoc.Save(filePath);

            return true;
        }
        bool IFParser.SetDouble(string cmd, double value, string filePath)
        {
            if (CheckFilePath(filePath) == false)
            {
                return false;
            }

            if (_filePath.Length == 0 && filePath.Length == 0)
            {
                return false;
            }

            if (filePath.Length == 0)
            {
                filePath = _filePath;
            }

            string[] temp = cmd.Split(',');
            int tempSize = temp.Length;
            if (tempSize < 1)
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
                XmlNode nodes = xmlDoc.SelectSingleNode(temp[0]);
                if (nodes == null)
                {
                    return false;
                }
                for (int i = 1; i < temp.Length; i++)
                {
                    XmlNode node = nodes[temp[i]];
                    if (node != null)
                    {
                        nodes = node;
                    }
                    else
                    {
                        XmlElement elem = xmlDoc.CreateElement(temp[i]);
                        nodes.AppendChild(elem);
                        nodes = nodes[temp[i]];
                    }
                }
                nodes.InnerText = value.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("iniParser : " + ex.ToString());
                return false;
            }
            xmlDoc.Save(filePath);

            return true;
        }
    }
}
