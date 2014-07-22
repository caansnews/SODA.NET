﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SODA.Utilities;

namespace SODA
{
    [DataContract]
    public class ResourceMetadata
    {
        [DataMember(Name="id")]
        public string Identifier { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "attribution")]
        public string Attribution { get; set; }

        [DataMember(Name = "attributionLink")]
        public string AttributionLink { get; set; }

        [DataMember(Name = "averageRating")]
        public decimal AverageRating { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "createdAt")]
        public double? CreationDateUnix { get; set; }

        public DateTime? CreationDate
        {
            get
            {
                if (CreationDateUnix.HasValue)
                {
                    return DateTimeConverter.FromUnixTimestamp(CreationDateUnix.Value);
                }

                return default(DateTime?);
            }
        }
                
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "displayType")]
        public string DisplayType { get; set; }

        [DataMember(Name = "downloadCount")]
        public long DownloadsCount { get; set; }

        [DataMember(Name = "numberOfComments")]
        public long CommentsCount { get; set; }

        [DataMember(Name = "publicationDate")]
        public double? PublishedDateUnix { get; set; }

        public DateTime? PublishedDate
        {
            get
            {
                if (PublishedDateUnix.HasValue)
                {
                    return DateTimeConverter.FromUnixTimestamp(PublishedDateUnix.Value);
                }

                return default(DateTime?);
            }
        }

        [DataMember(Name = "rowsUpdatedAt")]
        public double? RowsLastUpdatedUnix { get; set; }

        public DateTime? RowsLastUpdated
        {
            get
            {
                if (RowsLastUpdatedUnix.HasValue)
                {
                    return DateTimeConverter.FromUnixTimestamp(RowsLastUpdatedUnix.Value);
                }

                return default(DateTime?);
            }
        }

        [DataMember(Name = "tableId")]
        public long TableId { get; set; }

        [DataMember(Name = "totalTimesRated")]
        public long RatingsCount { get; set; }

        [DataMember(Name = "viewCount")]
        public long ViewsCount { get; set; }

        [DataMember(Name = "viewLastModified")]
        public double? SchemaLastUpdatedUnix { get; set; }

        public DateTime? SchemaLastUpdated
        {
            get
            {
                if (SchemaLastUpdatedUnix.HasValue)
                {
                    return DateTimeConverter.FromUnixTimestamp(SchemaLastUpdatedUnix.Value);
                }

                return default(DateTime?);
            }
        }

        [DataMember(Name = "viewType")]
        public string ViewType { get; set; }

        [DataMember(Name = "columns")]
        public IEnumerable<Column> Columns { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "metadata")]
        public Dictionary<string, dynamic> Metadata { get; set; }

        public Dictionary<string, Dictionary<string, string>> CustomMetadata
        {
            get
            {
                var customMetadata = new Dictionary<string, Dictionary<string, string>>();

                if (Metadata != null && Metadata.ContainsKey("custom_fields"))
                {
                    customMetadata = (Dictionary<string, Dictionary<string, string>>)Metadata["custom_fields"];
                }

                return customMetadata;
            }
        }

        [DataMember(Name = "privateMetadata")]
        public Dictionary<string, dynamic> PrivateMetadata { get; set; }

        public string ContactEmail
        {
            get
            {
                if (PrivateMetadata != null && PrivateMetadata.ContainsKey("contactEmail"))
                {
                    return (string)PrivateMetadata["contactEmail"];
                }

                return null;
            }
        }
    }
}