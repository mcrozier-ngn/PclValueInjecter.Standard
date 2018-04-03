﻿using Xunit;

namespace Xciles.PclValueInjecter.Tests
{
    
    public class KohanTests
    {
        [Fact]
        public void Test()
        {
            var pc = new ProgrammeClient
                         {
                             Id = 1,
                             Client = new Client{Id =3, Name = "foo"},
                         };
            
            var pcvm = new ProgrammeClientViewModel();
            pcvm.InjectFrom<FlatLoopValueInjection>(pc);

            Assert.Equal(pc.Id, pcvm.Id);
            Assert.Equal(pc.Client.Id, pcvm.ClientId);
            Assert.Equal(pc.Client.Name, pcvm.ClientName);
        }

        public class ProgrammeClientViewModel
        {
            public int Id { get; set; }

            public int ClientId { get; set; }

            public string ClientName { get; set; }
            public int ClientAddressCountryId { get; set; }

        }

        public interface IProgrammeClient
        {
            IClient Client { get; set; }
        }

        public interface IClient : IEntity
        {
            string Name { get; set; }
        }

        public interface IEntity
        {
            int Id { get; set; }
        }

        public abstract class Entity : IEntity
        {
            public int Id { get; set; }
        }

        public class ProgrammeClient : Entity, IProgrammeClient
        {

            public virtual IClient Client { get; set; }
        }

        public class Client : Entity, IClient
        {
            public virtual string Name { get; set; }
        }
    }
}