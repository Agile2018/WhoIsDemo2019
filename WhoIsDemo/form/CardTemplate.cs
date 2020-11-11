using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIsDemo.form
{
    public partial class CardTemplate : UserControl
    {
        #region variables
        
        private Image photoTemplate;

        #endregion

        public Image PhotoTemplate
        {
            get
            {
                return photoTemplate;
            }

            set
            {
                photoTemplate = value;
                picTemplate.Image = value;
            }
        }
        public CardTemplate()
        {
            InitializeComponent();
        }
    }
}
