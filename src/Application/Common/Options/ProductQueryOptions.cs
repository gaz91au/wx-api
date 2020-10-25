using Application.Common.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Application.Common.Options
{
    public class ProductQueryOptions : IEquatable<ProductQueryOptions>
    {
        public SortOption SortOption { get; set; }

        public bool Equals([AllowNull] ProductQueryOptions other)
        {
            if (other == null)
            {
                return false;
            }
            return SortOption == other.SortOption;
        }
    }
}
