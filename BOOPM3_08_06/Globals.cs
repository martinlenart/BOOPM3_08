using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOPM3_08_06
{
    public class Globals
    {
        #region Singleton implementation
        static Globals _singleton = null;

        public static Globals GetSingleton()
        {
            if (_singleton == null)
            {
                _singleton = new Globals();
            }
            return _singleton;
        }
        //Private contructor to avoid any direct instantiations
        Globals() { }
        #endregion

        #region Immediate Singleton Data
        
        //Accessible immediatly through the singleton
        public string config1 = "Some Config Data Available now";

        #endregion

        #region Lazy Loading Data

        // accessible as Globals.GetSingleton().Data.HugeDecimalArray
        public class LazyLoading
        {
            public decimal[] HugeDecimalArray = new decimal[10_000_000];
        }
        
        private Lazy<LazyLoading> _lazy = new Lazy<LazyLoading>(() => new LazyLoading());

        public decimal[] Data => _lazy.Value.HugeDecimalArray;
        #endregion
    }
}
