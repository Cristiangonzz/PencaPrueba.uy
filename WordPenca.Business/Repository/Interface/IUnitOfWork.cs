
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
        IChatRepository Chat { get; }
        IUsuarioRepository Usuario { get; }


        IChatMensajeRepository ChatMensaje { get; }

        IChatHistorialRepository ChatHistorial { get; }


        void Save();
    }
}
