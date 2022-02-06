using System.Threading.Tasks;
using API.DTOs;

namespace API.Services.Abstract
{
    public interface IKiranicoClient
    {
        Task<MonsterDto> GetMonster(int id);
    }
}