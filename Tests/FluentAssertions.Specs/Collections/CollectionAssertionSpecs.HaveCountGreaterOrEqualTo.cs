﻿using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections
{
    /// <content>
    /// The HaveCountGreaterOrEqualTo specs.
    /// </content>
    public partial class CollectionAssertionSpecs
    {
        #region Have Count Greater Or Equal To

        [Fact]
        public void Should_succeed_when_asserting_collection_has_a_count_greater_or_equal_to_less_the_number_of_items()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act / Assert
            collection.Should().HaveCountGreaterOrEqualTo(3);
        }

        [Fact]
        public void Should_fail_when_asserting_collection_has_a_count_greater_or_equal_to_the_number_of_items()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act
            Action act = () => collection.Should().HaveCountGreaterOrEqualTo(4);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_collection_has_a_count_greater_or_equal_to_the_number_of_items_it_should_fail_with_descriptive_message_()
        {
            // Arrange
            var collection = new[] { 1, 2, 3 };

            // Act
            Action action = () => collection.Should().HaveCountGreaterOrEqualTo(4, "because we want to test the failure {0}", "message");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("*at least*4*because we want to test the failure message*3*");
        }

        [Fact]
        public void When_collection_count_is_greater_or_equal_to_and_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                collection.Should().HaveCountGreaterOrEqualTo(1, "we want to test the behaviour with a null subject");
            };

            // Assert
            act.Should().Throw<XunitException>().WithMessage("*at least*1*we want to test the behaviour with a null subject*found <null>*");
        }

        #endregion
    }
}
