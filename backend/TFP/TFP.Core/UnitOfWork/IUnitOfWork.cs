using System;
using System.Collections.Generic;
using System.Text;
using TFP.Core.Repositories.Interfaces;
using TFP.Domain.Entities;

namespace TFP.Core.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Album> AlbumRepository { get; }
         IGenericRepository<Comment> CommentRepository { get; }
         IGenericRepository<Individual> IndividualStatusRepository { get; }
         IGenericRepository<Message> MessageRepository { get; }
        IGenericRepository<Model> ModelRepository { get; }
        IGenericRepository<Permission> PermissionTypeRepository { get; }
        IGenericRepository<Photo> PhotoRepository { get; }
        IGenericRepository<Photographer> PhotograferRepository { get; }
        IGenericRepository<Responded> RespondedRepository { get; }
        IGenericRepository<PhotographerShootingGenre> PhotographerShootingGenreRepository { get; }
        IGenericRepository<Social> SocialRepository { get; }
        IGenericRepository<Stylist> StylistRepository { get; }
        IGenericRepository<StylistSpecialization> StylistSpecializationRepository { get; }
        IGenericRepository<TfpEvent> TfpEventRepository { get; }
        IGenericRepository<TfpEventPhoto> TfpEventPhotoRepository { get; }

        void Save();
    }
}
