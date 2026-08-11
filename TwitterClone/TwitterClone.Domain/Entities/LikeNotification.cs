using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class LikeNotification : Notification
    {
        public LikeNotification(Guid likeUserById) : base("type")
        {
            LikeUserById = likeUserById;
        }

        public Guid LikeUserById { get; set; }
    }
}
