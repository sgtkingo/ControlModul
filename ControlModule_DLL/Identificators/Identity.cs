using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.Identificators
{
    [Serializable]
    public abstract class Identity 
    {
        //Primary key
        [Key]
        //Generated auto-increment ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("GUID položky"), Description("Externí databázové ID položky v programu"), Category("Identifikátory")]
        public int GUID { get; protected set; }

        [MaxLength(50)]
        [DisplayName("ID položky"), Description("Interní ID položky v programu"), Category("Identifikátory")]
        public string ID { get; set; }

        [DisplayName("Datum vytvoření")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual string ToShortString()
        {
            return base.ToString();
        }
        public virtual string ToLongString()
        {
            return base.ToString();
        }
    }
}
