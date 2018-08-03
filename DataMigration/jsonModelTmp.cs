using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigration
{

public class RepositoryAttribute
{
    public string Name { get; set; }
    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }
}

public class PartitionMappingAttribute
{
    public string KahuaOperationName { get; set; }
    public string KahuaAttributeName { get; set; }
    public int KahuaDataType { get; set; }
    public RepositoryAttribute RepositoryAttribute { get; set; }
    public string RepositoryOperationName { get; set; }
}

public class OperationMapping
{
    public string ContractItems { get; set; }
    public string ContractItemsItems { get; set; }
    public string ContractItemsItemsItems { get; set; }
}

public class RepositoryAttribute2
{
    public string Name { get; set; }
    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }
}

public class ContractItem
{
    public string KahuaOperationName { get; set; }
    public string KahuaAttributeName { get; set; }
    public int KahuaDataType { get; set; }
    public RepositoryAttribute2 RepositoryAttribute { get; set; }
    public string RepositoryOperationName { get; set; }
}

public class RepositoryAttribute3
{
    public string Name { get; set; }
    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }
}

public class ContractItemsItem
{
    public string KahuaOperationName { get; set; }
    public string KahuaAttributeName { get; set; }
    public int KahuaDataType { get; set; }
    public RepositoryAttribute3 RepositoryAttribute { get; set; }
    public string RepositoryOperationName { get; set; }
}

public class AttributeMapping
{
    public List<ContractItem> ContractItems { get; set; }
    public List<ContractItemsItem> ContractItemsItems { get; set; }
    public List<object> ContractItemsItemsItems { get; set; }
}

public class RootObject
{
    public string Environment { get; set; }
    public string Domain { get; set; }
    public string Inflow { get; set; }
    public int ResolvePartitionType { get; set; }
    public PartitionMappingAttribute PartitionMappingAttribute { get; set; }
    public OperationMapping OperationMapping { get; set; }
    public AttributeMapping AttributeMapping { get; set; }
}
}
