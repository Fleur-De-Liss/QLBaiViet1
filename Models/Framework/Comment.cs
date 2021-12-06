namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [StringLength(5)]
        public string CommentId { get; set; }

        [Required]
        [StringLength(255)]
        public string Ccontent { get; set; }

        [Required]
        [StringLength(5)]
        public string UserId { get; set; }

        [Required]
        [StringLength(5)]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
