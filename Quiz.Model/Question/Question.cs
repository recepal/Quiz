using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    [Table("questions", Schema = "que")]
    public class Question : EntityBase
    {
        public string Description { get; set; }
    }
}
