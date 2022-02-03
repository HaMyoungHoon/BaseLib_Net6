using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib_Net6
{
    /// <summary>file parser class</summary>
    public class FFileParser
    {
        /// <summary>
        /// File Type
        /// </summary>
        public enum FILE_TYPE
        {
            /// <summary>.ini file</summary>
            INI = 0,
            /// <summary>.xml file</summary>
            XML = 1,
            //            /// <summary>.json file</summary>
            //            JSON = 2,
        }
        private FILE_TYPE _fileType;

        private IFParser _iniParser;
        private IFParser _xmlParser;

        /// <summary>Construct</summary>
        /// <param name="filePath">Default File Path</param>
        /// <param name="fileType">File Type</param>
        public FFileParser(string filePath, FILE_TYPE fileType)
        {
            // new는 전체 다 때릴까.
            _iniParser = new FIniParser(filePath);
            _xmlParser = new FXmlParser(filePath);
            _fileType = fileType;
        }

        /// <summary>
        /// Create Ini File
        /// </summary>
        /// <param name="section">Xml : Node, Ini : Root Key</param>
        /// <param name="value">Xml : Value, Ini : None</param>
        /// <param name="filePath">Default File Path</param>
        public void CreateFile(string section, string value, string filePath)
        {
            switch (_fileType)
            {
                case FILE_TYPE.INI: _iniParser.CreateFile(section, value, filePath); break;
                case FILE_TYPE.XML: _xmlParser.CreateFile(section, value, filePath); break;
            }
        }
        /// <summary>
        /// Re Setting File Path, File Type
        /// </summary>
        /// <param name="filePath">Default File Path</param>
        /// <param name="fileType">File Type</param>
        public void SetFilePath(string filePath, FILE_TYPE fileType)
        {
            _fileType = fileType;

            switch (_fileType)
            {
                case FILE_TYPE.INI: _iniParser.SetFilePath(filePath); break;
                case FILE_TYPE.XML: _xmlParser.SetFilePath(filePath); break;
            }
        }

        /// <summary>
        /// GetString("Section,Key");
        /// GetString("Node,ChildNode,ChildNode...");
        /// </summary>
        /// <param name="cmd">ref to summary</param>
        /// <param name="defValue">default value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>string type</returns>
        public string GetString(string cmd, string defValue, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.GetString(cmd, defValue, filePath),
                FILE_TYPE.XML => _xmlParser.GetString(cmd, defValue, filePath),
                _ => defValue
            };

        /// <summary>
        /// GetString("Section,Key");
        /// GetString("Node,ChildNode,ChildNode...");
        /// </summary>
        /// <param name="cmd">ref to summary</param>
        /// <param name="defValue">default value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>int type</returns>
        public int GetInt(string cmd, int defValue, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.GetInt(cmd, defValue, filePath),
                FILE_TYPE.XML => _xmlParser.GetInt(cmd, defValue, filePath),
                _ => defValue
            };

        /// <summary>
        /// GetString("Section,Key");
        /// GetString("Node,ChildNode,ChildNode...");
        /// </summary>
        /// <param name="cmd">ref to summary</param>
        /// <param name="defValue">default value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>double type</returns>
        public double GetDouble(string cmd, double defValue, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.GetDouble(cmd, defValue, filePath),
                FILE_TYPE.XML => _xmlParser.GetDouble(cmd, defValue, filePath),
                _ => defValue
            };

        /// <summary>
        /// SetString("Section,Key");
        /// SetString("Node,ChildNode,ChildeNode...);
        /// </summary>
        /// <param name="cmd">ref summary</param>
        /// <param name="value">setting value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>false : fail</returns>
        public bool SetString(string cmd, string value, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.SetString(cmd, value, filePath),
                FILE_TYPE.XML => _xmlParser.SetString(cmd, value, filePath),
                _ => false
            };

        /// <summary>
        /// SetString("Section,Key");
        /// SetString("Node,ChildNode,ChildeNode...);
        /// </summary>
        /// <param name="cmd">ref summary</param>
        /// <param name="value">setting value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>false : fail</returns>
        public bool SetInt(string cmd, int value, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.SetInt(cmd, value, filePath),
                FILE_TYPE.XML => _xmlParser.SetInt(cmd, value, filePath),
                _ => false
            };

        /// <summary>
        /// SetString("Section,Key");
        /// SetString("Node,ChildNode,ChildeNode...);
        /// </summary>
        /// <param name="cmd">ref summary</param>
        /// <param name="value">setting value</param>
        /// <param name="filePath">None : Construct Path</param>
        /// <returns>false : fail</returns>
        public bool SetDouble(string cmd, double value, string filePath = "") =>
            _fileType switch
            {
                FILE_TYPE.INI => _iniParser.SetDouble(cmd, value, filePath),
                FILE_TYPE.XML => _xmlParser.SetDouble(cmd, value, filePath),
                _ => false
            };
    }
}
