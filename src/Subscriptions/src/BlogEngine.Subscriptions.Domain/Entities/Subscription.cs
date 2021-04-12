using System.Collections.Generic;
using System.Linq;
using BlogEngine.Domain.Common.ValueObjects;
using BlogEngine.Domain.Core;
using JetBrains.Annotations;

namespace BlogEngine.Subscriptions.Domain.Entities
{
    public sealed class Subscription : Entity
    {
        private readonly ICollection<HashTag> _hashTags = new HashSet<HashTag>();

        [UsedImplicitly]
        private Subscription() { }

        public Subscription(string email, IEnumerable<string> hashTags)
        {
            Email = email;

            foreach (var hashTag in hashTags) _hashTags.Add(new HashTag(hashTag));
        }

        public string Email { get; }

        public IReadOnlyCollection<HashTag> HashTags => _hashTags.ToList();

        public void Update(IEnumerable<string> hashTags)
        {
            _hashTags.Clear();

            foreach (var hashTag in hashTags) _hashTags.Add(new HashTag(hashTag));
        }
    }
}