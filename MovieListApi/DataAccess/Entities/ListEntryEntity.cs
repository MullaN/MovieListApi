using System;
using Dapper.Contrib.Extensions;

namespace MovieListApi.DataAccess.Entities
{
    [Table("listentries")]
    public class ListEntryEntity
    {
        [ExplicitKey]
        public Guid ListEntryId { get; set; }
        public Guid ListId { get; set; }
        public string MovieId { get; set; }
    }
}