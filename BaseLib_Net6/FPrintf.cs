using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseLib_Net6
{
    /// <summary>class for Log</summary>
    public class FPrintf
    {
        /// <summary>delegate for Callback Function</summary>
        /// <param name="data">Log Data</param>
        public delegate void PrintCallbackFunc(char[] data);

        /// <summary>Log Path</summary>
        public string _filePath { get; private set; }
        /// <summary>Log File Name</summary>
        public string _fileName { get; private set; }
        /// <summary>Log delete Date</summary>
        public uint _expiryDate { get; private set; }
        /// <summary>refer eMODE</summary>
        public eMODE _saveMode { get; private set; }

        /// <summary>Save Mode</summary>
        public enum eMODE
        {
            /// <summary>_filePath -> _fileName_yyyy-MM-dd</summary>
            SORT_DATETIME_FILE = 0,
            /// <summary>_filePath -> yyyy-MM-dd -> _fileName</summary>
            SORT_DATETIME_FOLDER,
        }

        private bool _notUse;
        private PrintCallbackFunc _printCallbackFunc;

        /// <summary>Class generator</summary>
        /// <param name="filePath">log path</param>
        /// <param name="fileName">log file Name</param>
        /// <param name="saveMode">save mode</param>
        /// <param name="printCallbackFunc">set callback function</param>
        /// <param name="expiryDate">delete file</param>
        public FPrintf(string filePath, string fileName, eMODE saveMode = eMODE.SORT_DATETIME_FILE, PrintCallbackFunc printCallbackFunc = null, uint expiryDate = 60)
        {
            this._filePath = filePath;
            this._fileName = fileName;
            this._saveMode = saveMode;

            this._notUse = false;
            this._printCallbackFunc = printCallbackFunc;

            this._expiryDate = expiryDate;
        }
        /// <summary>Class destructor</summary>
        ~FPrintf()
        {

        }
        /// <summary>can use config setting</summary>
        /// <param name="data"></param>
        public void NotUsePrintf(bool data = true)
        {
            _notUse = data;
        }
        private void DeleteFolder()
        {
            if (new DirectoryInfo(_filePath).Exists)
            {
                DirectoryInfo di;
                DateTime lowerFolder;
                DateTime expirydate = DateTime.Now.AddDays(-_expiryDate);
                string[] dir = Directory.GetDirectories(_filePath, "*", SearchOption.TopDirectoryOnly);
                switch (_saveMode)
                {
                    case eMODE.SORT_DATETIME_FILE:
                        {
                            int parseDir;
                            for (int i = 0; i < dir.Length; i++)
                            {
                                if (int.TryParse(dir[i].Remove(0, dir[i].LastIndexOf('\\') + 1), out parseDir))
                                {
                                    lowerFolder = new DateTime(parseDir / 100, parseDir % 100, 1);
                                    if (expirydate.Ticks - lowerFolder.Ticks >= 0)
                                    {
                                        di = new DirectoryInfo(string.Format(@"{0}\{1}", _filePath, lowerFolder.ToString("yyyyMM")));
                                        if (di.Exists)
                                        {
                                            di.Delete(true);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case eMODE.SORT_DATETIME_FOLDER:
                        {
                            Regex rx = new Regex(@"\d{1,4}-\d{1,2}-\d{1,2}");
                            for (int i = 0; i < dir.Length; i++)
                            {
                                if (rx.IsMatch(dir[i].Remove(0, dir[i].LastIndexOf('\\') + 1)))
                                {
                                    DateTime.TryParse(dir[i].Remove(0, dir[i].LastIndexOf('\\') + 1), out lowerFolder);
                                    if (expirydate.Ticks - lowerFolder.Ticks >= 0)
                                    {
                                        di = new DirectoryInfo(string.Format(@"{0}\{1}", _filePath, lowerFolder.ToString("yyyy-MM-dd")));
                                        if (di.Exists)
                                        {
                                            di.Delete(true);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        private void WriteFile(string data)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            DirectoryInfo di;
            FileInfo fi;
            var yyyymmdd = DateTime.Now;
            switch (_saveMode)
            {
                case eMODE.SORT_DATETIME_FILE:
                    {
                        di = new DirectoryInfo(string.Format(@"{0}\{1}", _filePath, yyyymmdd.ToString("yyyyMM")));
                        fi = new FileInfo(string.Format(@"{0}\{1}\{2}_{3}.log", _filePath, yyyymmdd.ToString("yyyyMM"), _fileName, yyyymmdd.ToString("yyyyMMdd")));
                    }
                    break;
                case eMODE.SORT_DATETIME_FOLDER:
                    {
                        di = new DirectoryInfo(string.Format(@"{0}\{1}", _filePath, yyyymmdd.ToString("yyyy-MM-dd")));
                        fi = new FileInfo(string.Format(@"{0}\{1}\{2}.log", _filePath, yyyymmdd.ToString("yyyy-MM-dd"), _fileName));
                    }
                    break;
                default: return;
            }
            if (di.Exists == false)
            {
                di.Create();
            }
            if (fi.Exists)
            {
                using (StreamWriter sw = File.AppendText(fi.FullName))
                {
                    sw.WriteLine(string.Format("[{0}]   {1}", yyyymmdd.ToString("yyyy-MM-dd tt hh:mm:ss", culture), data));
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(fi.FullName))
                {
                    sw.WriteLine(string.Format("[{0}]   {1}", yyyymmdd.ToString("yyyy-MM-dd tt hh:mm:ss", culture), data));
                    sw.Close();
                }
            }
        }
        /// <summary>Save Log</summary>
        /// <param name="data">formated string</param>
        /// <param name="ps">params</param>
        public void PRINT_F(string data, params object[] ps)
        {
            string log = "";
            // 잘못 했으면 터져야지.
//            try
//            {
                log = string.Format(data, ps);
//            }
//            catch (Exception ex)
//            {
//                log = ex.ToString();
//            }
            PRINT_F(log.ToCharArray());
        }
        /// <summary>Save Log</summary>
        /// <param name="data">string type data</param>
        public void PRINT_F(string data)
        {
            PRINT_F(data.ToCharArray());
        }
        /// <summary>Save Log</summary>
        /// <param name="data">char array type data</param>
        public void PRINT_F(char[] data)
        {
            if (_notUse == true)
            {
                return;
            }

            if (_expiryDate != 0)
            {
                try
                {
                    DeleteFolder();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("printf : " + ex.ToString());
                }
            }
            try
            {
                WriteFile(new string(data));
            }
            catch(Exception ex)
            {
                Debug.WriteLine("printf : " + ex.ToString());
            }
            if (_printCallbackFunc != null)
            {
                _printCallbackFunc(data);
            }
        }
    }
}
