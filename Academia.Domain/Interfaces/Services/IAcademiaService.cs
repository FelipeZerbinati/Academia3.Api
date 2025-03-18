using acdm = Academia2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia2.Domain.DTO;

namespace Academia2.Domain.Interfaces.Services
{
    public interface IAcademiaService
    {
        Task <ResultData<acdm.Academia2>> AddAcademia(acdm.Academia2 academia2);
        Task<ResultData<acdm.Academia2>> UpdateAcademia(Guid id, acdm.Academia2 academia2);
        Task<ResultData<List<acdm.Academia2>>> GetAcademias();
        Task<ResultData<acdm.Academia2>> GetAcademiaById(Guid id);
        Task<ResultData<bool>> DeleteAcademia(Guid id);
    }
}
