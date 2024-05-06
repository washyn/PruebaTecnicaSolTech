using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Encryption;
using Washyn.TechTest.Entities;
using Washyn.TechTest.Repositories;
using Washyn.TechTest.Services.Dto;

namespace Washyn.TechTest.Services;

[Authorize]
public class UsuarioAppService : CrudAppService<Usuario,UsuarioDto, Guid,PagedAndSortedResultRequestDto,UsuarioCreateDto, UsuarioUpdateDto>
{
    private readonly IStringEncryptionService _encryptionService;

    public UsuarioAppService(IUsuarioRepository repository, IStringEncryptionService encryptionService) : base(repository)
    {
        _encryptionService = encryptionService;
    }

    /// <summary>
    /// Servicio para listar usuario(incluye paginacion y ordenado).
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override Task<PagedResultDto<UsuarioDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return base.GetListAsync(input);
    }

    public override async Task<UsuarioDto> CreateAsync(UsuarioCreateDto input)
    {
        var user = ObjectMapper.Map<UsuarioCreateDto, Usuario>(input);
        user.Password = _encryptionService.Encrypt(input.Password)!;
        var result = await Repository.InsertAsync(user);
        return ObjectMapper.Map<Usuario, UsuarioDto>(result);
    }
}