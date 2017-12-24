using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Individual
    {
        public Individual()
        {
            AlbumIndividual = new HashSet<Album>();
            AlbumModified = new HashSet<Album>();
            CommentAuthor = new HashSet<Comment>();
            CommentModified = new HashSet<Comment>();
            CommentRecipient = new HashSet<Comment>();
            MessageAuthor = new HashSet<Message>();
            MessageModified = new HashSet<Message>();
            MessageRecipient = new HashSet<Message>();
            ModelModified = new HashSet<Model>();
            PhotoNavigation = new HashSet<Photo>();
            PhotographerModified = new HashSet<Photographer>();
            Responded = new HashSet<Responded>();
            Social = new HashSet<Social>();
            StylistModified = new HashSet<Stylist>();
            TfpEventAuthor = new HashSet<TfpEvent>();
            TfpEventModified = new HashSet<TfpEvent>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        

        public Category Category { get; set; }
        public City City { get; set; }
        public Model ModelIdNavigation { get; set; }
        public Photographer PhotographerIdNavigation { get; set; }
        public Stylist StylistIdNavigation { get; set; }
        public User User { get; set; }
        public ICollection<Album> AlbumIndividual { get; set; }
        public ICollection<Album> AlbumModified { get; set; }
        public ICollection<Comment> CommentAuthor { get; set; }
        public ICollection<Comment> CommentModified { get; set; }
        public ICollection<Comment> CommentRecipient { get; set; }
        public ICollection<Message> MessageAuthor { get; set; }
        public ICollection<Message> MessageModified { get; set; }
        public ICollection<Message> MessageRecipient { get; set; }
        public ICollection<Model> ModelModified { get; set; }
        public ICollection<Photo> PhotoNavigation { get; set; }
        public ICollection<Photographer> PhotographerModified { get; set; }
        public ICollection<Responded> Responded { get; set; }
        public ICollection<Social> Social { get; set; }
        public ICollection<Stylist> StylistModified { get; set; }
        public ICollection<TfpEvent> TfpEventAuthor { get; set; }
        public ICollection<TfpEvent> TfpEventModified { get; set; }
    }
}
