using System;
using profile.Models;
using profile.UnitOfWork;

namespace profile.Models
{
    public class UnitOfWork : IDisposable
    {
        private Storecontext _context = new Storecontext();
        private GenericRepository<User> _userRepository;
        private GenericRepository<BlogPost> _blogRepository;


        public UnitOfWork()
        {
        }

   
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }


        public GenericRepository<BlogPost> blogRepository
        {
            get
            {

                if (this._blogRepository == null)
                {
                    this._blogRepository = new GenericRepository<BlogPost>(_context);
                }
                return _blogRepository;
            }
        }


        //public GenericRepository<Crypto> CryptoRepository
        //{
        //    get
        //    {

        //        if (this.cryptoRepository == null)
        //        {
        //            this.cryptoRepository = new GenericRepository<Crypto>(context);
        //        }
        //        return cryptoRepository;
        //    }
        //}

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}