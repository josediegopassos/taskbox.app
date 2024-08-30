using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TEntity>
            where TEntity : BaseEntity
    {
    }
}
