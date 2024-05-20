
namespace WordPenca.Business.Repository.Interface
{
    public interface IUnitOfWork
    {
        //IApplicationUserRepository ApplicationUser { get; }
        IPencaRepository Penca { get; }
        ICampeonatoRepository Campeonato { get; }
        IPartidoRepository Partido { get; }
        IEquipoRepository Equipo { get; }
        ITablaRepository Tabla { get; }
        IClasificacionRepository Clasificacion { get; }
        IUsuarioRepository Usuario { get; }

        void Save();
    }
}
