using System;
using System.Collections.Generic;
using System.Text;
using TFP.Core.Repositories;
using TFP.Core.Repositories.Interfaces;
using TFP.Domain.Entities;
using TFP.Persistence.Context;

namespace TFP.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TfpContext _context;

        private bool _disposed;

        private IGenericRepository<Album> _albumRepository;
        private IGenericRepository<Comment> _commentRepository;
        private IGenericRepository<Individual> _individualStatusRepository;
        private IGenericRepository<Message> _messageRepository;
        private IGenericRepository<Model> _modelRepository;
        private IGenericRepository<Permission> _permissionTypeRepository;
        private IGenericRepository<Photo> _photoRepository;
        private IGenericRepository<Photographer> _photograferRepository;
        private IGenericRepository<Responded> _respondedRepository;
        private IGenericRepository<PhotographerShootingGenre> _photographerShootingGenreRepository;
        private IGenericRepository<Social> _socialRepository;
        private IGenericRepository<Stylist> _stylistRepository;
        private IGenericRepository<StylistSpecialization> _stylistSpecializationRepository;
        private ITfpEventRepository _tfpEventRepository;
        private IGenericRepository<TfpEventPhoto> _tfpEventPhotoRepository;



        public UnitOfWork(TfpContext context)
        {
            _context = context;
        }

        public IGenericRepository<Album> AlbumRepository =>
            _albumRepository ?? (_albumRepository = new GenericRepository<Album>(_context));

        public IGenericRepository<Comment> CommentRepository =>
            _commentRepository ?? (_commentRepository = new GenericRepository<Comment>(_context));

        public IGenericRepository<Individual> IndividualStatusRepository =>
              _individualStatusRepository ?? (_individualStatusRepository = new GenericRepository<Individual>(_context));

        public IGenericRepository<Message> MessageRepository =>
              _messageRepository ?? (_messageRepository = new GenericRepository<Message>(_context));

        public IGenericRepository<Model> ModelRepository =>
              _modelRepository ?? (_modelRepository = new GenericRepository<Model>(_context));

        public IGenericRepository<Permission> PermissionTypeRepository =>
            _permissionTypeRepository ?? (_permissionTypeRepository = new GenericRepository<Permission>(_context));

        public IGenericRepository<Photo> PhotoRepository =>
           _photoRepository ?? (_photoRepository = new GenericRepository<Photo>(_context));

        public IGenericRepository<Photographer> PhotograferRepository =>
        _photograferRepository ?? (_photograferRepository = new GenericRepository<Photographer>(_context));

        public IGenericRepository<Responded> RespondedRepository =>
        _respondedRepository ?? (_respondedRepository = new GenericRepository<Responded>(_context));

        public IGenericRepository<PhotographerShootingGenre> PhotographerShootingGenreRepository =>
        _photographerShootingGenreRepository ?? (_photographerShootingGenreRepository = new GenericRepository<PhotographerShootingGenre>(_context));

        public IGenericRepository<Social> SocialRepository =>
        _socialRepository ?? (_socialRepository = new GenericRepository<Social>(_context));

        public IGenericRepository<Stylist> StylistRepository =>
        _stylistRepository ?? (_stylistRepository = new GenericRepository<Stylist>(_context));

        public IGenericRepository<StylistSpecialization> StylistSpecializationRepository =>
        _stylistSpecializationRepository ?? (_stylistSpecializationRepository = new GenericRepository<StylistSpecialization>(_context));

        public ITfpEventRepository TfpEventRepository =>
        _tfpEventRepository ?? (_tfpEventRepository = new TfpEventRepository(_context));

        public IGenericRepository<TfpEventPhoto> TfpEventPhotoRepository =>
        _tfpEventPhotoRepository ?? (_tfpEventPhotoRepository = new GenericRepository<TfpEventPhoto>(_context));
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
