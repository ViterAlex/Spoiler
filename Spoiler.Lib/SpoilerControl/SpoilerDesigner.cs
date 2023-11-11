using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Spoiler.SpoilerControl
{
    public class SpoilerDesigner : ParentControlDesigner
    {
        private DesignerActionListCollection actions;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actions == null)
                {
                    actions = new DesignerActionListCollection
                    {
                        new SpoilerActionList(Component)
                    };
                }
                return actions;
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties.Remove(nameof(Panel.AutoSize));
            properties.Remove(nameof(Panel.AutoSizeMode));
        }
    }
}
