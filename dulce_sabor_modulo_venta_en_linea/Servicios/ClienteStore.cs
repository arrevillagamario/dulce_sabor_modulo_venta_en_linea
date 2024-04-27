using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.AspNetCore.Identity;

namespace dulce_sabor_modulo_venta_en_linea.Servicios
{
    public class ClienteStore : IUserStore<Cliente>, IUserPasswordStore<Cliente>
    {
        public ClienteStore(IRepositorioClientes repositorioClientes)
        {
            this.repositorioClientes = repositorioClientes;
        }
        private bool disposedValue;
        private readonly IRepositorioClientes repositorioClientes;

        public async Task<IdentityResult> CreateAsync(Cliente user, CancellationToken cancellationToken)
        {
            user.ClienteId = await repositorioClientes.CrearCliente(user);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Cliente user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
             return await repositorioClientes.BuscarClientePorNumeroTel(normalizedUserName);
    
        }

        public Task<string?> GetNormalizedUserNameAsync(Cliente user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Cliente user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.ClienteId.ToString());
        }

        public Task<string?> GetUserNameAsync(Cliente user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Telefono);
        }

        public Task SetNormalizedUserNameAsync(Cliente user, string? normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Cliente user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Cliente user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~ClienteStore()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public Task SetPasswordHashAsync(Cliente user, string? passwordHash, CancellationToken cancellationToken)
        {
            user.Contraseña = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string?> GetPasswordHashAsync(Cliente user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Contraseña);
        }

        public Task<bool> HasPasswordAsync(Cliente user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
