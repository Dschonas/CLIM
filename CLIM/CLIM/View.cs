using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIM
{
    class View
    {
        public Controller Controller { get; set; }
        public Model Model { get; set; }

        public View()
        {
            Model = new Model();
            Controller = new Controller(this.Model, this);

            Controller.InputHandler();
        }

        //every printouts
    }
}
