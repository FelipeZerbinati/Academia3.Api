using Academia2.Domain.DTO;
using Academia2.Domain.Interfaces.Repository;
using Academia2.Domain.Interfaces.Services;
using acdm = Academia2.Domain.Models;

namespace Academia2.Application.Services;

public class AcademiaService(IUnitOfWork unitOfWork) : IAcademiaService
{
    public async Task<ResultData<acdm.Academia2>> AddAcademia(acdm.Academia2 academia2)
    {
        var result = new ResultData<acdm.Academia2>();
        try
        {
            var id = unitOfWork.Academia2Repository.Insert(academia2);
            academia2.Id = id;
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = academia2;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = ex.Message;
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = null;
            }
        }
        return result;

    }

    public async Task<ResultData<bool>> DeleteAcademia(Guid id)
    {
        var result = new ResultData<bool>();
        try
        {
            var academia = await unitOfWork.Academia2Repository.GetAsync(false, null, a => a.Id == id);
            unitOfWork.Academia2Repository.Delete(academia);
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = ex.Message;

        }
        finally
        {
            if (!result.Success)
            {
                result.Data = false;
            }
        }
        return result;
    }

    public async Task<ResultData<acdm.Academia2>> GetAcademiaById(Guid id)
    {
        var result = new ResultData<acdm.Academia2>();
        try
        {
            var academia = await unitOfWork.Academia2Repository.GetByIdAsync(id);
            result.Success = true;
            result.Data = academia;
        }
        catch (Exception ex)
        {

            result.Success = false;
            result.ErrorDescription = ex.Message;

        }
        finally
        {
            if (!result.Success)
            {
                result.Data = new acdm.Academia2();
            }
        }
        return result;

    }

    public async Task<ResultData<List<acdm.Academia2>>> GetAcademias()
    {
        var result = new ResultData<List<acdm.Academia2>>();
        try
        {
            var academias = await unitOfWork.Academia2Repository.GetAllAsync();
            result.Success = true;
            result.Data = academias;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = ex.Message;
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = new List<acdm.Academia2>();
            }
        }
        return result;
    }

    public async Task<ResultData<acdm.Academia2>> UpdateAcademia(Guid id, acdm.Academia2 updatedAcademia2)
    {
        var result = new ResultData<acdm.Academia2>();
        try
        {
            var academia = await unitOfWork.Academia2Repository.GetAsync(false, null, a => a.Id == id);
            if (academia == null)
            {
                result.Success = false;
                result.ErrorDescription = "Gym does not exist.";
                return result;
            }
            academia.Nome = updatedAcademia2.Nome;
            unitOfWork.Academia2Repository.Update(academia);
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = academia;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = ex.Message;
        }
        finally
        {
            if (!result.Success)
            {
                result.Success = false;
            }
        }
        return result;
    }
}

