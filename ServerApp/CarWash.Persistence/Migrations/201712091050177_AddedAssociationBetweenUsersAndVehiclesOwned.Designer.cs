// <auto-generated />
namespace CarWash.Persistence.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddedAssociationBetweenUsersAndVehiclesOwned : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedAssociationBetweenUsersAndVehiclesOwned));
        
        string IMigrationMetadata.Id
        {
            get { return "201712091050177_AddedAssociationBetweenUsersAndVehiclesOwned"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
