# ATEA-Coding-Challenge

The project is a Console Application and therefore the entry point is the static Main method.
I chose to not use the .NET6+ non-scoped namespaces for clarity in the structure.
The framework used is .NET7 and the libraries used match its version, including Pomelo which required an alpha version in order to work. 

Right after the entry point, there is a simple check for the amount of arguments provided. 
As the requirement is to provide only two arguments, I opted for throwing an exception in case of a wrong amount of them.

I use a IHostBuilder for creating all the services and accessing the appsettings.json file in order to retrieve the configuration.

The following section retrieves such services and configuration and attempts a database migration at launch, in order to check for 
the existence of the database and its validity. The migrations make use of EntityFramework.

I then create a businessLayer object used for all the CRUD operations, save the passed arguments, and then continue with a loop.

Right before the loop, for readability, I'll display the sum of the two arguments.
The aforementioned loop will allow the user to chose between two options: 
- read through all the entries in the database
- read all the entries and select one, which brings to the details of the selected operation

In order to display the sum of these two arguments, I created an extension method which checks in a very basic way for the type of the arguments,
applies some very basic validation, and returns a string according to the proper variable type.

Note that in case on numeric entries, the string result is a numeric sum of the two values.

The read and write operations to the SQL database are performed through the Persistence service, which contains:
- a generic repository with its own interface, in case of scalability
- a dedicated repository with its interface for specific operations required by this very entity.

The DbContext uses EF as well, and doesn't provide specific OnModelCreating requirements due to the simplicity of the entity.

After the loop is interrupted, the application ceases to run. This is a design choice as the application can be called on demand for 
any particular use case. In case I would have needed to let the application keep on running, I would personally have structured differently.
For instance, through an enpdoint and with the host.Run() method looping the execution, without the while loop, but leaving the user
with the possibility to query the database and write to it indefinitely.

Lastly, you'll find a UnitTest project using nUnit and some very basic testing over the extension method:
- one test for each valid variable type
- one test for each case in which the application is expected to throw an exception