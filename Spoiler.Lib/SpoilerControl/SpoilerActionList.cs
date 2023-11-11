using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoiler.SpoilerControl
{
    public class SpoilerActionList : DesignerActionList
    {
        public SpoilerActionList(IComponent component) : base(component)
        {
        }
    }
}
