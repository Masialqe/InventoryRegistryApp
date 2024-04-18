using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR.Domain.Models.Interfaces
{
    public interface IModelBase
    {
        Guid Id { get; }
        DateOnly Created { get; }
    }
}
