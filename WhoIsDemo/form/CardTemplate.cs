using System.Drawing;
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
