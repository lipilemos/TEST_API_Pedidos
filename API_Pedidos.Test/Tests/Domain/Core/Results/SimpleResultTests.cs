﻿using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Test.Base;
using FluentAssertions;
using NUnit.Framework;

namespace API_Pedidos.Test.Tests.Domain.Core.Results
{
    public class SimpleResultTests : UnitTestBase
    {
        [Test]
        public void Ok_should_create_a_Result_with_no_Error()
        {
            // Arrange - Act
            var result = SimpleResult.Ok();

            // Assert
            result.HasError.Should().BeFalse();
            result.Errors.Should().BeEmpty();
        }

        [Test]
        public void Error_should_set_a_list_of_Error()
        {
            // Arrange
            var expectedErrorList = new List<Error> {
                new Error("SomeProperty1", "Some message 1"),
                new Error("SomeProperty2", "Some message 2")
            };

            // Act
            var result = SimpleResult.Error(expectedErrorList);

            // Assert
            result.HasError.Should().BeTrue();
            result.Errors.Should().BeEquivalentTo(expectedErrorList);
        }

        [Test]
        public void Error_should_set_an_Error_correctly()
        {
            // Arrange
            var expectedError = new Error("SomeProperty", "Some message");
            var expectedErrorList = new List<Error> { expectedError };

            // Act
            var result = SimpleResult.Error(expectedError);

            // Assert
            result.HasError.Should().BeTrue();
            result.Errors.Should().BeEquivalentTo(expectedErrorList);
        }
    }
}
