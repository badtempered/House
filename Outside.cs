using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Outside : Location
    {
        public Outside(string name, bool hot) : base(name)
        {
            this.hot = hot;
        }
        bool hot;
        public override string Description
        {
            get
            {
                if (hot == true)
                {
                    return base.Description + " It's very hot here.";
                }
                return base.Description;
            }
        }
    }
}
