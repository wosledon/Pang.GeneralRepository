using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Pang.GeneralRepository.Web.Entities;

namespace Pang.GeneralRepository.Web.Dtos
{
    [AutoMap(typeof(TestUser2), ReverseMap = true)]
    public class UserDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public string FirstName{get; set;}
        [JsonIgnore]
        public string LastName{get; set;}

        public string Name
        {
            get
            {
                return FirstName + LastName;
            }
            set{}
        }

        public IEnumerable<UserItem> UserItems { get; set; }
    }
}