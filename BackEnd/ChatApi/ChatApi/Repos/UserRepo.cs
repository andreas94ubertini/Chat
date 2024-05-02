using ChatApi.DTO;
using ChatApi.Models;

namespace ChatApi.Repos
{
    public class UserRepo : IRepo<Utenti>
    {
        #region Injection
        private readonly ILogger _logger;
        private readonly ChatUsersContext _context;
      

        public UserRepo(ChatUsersContext context, ILogger<UserRepo> logger)
        {
            this._logger = logger;
            _context = context;
        }
        #endregion
        public bool Create(Utenti entity)
        {
            try
            {
                _context.Utentis.Add(entity);
                _context.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
            }
            return false;
        }

        public bool Delete(string codice)
        {
            Utenti? u = GetByCod(codice);
            if (u != null)
            {
                u.IsDeleted = true;
                try
                {
                    _context.Utentis.Update(u);
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);

                }
                return false;
            }
            return false;
        }

        public IEnumerable<Utenti> GetAll()
        {
           return _context.Utentis.ToList();
        }

        public Utenti? GetByCod(string codice)
        {
            return _context.Utentis.FirstOrDefault(u => u.Codice == codice);
        }

        public bool Update(Utenti entity)
        {
            try
            {
                _context.Utentis.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return false;
        }

        public Utenti? CheckLogin(UserLoginModel obj)
        {

            Utenti? temp = _context.Utentis.FirstOrDefault(p => p.Username == obj.Username && p.Psw == obj.Password);
            return temp;
        }

        public Utenti? GetByUsername(string username)
        {
            return _context.Utentis.FirstOrDefault(u => u.Username == username);
        }

    }
}
