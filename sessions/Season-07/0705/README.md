# 0705 - Databases on Azure

It's great to run an application on Azure, but what about storing data so that we can scan and update it quickly with a database?  There are several options deployed and available as a service on Azure, and we'll review a few of them in this session.

We won't teach you how to use each of these services, but rather show you the options to get the service configured and how you can work with it.

## SQL Server

The Microsoft database offering has MANY configuration options on Azure, enough to meet every need and pricing requirement.  There are several service options available:

- [SQL Managed Instances](https://learn.microsoft.com/azure/azure-sql/managed-instance/sql-managed-instance-paas-overview) - A deployed version of SQL Server managed for you on Azure that is compatible with versions going back to SQL 2008
- [Azure SQL](https://learn.microsoft.com/azure/azure-sql/database/sql-database-paas-overview) - A fully managed, always updated, latest version of SQL Server running for you
- [SQL Server on VM](https://learn.microsoft.com/azure/azure-sql/virtual-machines/windows/sql-server-on-azure-vm-iaas-what-is-overview?view=azuresql) - Run SQL Server on a Virtual Machine just like you would in your own data center.

There are additional options to configure SQL Server on the Edge with IoT devices, and in Hybrid mode so that you extend SQL Server running on premises to the cloud for additional resources.  We're focusing on running only on Azure.

Options are available to even run SQL Server in a [Serverless configuration](https://learn.microsoft.com/azure/azure-sql/database/serverless-tier-overview) for applications that start and stop regularly and you don't want to pay to have an idle database.

You can develop and test locally using the [Azure SQL Emulator](https://learn.microsoft.com/azure/azure-sql/database/local-dev-experience-sql-database-emulator). 

You can configure your Azure SQL Instances in clusters, with elastic pools of resources and read-only replicas as needed.

### Deploy and Configure Firewall

### Connections and Connectionstrings

## MySQL

Fully-managed MySQL Community Edition instances and clusters can be configured as well, with resources allocated per core, RAM, and storage required. 

You can run with MySQL Flexible server that allows you to burst and use managed computer resources or you can run MySQL on a virtual machine for a more managed IAAS solution.

Details about the service are on [learn.microsoft.com](https://learn.microsoft.com/azure/mysql/single-server/overview)

## Postgres

Similarly, you can run a fully-managed Postgres database on flexible resources or on a VM for an IAAS solution.

Details on [learn.microsoft.com](https://learn.microsoft.com/azure/postgresql/single-server/overview)

## CosmosDb

[Cosmos Db](https://learn.microsoft.com/azure/cosmos-db/introduction) is the ultimate multi-tool for database development with relational, NoSQL, and geo-replication features and durability.

There are APIs and structures available in CosmosDb to support connecting and using it like:

- NoSQL database
- MongoDb
- PostgreSQL
- Apache Cassandra
- Gremlin
- Key/Value pairs like Azure Table Storage

CosmosDb has a free configuration available that allows you to deploy a single 25 GB database instance with 1000 RU/s.

## Redis

[Azure Redis Cache](https://learn.microsoft.com/azure/azure-cache-for-redis/cache-overview) is the high-speed in-memory key-value pair solution that can turbo-charge your application.