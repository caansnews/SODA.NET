﻿using NUnit.Framework;
using SODA.Tests.Mocks;
using System;
using System.Net;

namespace SODA.Tests
{
    [TestFixture]
    public class ResourceTests
    {
        SodaClient mockClient;
        ResourceMetadata mockMetadata;

        [SetUp]
        public void TestSetup()
        {
            mockClient = new SodaClient(StringMocks.Host, StringMocks.NonEmptyInput);
            mockMetadata = new ResourceMetadata(mockClient);
            mockMetadata.Identifier = "1234-abcd";
        }

        [Test]
        [Category("Resource")]
        public void New_Gets_Metadata_Client()
        {
            var metadata = new ResourceMetadata(mockClient);

            var resource = new Resource<object>(metadata);

            Assert.AreSame(metadata.Client, resource.Client);
        }

        [Test]
        [Category("Resource")]
        public void New_Gets_Metadata_Host()
        {
            var metadata = new ResourceMetadata(mockClient);

            var resource = new Resource<object>(metadata);

            Assert.AreEqual(metadata.Host, resource.Host);
        }

        [Test]
        [Category("Resource")]
        public void New_Gets_Metadata_Columns()
        {
            var metadata = new ResourceMetadata(mockClient) {
                Columns = new[]
                { 
                    new ResourceColumn() { Name = "column1" },
                    new ResourceColumn() { Name = "column2" },
                    new ResourceColumn() { Name = "column3" }
                }
            };

            var resource = new Resource<object>(metadata);

            Assert.AreSame(metadata.Columns, resource.Columns);
        }

        [Test]
        [Category("Resource")]
        public void New_Gets_Metadata_Identifier()
        {
            var metadata = new ResourceMetadata(mockClient) { Identifier = "identifier" };

            var resource = new Resource<object>(metadata);

            Assert.AreSame(metadata.Identifier, resource.Identifier);
        }

        [TestCase(StringMocks.EmptyInput)]
        [TestCase(StringMocks.NullInput)]
        [ExpectedException(typeof(ArgumentException))]
        [Category("Resource")]
        public void GetRow_With_Invalid_RowId_Throws_ArugmentException(string input)
        {
            new Resource<object>(mockMetadata).GetRow(input);
        }

        [Test]
        [Category("Resource")]
        public void Query_With_UndefinedLimit_UsesMaximum()
        {
            var resource = new Resource<object>(mockMetadata);
            var query = new SoqlQuery();

            var initialValue = query.LimitValue;

            try
            {
                resource.Query(query);
            }
            catch (WebException ex)
            {
                //pass
            }

            Assert.Greater(query.LimitValue, initialValue);
            Assert.AreEqual(SoqlQuery.MaximumLimit, query.LimitValue);
        }
    }
}
