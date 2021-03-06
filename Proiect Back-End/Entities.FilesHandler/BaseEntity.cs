﻿using System;

namespace Entities.FilesHandler
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid EntityId { get; set; }

        public Guid? AuthorId { get; set; }

        public DateTime LastChangeDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
