using DesignRSC.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignRSC.ViewModel
{
    public class MeniPage
    {
        private List<MeniItem> _lista = new List<MeniItem>();
        public MeniPage()
        {

        }

        public List<MeniItem> lista
        {
            get
            {
                for (int i = 0; i < 2; i++)
                {
                    MeniItem j = new MeniItem();
                    _lista.Add(j);
                }
                return _lista;
            }
        }
    }
}
