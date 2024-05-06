using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSimples.Domain.DTOs.Base
{
    public abstract class DtoBase
    {
        #region ## Properties
        [Key]
        public Guid Id { get; set; }
        #endregion
    }
}
