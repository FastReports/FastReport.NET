using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintZPL
{
    [Serializable]
    public class Config
    {
        #region Public Properties

        public string CodePage { get; set; }
        public float FontScale { get; set; }
        public string PageInit { get; set; }
        public bool PrintAsBitmap { get; set; }
        public string PrinterFinish { get; set; }
        public string PrinterFont { get; set; }
        public string PrinterInit { get; set; }

        #endregion Public Properties
    }
}
