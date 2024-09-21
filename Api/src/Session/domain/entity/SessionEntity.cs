using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using backend.src.User.domain.entity;

namespace Api.src.Session.domain.entity
{
    public class SessionEntity
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public UserEntity User { get; set; }
    }
}