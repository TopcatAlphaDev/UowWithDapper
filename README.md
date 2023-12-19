# UowWithDapper
Example how we can use unitofwork for repositories using dapper and autofac.

This code shows a few examples in testclasses, covering different usages about uow with repositories defined, injected by constructor, by function, lazy loading using the autofac func<>, instantiation of the uow in class, by constructor,...

i prefer testclass 6 as the code is completely testable because all code is injected by constructor and not instantiated in class, its easy readable because of defined, specific type of uow and its easy to create a new uow only by inheritance and exposing the repositories by properties.

The base classes support:
- transactionlevels (not required)
- dynamic assigning repositories
- aswel read as write
- async query calls
- Doesnt require transactions for reading
- autofac safe and threaded execution safe ( See 3 levels of testruns )
- chaining format for who prefers coding like this.

Be aware 
- that using singletons can raise errors because those repositorie instants can only be owned by one uow, can only have one transaction.
- Not tested the maximum nbr of repositories, but should not be problematic when single responsibility and separation of concerns is kept in mind.
