using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class View
    {
        private Controller controller;
        private Model model;

        internal Controller Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
            }
        }

        internal Model Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public View()
        {
            Model = new Model();
            Controller = new Controller(this.Model, this);

            Controller.InputHandler();
        }

        //every printouts
    }
}
