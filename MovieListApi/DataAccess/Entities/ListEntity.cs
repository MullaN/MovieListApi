using System;
using Dapper.Contrib.Extensions;

namespace MovieListApi.DataAccess.Entities
{
    [Table("lists")]
    public class ListEntity
    {
        [ExplicitKey]
        public Guid ListId { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        [Write(false)]
        public List<MovieEntity> Movies { get; set; }
    }
}