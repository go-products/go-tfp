namespace TFP.Domain.Entities
{
    public class AlbumPhoto
    {
        public int AlbumId { get; set; }
        public int PhotoId { get; set; }

        public Album Album { get; set; }
        public Photo Photo { get; set; }
    }
}