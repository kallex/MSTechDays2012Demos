
using System.Collections.Generic;
	
			public partial class TechDays2012DemoEntities
	{
			public ObjectSet`1 Classes { get; set; }
				public ObjectSet`1 ClassProperties { get; set; }
				public DbConnection Connection { get; set; }
				public String DefaultContainerName { get; set; }
				public MetadataWorkspace MetadataWorkspace { get; set; }
				public ObjectStateManager ObjectStateManager { get; set; }
				public Nullable`1 CommandTimeout { get; set; }
				public ObjectContextOptions ContextOptions { get; set; }
			}
			public partial class Class
	{
			public Int64 ID { get; set; }
				public String ClassName { get; set; }
				public EntityCollection`1 ClassProperties { get; set; }
				public EntityState EntityState { get; set; }
				public EntityKey EntityKey { get; set; }
			}
			public partial class ClassProperty
	{
			public Int64 ID { get; set; }
				public Int64 ClassID { get; set; }
				public String PropertyName { get; set; }
				public String PropertyType { get; set; }
				public Boolean ValidateOnSet { get; set; }
				public Class Class { get; set; }
				public EntityReference`1 ClassReference { get; set; }
				public EntityState EntityState { get; set; }
				public EntityKey EntityKey { get; set; }
			}
			public partial class Program
	{
		}
			
