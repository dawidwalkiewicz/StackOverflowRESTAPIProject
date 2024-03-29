using System.Runtime.Serialization;

namespace StackOverflowRESTAPIProject.Repositories
{
    public interface IWrapperCollection<TEntity> where TEntity : class
    {
        public int Count { get; set; }

        [DataMember(Name = "items")]
        List<TEntity> Items { get; set; }

        [DataMember(Name = "has_more")]
        bool? HasMore { get; set; }

        [DataMember(Name = "quota_max")]
        int? QuotaMax { get; set; }

        [DataMember(Name = "quota_remaining")]
        int? QuotaRemaining { get; set; }
    }
}