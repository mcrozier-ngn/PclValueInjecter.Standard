﻿using Xciles.NetStandardValueInjecter.Extensions;
using Xunit;

namespace Xciles.NetStandardValueInjecter.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void RemovePrefix()
        {
            const string s = "txtName";
            s.RemovePrefix("txt").IsEqualTo("Name");
        }

        [Fact]
        public void RemoveSuffix()
        {
            const string s = "NameRaw";
            s.RemoveSuffix("Raw").IsEqualTo("Name");
        }
        // todo add more ;)
    }
}